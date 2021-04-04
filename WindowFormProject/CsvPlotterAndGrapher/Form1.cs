using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ApiLibrary;
using ProjectLibrary;
namespace CsvPlotterAndGrapher
{
    public partial class Form1 : Form
    {
        String csvPath = "";
        static string apiURL = "http://localhost:5000/CsvReader/path1";
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

            //open dialog to open a file and return its result
            DialogResult dialogResult = openFileDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    this.csvPath = openFileDialog.FileName;
                    //await FlaskApi.PutRequest(apiURL, new KeyValuePair<string, string>("csvFilePath", this.csvPath));

                    //string response= await FlaskApi.GetRequest(apiURL);
                    await CsvReader.GetCsvColumns(this.csvPath);
                    //MessageBox.Show(text:response);
                    break;
            }
        }
    }
}
