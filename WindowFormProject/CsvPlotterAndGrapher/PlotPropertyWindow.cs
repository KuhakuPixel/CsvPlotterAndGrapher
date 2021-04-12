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
    }
}
