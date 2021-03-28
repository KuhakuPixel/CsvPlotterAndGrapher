using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvPlotterAndGrapher
{
    public partial class Form1 : Form
    {
        String csvPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileButtonClick(object sender, EventArgs e)
        {
            //initialize OpenfileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Opening csv file";
            openFileDialog.Filter = "CSV files|*.csv";
            openFileDialog.InitialDirectory = @"C:\";

            //open dialog and return its result
            DialogResult dialogResult = openFileDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    this.csvPath = openFileDialog.FileName;
                    MessageBox.Show(this.csvPath);
                    break;
            }
        }
    }
}
