using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ApiLibrary;
using ProjectLibrary;
namespace CsvPlotterAndGrapher
{
    public partial class Form1 : Form
    {
        String csvPath = "";
      
        public Form1()
        {
            InitializeComponent();

        }

        private async void OpenFileButtonClick(object sender, EventArgs e)
        {
            //initialize OpenfileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Opening csv file";
            openFileDialog.Filter = "CSV files|*.csv";
            openFileDialog.InitialDirectory = @"C:\";

            //open dialog to open a file 
            DialogResult dialogResult = openFileDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    this.csvPath = openFileDialog.FileName;

                    string[] columns = await CsvReader.GetCsvColumns(this.csvPath);
                    
                    
                    
                    //MessageBox.Show(text:string.Join(",",columns));
                    break;
            }
        }
    }
}
