using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFC_UM_Demo
{
    public class PictureboxLocation
    {
        public PictureboxLocation(PictureBox pictureBox)
        {
            this.pb = pictureBox;
            this.timer.Enabled = true;
            this.timer.Start();
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick; 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            List<int> xCoordinates = q.Select(x => x.X).ToList();
            List<int> yCoordinates = q.Select(x => x.Y).ToList();
            if(q.Count> 0)
            {
                int xLocation = Convert.ToInt32(xCoordinates.Sum() / q.Count);
                int yLocation = Convert.ToInt32(yCoordinates.Sum() / q.Count);
                this.pb.Location = new Point(xLocation, yLocation);
            }
                
            
        }

        public PictureBox pb;
        private Queue<Point> q=new Queue<Point>();
        Timer timer = new Timer();

        public void Locate(Point p,int f)
        {
            if (q.Count > f)
            {
                for (int i = 0; i < f-q.Count; i++)
                {
                    q.Dequeue();
                }
            }
            else if (q.Count == f)
            {
                q.Dequeue();
                q.Enqueue(p);
               
            }
            else
            {
                q.Enqueue(p);
            }

            /*List<int> xCoordinates = q.Select(x => x.X).ToList();
            List<int> yCoordinates = q.Select(x => x.Y).ToList();

            int xLocation = Convert.ToInt32(xCoordinates.Sum() / q.Count);
            int yLocation = Convert.ToInt32(yCoordinates.Sum() / q.Count);
            this.pb.Location = new Point(xLocation, yLocation);*/
        }

        public void clearQueue()
        {
            this.q.Clear();
        }
    }
}
