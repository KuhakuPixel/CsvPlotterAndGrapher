using ProjectLibrary;
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
    public partial class PlotPropertyWindow : Form
    {
        private CsvPlotter.PlotTypes plotType;
        
        public PlotPropertyWindow(CsvPlotter.PlotTypes plotType)
        {
            this.plotType = plotType;
           
            InitializeComponent();
            InitializePlotPropertyGrid();

        }
        //initialize property grid
        private void InitializePlotPropertyGrid()
        {
            switch (this.plotType)
            {
                case CsvPlotter.PlotTypes.Histogram:
                    this.pgPlotProperty.SelectedObject = new HistogramAttributes();
                    break;
                case CsvPlotter.PlotTypes.Scatter:
                    this.pgPlotProperty.SelectedObject = new ScatterAttributes();
                    break;
            }
        }

        /// <summary>
        /// Start plotting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPlotGraph_Click(object sender, EventArgs e)
        {
            //draw respective plot
            string exceptionMessage="";
            switch (this.plotType)
            {
                case CsvPlotter.PlotTypes.Histogram:
                    HistogramAttributes attributes = this.pgPlotProperty.SelectedObject as HistogramAttributes;
                    if (attributes.ColumnsNamesAreValid(ref exceptionMessage))
                    {
                        Bitmap image=await CsvPlotter.CreateHistogram(attributes);
                        using (ShowPlotForm showPlotForm = new ShowPlotForm(image))
                        {
                            showPlotForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show(exceptionMessage, "Exception Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    break;
                case CsvPlotter.PlotTypes.Scatter:
                    this.pgPlotProperty.SelectedObject = new ScatterAttributes();
                    break;
            }
        }

        private void pgPlotProperty_Click(object sender, EventArgs e)
        {

        }
    }
}
