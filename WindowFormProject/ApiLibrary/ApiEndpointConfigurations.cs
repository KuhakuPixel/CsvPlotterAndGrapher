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
        public static readonly string histogramImageData_key = "histogramPlot";
        public static readonly string histogramImageShape_key = "img_shape";
        #endregion


    }
}
