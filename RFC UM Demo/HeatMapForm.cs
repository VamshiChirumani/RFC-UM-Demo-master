using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFC_UM_Demo
{
    public partial class HeatMapForm : Form
    {
        public HeatMapForm(Bitmap heatmapBitmap)
        {
            InitializeComponent();
            pbHeatMap.Image = heatmapBitmap;
            //this.Height = Parent.Height;
        }
    }
}
