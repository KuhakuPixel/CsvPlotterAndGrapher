using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    public static class ApiEndpointConfigurations
    {
        #region Csv Reader configuration
        public static readonly string csvReaderApiEndPoint = "http://localhost:5000/CsvReader/path1";
        public static readonly string csvColumn_key = "csvColumns";
        #endregion


        #region Histogram Plotter Configuration
        public static readonly string histogramPlotterApiEndPoint = "http://localhost:5000/Plotter/ColumnToHistogram/HistogramPlot";

        #endregion

        #region Scatter Plotter Configuration
        public static readonly string scatterPlotterApiEndPoint = "http://localhost:5000/Plotter/ColumnsToScatterPlot/ScatterPlot";
        #endregion


        public static readonly string plotImageData_key = "plot_data";
        public static readonly string plotImageShape_key = "img_shape";
    }
}
