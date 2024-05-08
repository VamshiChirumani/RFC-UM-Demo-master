using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using RFC_UM_Demo.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace RFC_UM_Demo
{
    public partial class Form1 : Form
    {
        //List<PictureBox> myPics = new List<PictureBox>();
        public Dictionary<string, PictureboxLocation> myPics = new Dictionary<string, PictureboxLocation>();
        Dictionary<string, Point> tagLocations = new Dictionary<string, Point>();
        List<TagBlinkLite> tags = new List<TagBlinkLite>();
        StompHelper stompHelper = new StompHelper();
        bool dragging;
        int xoffset;
        int yoffset;

        public SqlConnection cn = new SqlConnection(Settings.Default.RFCUMConnectionString);
      
        public Form1()
        {
            InitializeComponent();
            dragging = false;
            stompHelper.ListUpdated += PictureLocationAssignerLite;
            //pbHeatMap.Visible = false;
            //this.Move += Form1_Move;
        }
        private void Form1_Move(object sender, EventArgs e)
        {
            // Check if the form's current screen has changed
            Screen currentScreen = Screen.FromControl(this);
            if (!currentScreen.Equals(lastScreen))
            {
                lastScreen = currentScreen; // Update the last known screen
                AdjustFormToScreen(currentScreen); // Adjust the form to fit the new screen
            }
        }

        private Screen lastScreen; // Store the last known screen

        private void AdjustFormToScreen(Screen screen)
        {
            // Set the form's position and size to fit the screen's working area
            this.Location = screen.WorkingArea.Location;
            this.WindowState = FormWindowState.Maximized;


            this.Size = screen.WorkingArea.Size;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            /*   You will have to scale the pixels to the overall size of the room.
             *   Room is 85.75 feet long (across in form) by 44.6 feet tall (height in form)
             *   Position origin from RFC software is upper left corner and pixel locations are.
             *   from the same upper left corner.
             */
            // Set the Timer control's interval to 30 seconds (30000 milliseconds)
            //timer1.Interval = 1000;

            //timer1.Enabled = true;

            //timer1.Tick += Timer1_Tick;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            cbSelectAll.Checked= false;
        }


        private void Pb_Click(object sender, EventArgs e)
        {

            PictureBox pb = (PictureBox)sender;
            FormTagImage imageTagForm = new FormTagImage(pb, this);
            imageTagForm.ShowDialog();
            
        }

        public void PictureLocationAssignerLite(Dictionary<string, TagBlinkLite> blinks, TagBlinkLite tbl)
        {
            Dictionary<string, TagBlinkLite> tagBlinks = blinks;
            tbl.x = Math.Round(tbl.x,0);
            tbl.y = Math.Round(tbl.y,0);
            tags.Add(tbl);
            tagLocations.Clear();
            foreach (var item in tagBlinks.Keys)
            {
                string text = tagBlinks[item].tagID.Substring(1, 2);

                if (cbSelectAll.Checked)
                {
                    tagLocations.Add(tagBlinks[item].tagID, CalcLocation(tagBlinks[item].x, tagBlinks[item].y));
                }
                else
                {
                    if (cbGIAI.Checked && tagBlinks[item].tagID.Length == 26 && tagBlinks[item].tagID.Substring(1, 2) == "34")
                    {
                        //if(LookForTag(item.tagID)==false)
                        tagLocations.Add(tagBlinks[item].tagID, CalcLocation(tagBlinks[item].x, tagBlinks[item].y));
                        //tagLocations.Add(item.tagID, new Point((int)item.location.x, (int)item.location.y));
                    }
                    if (cbGRAI.Checked && tagBlinks[item].tagID.Length == 26 && tagBlinks[item].tagID.Substring(1, 2) == "33")
                    {
                        //if(LookForTag(item.tagID)==false)
                        tagLocations.Add(tagBlinks[item].tagID, CalcLocation(tagBlinks[item].x, tagBlinks[item].y));
                        //tagLocations.Add(item.tagID, new Point((int)item.location.x, (int)item.location.y));
                    }
                    if (cbSGTIN.Checked && tagBlinks[item].tagID.Length == 26 && tagBlinks[item].tagID.Substring(1, 2) == "30")
                    {
                        //if(LookForTag(item.tagID)==false)
                        tagLocations.Add(tagBlinks[item].tagID, CalcLocation(tagBlinks[item].x, tagBlinks[item].y));
                        //tagLocations.Add(item.tagID, new Point((int)item.location.x, (int)item.location.y));
                    }
                    if (cbGDTI.Checked && tagBlinks[item].tagID.Length == 26 && tagBlinks[item].tagID.Substring(1, 2) == "2C")
                    {
                        //if(LookForTag(item.tagID)==false)
                        tagLocations.Add(tagBlinks[item].tagID, CalcLocation(tagBlinks[item].x, tagBlinks[item].y));
                        //tagLocations.Add(item.tagID, new Point((int)item.location.x, (int)item.location.y));
                    }
                    if (cbFilter.Text != "All Tags" && tagBlinks[item].tagID.Length == 26 && tagBlinks[item].tagID == cbFilter.Text)
                    {
                        //if(LookForTag(item.tagID)==false)
                        tagLocations.Add(tagBlinks[item].tagID, CalcLocation(tagBlinks[item].x, tagBlinks[item].y));
                        //tagLocations.Add(item.tagID, new Point((int)item.location.x, (int)item.location.y));
                    }

                }


                if (cbFilter.Items.Contains(tagBlinks[item].tagID) == false)
                { 
                    cbFilter.Items.Add(tagBlinks[item].tagID); 

                }

            }
            

            foreach (var item in tagLocations)
            {
                System.Drawing.Image image= UnidentifiedTag.Image;
                if (myPics.ContainsKey(item.Key))
                {
                    myPics[item.Key].Locate(item.Value, Convert.ToInt32(FrequencyAdjust.Value));
                    myPics[item.Key].pb.Visible = true;
                    
                }
                else
                {
                    cn.Open();
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Tags WHERE tagId = @tagId", cn);
                    checkCmd.Parameters.AddWithValue("@tagId", SqlDbType.VarChar).Value = item.Key;
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT image FROM tags WHERE tagID = @tagID", cn);
                        cmd.Parameters.AddWithValue("@tagId", SqlDbType.VarChar).Value = item.Key;
                        byte[] imageData = (byte[])cmd.ExecuteScalar();
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            image = System.Drawing.Image.FromStream(ms);
                        }
                        myPics.Add(item.Key, new PictureboxLocation(
                            new PictureBox()
                            {
                                Size = UnidentifiedTag.Size,
                                SizeMode = UnidentifiedTag.SizeMode,
                                Image = image,
                                Location = item.Value,
                                Tag = item.Key,
                                Visible = true
                            }
                        ));
                        

                    }
                    else
                    {
                        myPics.Add(item.Key, new PictureboxLocation(
                        new PictureBox()
                        {
                            Size = UnidentifiedTag.Size,
                            SizeMode = UnidentifiedTag.SizeMode,
                            Image = image,
                            Location = item.Value,
                            Tag = item.Key,
                            Visible = true
                        }
                        ));
                    }
                    cn.Close();

                }


            }
           
            foreach (var item in myPics.Values)
            {
                if (!this.Controls.Contains(item.pb))
                {
                    item.pb.Click += new EventHandler(Pb_Click);
                    this.Controls.Add(item.pb);
                }
            }
            foreach (var item in unknowntags)
            {
                this.Controls.Add(item);
            }
            
        }
        

        /// <summary>
        /// Converts X,Y locations in meters to a .NET point object, and assumes a 70x70 picture box size
        /// </summary>
        /// <param name="X">X location as meters</param>
        /// <param name="Y">Y location as meters</param>
        /// <returns>A point for use in placing a picture box</returns>
        public Point CalcLocation(double X, double Y)
        {
            Point result = new Point();

            int widthCalc = this.Size.Width;
            int lengthCalc = this.Size.Height;

            result.Y = Convert.ToInt32(X * 3 * (widthCalc/78));
            result.X = Convert.ToInt32(Y* 3.2 * (lengthCalc/56));

            return result;
        }

        

        private void ClearScreen_Click(object sender, EventArgs e)
        {
            //cbGIAI.Checked = false;
            //cbGRAI.Checked = false;
            //cbSGTIN.Checked = false;
            //cbGDTI.Checked = false;
            foreach (string item in myPics.Keys)
            {
                myPics[item].clearQueue();
                myPics[item].pb.Visible = false;
            }
        }

        
        private void PointsWithStomp_Click(object sender, EventArgs e)
        {
            
            stompHelper.GetTagblinkLite(sender, e);
            
        }

        

        private void Stomp_stop_Click(object sender, EventArgs e)
        {
            stompHelper.cmd_stop_Click(sender, e);
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAll.Checked)
            {
                cbGDTI.Checked = true;
                cbGIAI.Checked = true;
                cbGRAI.Checked = true;
                cbSGTIN.Checked = true;
            }
            else
            {
                cbGDTI.Checked = false;
                cbGIAI.Checked = false;
                cbGRAI.Checked = false;
                cbSGTIN.Checked = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel p;
            p = (Panel)sender;
            if(Control.ModifierKeys == Keys.Control)
            {
                dragging = true;
                xoffset = e.X;
                yoffset = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Panel p;

            int XMoved;
            int YMoved;

            int newPanelX;
            int newPanelY;

            p = (Panel)sender;
            if (dragging)
            {

                XMoved = e.Location.X - xoffset;
                YMoved = e.Location.Y - yoffset;


                newPanelX = p.Location.X + XMoved;
                newPanelY = p.Location.Y + YMoved;

                p.Location = new Point(newPanelX, newPanelY);
            }
        }

        private void btnToggleFilter_Click(object sender, EventArgs e)
        {
            if(btnToggleFilter.Text == "<<")
            {
                panel1.Visible = true;
                btnToggleFilter.Text = ">>";
            }
            else
            {
                panel1.Visible = false;
                btnToggleFilter.Text = "<<";
            }
        }

        private void bgwHeatMap_DoWork(object sender, DoWorkEventArgs e)
        {

            List<TagBlinkLite> tagsNew = new List<TagBlinkLite>(tags);



            xoffset = (int)tagsNew.Max(x => x.x);
            yoffset = (int)tagsNew.Max(y => y.y);

            var pixelColor = tagsNew.GroupBy(x => new { x.x, x.y })
                .Select(x => new
                {
                    xPixel = x.Key.y,
                    yPixel = x.Key.x,
                    count = x.Count()
                });
            double countMax = pixelColor.Max(x => x.count);


            // Create a new bitmap for the heatmap
            Bitmap heatmapBitmap = new Bitmap((xoffset + 10) *20, (yoffset + 10 )* 20 );

            // Draw heatmap
            using (Graphics graphics = Graphics.FromImage(heatmapBitmap))
            using (SolidBrush brush = new SolidBrush(Color.Red)) // Example color (you can adjust based on signal strength)
            {
                foreach (var kvp in pixelColor)
                {
                    int x = (int)kvp.xPixel *20 ;
                    int y = (int)kvp.yPixel * 20;
                    double signalStrength = kvp.count/countMax;

                    // Map signal strength to color
                    Color color = MapSignalStrengthToColor(signalStrength);

                    // Fill rectangle with the corresponding color
                    brush.Color = color;
                    graphics.FillRectangle(brush, x, y, 20, 20);
                }
            }

            HeatMapForm hmf = new HeatMapForm(heatmapBitmap);
            hmf.ShowDialog();
            //pbHeatMap.Image = heatmapBitmap;

            /*foreach (var xyc in pixelColor)
            {
                ((Bitmap)pbHeatMap.Image).SetPixel((int)xyc.xPixel, (int)xyc.yPixel, MapSignalStrengthToColor(xyc.count/(countMax + 100)));
            }*/

        }

        static Color MapSignalStrengthToColor(double signalStrength)
        {
            // Example implementation: map signal strength to a gradient scale from blue to red
            int r = (int)(200 * (1 - signalStrength)); // Adjusted for lighter red
            int g = (int)(200 * (signalStrength)); // Adjusted for lighter green
            int b = (int)(200 * signalStrength); // Adjusted for lighter blue
            return Color.FromArgb(r, g, 0);
        }

        private void btnHeatmap_Click(object sender, EventArgs e)
        {
            
             bgwHeatMap.RunWorkerAsync();
            
        }
    }
}
