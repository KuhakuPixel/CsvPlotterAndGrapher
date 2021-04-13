using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ApiLibrary;
using ProjectLibrary;
namespace CsvPlotterAndGrapher
{
    public partial class MainForm : Form
    {
       
      
        public MainForm()
        {
            InitializeComponent();

        }

        private async void OpenFileButtonClick(object sender, EventArgs e)
        {
            //initialize OpenfileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Opening csv file";
            openFileDialog.Filter = "CSV files|*.csv";
           //openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.InitialDirectory = @"C:\Users\Nicho\Desktop\Projects\CsvPlotterAndGrapher";
            //open dialog to open a file 
            DialogResult dialogResult = openFileDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    string csvPath = openFileDialog.FileName;
                   
                    string[] columns = await CsvReader.GetCsvColumns(csvPath);
                    
                    
                    
                    //MessageBox.Show(text:string.Join(",",columns));
                    break;
            }
        }

        private void PlotTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void StartPlotBtn_Click(object sender, EventArgs e)
        {
            
            CsvPlotter.PlotTypes plotType=EnumConverter.ToEnum<CsvPlotter.PlotTypes>(cbPlotType.SelectedItem as string);

            
            using (PlotPropertyWindow plotPropertyWindow = new PlotPropertyWindow(plotType))
            {
                plotPropertyWindow.ShowDialog();
            }
              
        }
    }
}
