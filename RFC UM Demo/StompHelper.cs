using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RFC_UM_Demo
{
    public delegate void ListUpdatedEventHandler(Dictionary<string, TagBlinkLite> list_tags, TagBlinkLite tbl);

    public class StompHelper 
    {

        CancellationTokenSource s_cts; //new CancellationTokenSource();
        int TagsTotalNumber;
        Dictionary<string,TagBlinkLite> lst_tags = new Dictionary<string, TagBlinkLite>();
        public event ListUpdatedEventHandler ListUpdated;

        public StompHelper()
        {
            TagsTotalNumber = 0;
        }

        struct TagReportStructure
        {
            public String epc;
            public Double x;
            public Double y;
            public Double z;
        };


        #region TagParsing

        
        bool TagParse(String indata, ref TagReportStructure tag)
        {
            bool validTag = false;

            try
            {
                indata = indata.Replace('"', ' ');
                indata = indata.Replace('/', ' ');
                indata = indata.Trim();

                string[] fields = indata.Split(',');

                int fieldCnt;
                for (fieldCnt = 0; fieldCnt < fields.GetUpperBound(0); fieldCnt++)
                {
                    string[] param = fields[fieldCnt].Split(':');

                    string compareStr = param[0].Trim();

                    if (compareStr.Equals("tagID"))
                    {
                        tag.epc = param[1];
                        validTag = true;
                    }
                    if (compareStr == "x")
                        tag.x = Convert.ToDouble(param[1]);
                    if (compareStr == "y")
                        tag.y = Convert.ToDouble(param[1]);
                    if (compareStr == "z")
                        tag.z = Convert.ToDouble(param[1]);

                }
            }
            catch (Exception e)
            {
                validTag = false;
            }
            return (validTag);
        }

        #endregion

        const int RECEIVED_BUFFER_SIZE = 64000;


        #region ReadRFServAsync

       
        async Task ReadRFServAsync()
        {
            try
            {
                string url_s = "ws://172.16.160.90:8888/websockets/messaging/websocket";

                string UserName = "admin";
                string Password = "admin";

                System.Net.WebSockets.ClientWebSocket os_sock = new System.Net.WebSockets.ClientWebSocket();

                string encStr = UserName + ":" + Password;
                byte[] encBytes = System.Text.Encoding.UTF8.GetBytes(encStr);
                encStr = Convert.ToBase64String(encBytes);
                os_sock.Options.SetRequestHeader("Authorization", "Basic " + encStr);

                Uri uri = new Uri(url_s);

                await os_sock.ConnectAsync(uri, System.Threading.CancellationToken.None);

                if (os_sock.State == System.Net.WebSockets.WebSocketState.Open)
                {

                    byte[] rBytes = new byte[RECEIVED_BUFFER_SIZE];
                    ArraySegment<byte> rSeg = new ArraySegment<byte>(rBytes);

                    Console.WriteLine("Start Connection");

                    string startStr = "CONNECT\naccept-version:1.1,1.0\nheart-beat:10000,10000\n\n\u0000";
                    await os_sock.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(startStr)), System.Net.WebSockets.WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);

                    await os_sock.ReceiveAsync(rSeg, System.Threading.CancellationToken.None);
                    Console.WriteLine("Connected");


                    /* pick random number to identify subscription number */
                    var random = new Random();
                    int idnum = random.Next(1000);
                    string idNumS = idnum.ToString();


                    string subStr = "SUBSCRIBE\nid:" + idNumS + "\ndestination:/topic/tagBlinkLite.*\nack:auto\n\n\u0000";
                    await os_sock.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(subStr)), System.Net.WebSockets.WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);


                    await os_sock.ReceiveAsync(rSeg, System.Threading.CancellationToken.None);
                    Console.WriteLine("Subscribed");


                    while (s_cts.IsCancellationRequested == false)
                    {
                        int numberBytesRecieved = 0;
                        System.Net.WebSockets.WebSocketReceiveResult ws;

                        ws = await os_sock.ReceiveAsync(new ArraySegment<byte>(rBytes, numberBytesRecieved, (RECEIVED_BUFFER_SIZE - numberBytesRecieved)), System.Threading.CancellationToken.None);
                        numberBytesRecieved = ws.Count;


                        /* stomp packets can extend multiple buffers --- keep checking and reading until entire package is done */
                        while ((ws.EndOfMessage == false) && (numberBytesRecieved < RECEIVED_BUFFER_SIZE))
                        {
                            ws = await os_sock.ReceiveAsync(new ArraySegment<byte>(rBytes, numberBytesRecieved, (RECEIVED_BUFFER_SIZE - numberBytesRecieved)), System.Threading.CancellationToken.None);
                            numberBytesRecieved += ws.Count;
                        }


                        string info = Encoding.Default.GetString(rBytes);       /* convert to string */

                        /* generate display info for this demo */
                        string DisplayTagInfo = "";
                        string DisplayStompprotocol = "";

                        /* parse through stomp message */
                        bool bodyIsNext = false;
                        string[] headers = info.Split('\n');        /* initial header fields of stomp protocol use line feeds to seperate fields --- body of message is AFTER a blank line feed */

                        int headerCnt;

                        for (headerCnt = 0; headerCnt <= headers.GetUpperBound(0); headerCnt++)
                        {
                            if (headers[headerCnt] == "")
                                bodyIsNext = true;      /* blank line feed body of message is next */
                            else if (bodyIsNext == true)
                            {
                                /* parse through tag read information */
                                /* tags are delimited by {}  */
                                string[] tagStr = headers[headerCnt].Split('{');
                                int tagCnt;

                                /* parse through each tag */
                                for (tagCnt = 0; tagCnt < tagStr.GetUpperBound(0); tagCnt++)
                                {
                                    /* parse tag string into tag structure */
                                    TagReportStructure newTag = new TagReportStructure();
                                    if (TagParse(tagStr[tagCnt], ref newTag) == true)
                                    {
                                        /* Tag found & Parsed ----- display information      */
                                        DisplayTagInfo = DisplayTagInfo + tagStr[tagCnt] + "\r\n";


                                        /* Update List View with Tag information *******************************************************************************************/
                                        TagListUpdate(newTag); /* UPDATE list view */
                                    }
                                }

                            }
                            else
                            {
                                /* STOMP Message Protocol  ----- Each enty is seperated by line return  with a : between header and data  */
                                DisplayStompprotocol = DisplayStompprotocol + headers[headerCnt] + "\r\n";
                            }

                        }


                        //txt_out.Text = DisplayStompprotocol + DisplayTagInfo;

                        /* send out byte to keep alive */
                        string contStr = "\n";
                        await os_sock.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(contStr)), System.Net.WebSockets.WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
                    }
                }

                //os_sock .CloseAsync()
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //txt_out.Text = e.Message;
            }
        }

        #endregion
        public async void GetTagblinkLite(object sender, EventArgs e)
        {

            //cmd_start.Enabled = false;

            /*
             * 
             * Error with websocket 1st  attempt at connectin fails due to invalid header in library negotitions ------  when tried again the error does not happen
             * 
             * fix --- run instance of Read --- it will error out --- run instance of read again and it works  
             * 
             * see error info from msdn  

            https://social.msdn.microsoft.com/Forums/en-US/e0c40dca-8a8e-4bb1-baf1-9c1e683a8132/websocketclient-connection-header-values?forum=netfxbcl

            */

            s_cts = new CancellationTokenSource();
            Task readRFServTask = ReadRFServAsync();
            await readRFServTask;


            /* run again --- */
            s_cts = s_cts = new CancellationTokenSource();
            Task readRFServTaskb = ReadRFServAsync();
            await readRFServTaskb;

            //cmd_start.Enabled = true;
        }

        public void cmd_stop_Click(object sender, EventArgs e)
        {
            s_cts.Cancel();
        }




        /* update list view */

        void TagListUpdate(TagReportStructure tag)
        {

            int tagCnt;
            bool match = false;
            TagBlinkLite newTagBlink = new TagBlinkLite();
            if (lst_tags.ContainsKey(tag.epc))
            {
                lst_tags[tag.epc].x = tag.x;
                lst_tags[tag.epc].y = tag.y;
                newTagBlink = lst_tags[tag.epc];
            }
            else
            {
                newTagBlink.tagID = tag.epc;

                newTagBlink.x= tag.x;
                newTagBlink.y = tag.y;
                lst_tags.Add(tag.epc,newTagBlink);
                TagsTotalNumber++;
            }
            ListUpdated.Invoke(lst_tags,newTagBlink);
        }

        public Dictionary<string, TagBlinkLite> sendTagBlinks()
        {
            return lst_tags;
        }


    }
}
