using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace CsvPlotterAndGrapher
{
    public partial class ShowPlotForm : Form
    {
        
        public ShowPlotForm(Bitmap image)
        {
            InitializeComponent();
            //initialize image to PictureBox
            this.pbPlotPreviewer.Image = image;
        }

        private void ShowPlotForm_Load(object sender, EventArgs e)
        {

        }

        //save image
        private void btnDownload_Click(object sender, EventArgs e)
        {
            //open folder path to save file

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //get file extension that is specified by the user
                    string fileExtension = Path.GetExtension(saveFileDialog.FileName);
                    switch (fileExtension)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                    }
                    pbPlotPreviewer.Image.Save(saveFileDialog.FileName, format);
                }
            }
           
           


        }
    }
}
