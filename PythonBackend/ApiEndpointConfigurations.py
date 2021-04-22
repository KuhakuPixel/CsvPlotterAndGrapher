class ApiEndpointConfigurations:
    csvReaderApiEndPoint = "http://localhost:5000/CsvReader/path1"
    csvColumn_key = "csvColumns"

    histogramPlotterApiEndPoint = "http://localhost:5000/Plotter/ColumnToHistogram/HistogramPlot"
    scatterPlotterApiEndPoint="http://localhost:5000/Plotter/ColumnsToScatterPlot/ScatterPlot"
    lineOrMarkPlotterApiEndPoint="http://localhost:5000/Plotter/ColumnsToLineOrMarkerPlot/LineOrMarkerPlot"


    plotImageData_key = "plot_data"
    plotImageShape_key = "img_shape"