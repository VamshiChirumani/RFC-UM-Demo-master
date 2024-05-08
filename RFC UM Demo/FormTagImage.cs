using RFC_UM_Demo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RFC_UM_Demo
{
    public partial class FormTagImage : Form
    {
        public SqlConnection cn = new SqlConnection(Settings.Default.RFCUMConnectionString);
        private Form1 parentForm;
        public FormTagImage( PictureBox pictureBoxFromForm1, Form1 parentForm)
        {
            InitializeComponent();
            this.Text = pictureBoxFromForm1.Tag.ToString();
            txtTagId.Text = pictureBoxFromForm1.Tag.ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = pictureBoxFromForm1.Image;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            XCoordinate.Text = pictureBoxFromForm1.Location.X.ToString();
            YCoordinate.Text = pictureBoxFromForm1.Location.Y.ToString();

            this.parentForm = parentForm;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                byte[] bimage;
                if (txtFileName.Text == "")
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    ImageConverter converter = new ImageConverter();
                     bimage = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
                }
                else
                {
                    string image = txtFileName.Text;
                    FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
                    bimage = new byte[fs.Length];
                    fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                }
                

                // Check if the record exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Tags WHERE tagId = @tagId", cn);
                checkCmd.Parameters.AddWithValue("@tagId", SqlDbType.VarChar).Value = txtTagId.Text;
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    // Update the record
                    SqlCommand updateCmd = new SqlCommand("UPDATE Tags SET Image = @imgdata WHERE tagId = @tagId", cn);
                    updateCmd.Parameters.AddWithValue("@imgdata", SqlDbType.Image).Value = bimage;
                    updateCmd.Parameters.AddWithValue("@tagId", SqlDbType.VarChar).Value = txtTagId.Text;
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // Insert a new record
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO Tags (tagId, type, Image) VALUES (@tagId, @type, @imgdata)", cn);
                    insertCmd.Parameters.AddWithValue("@tagId", SqlDbType.VarChar).Value = txtTagId.Text;
                    insertCmd.Parameters.AddWithValue("@type", SqlDbType.Int).Value = 1;
                    insertCmd.Parameters.AddWithValue("@imgdata", SqlDbType.Image).Value = bimage;
                    insertCmd.ExecuteNonQuery();
                }

                cn.Close();
                parentForm.myPics[txtTagId.Text].pb.Image = Image.FromFile(txtFileName.Text);
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }
    }
}
