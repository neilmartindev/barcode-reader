using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronBarCode;

namespace Barcode_Scanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create an object to choose image extensions of jpg and png
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "JPG|*.jpg|PNG|*.png" })
            {
                // if an image has been selected then
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName); // put the image in the picture box on screen
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize; // change the size of the picturebox to auto
                    BarcodeResult result = BarcodeReader.QuicklyReadOneBarcode(pictureBox1.Image, BarcodeEncoding.QRCode
                        | BarcodeEncoding.Code128, true);

                    if (result != null)
                        textBox1.Text = result.ToString(); // put the result of the barcode in the textbox
                }
            }
        }
    }
}
