import json

import numpy as np
import pandas as pd
from flask import Flask
from flask_restful import Resource, Api, reqparse

from ApiEndpointConfigurations import ApiEndpointConfigurations
from CsvPlotter import CsvPlotter
from Wrapper import PlotArgumentParser
"""
containing the data such as dataframe,columns or ect
"""


class UserData:
    dataFrame = pd.DataFrame(columns=['A', 'B', 'C'], index=range(5))
    # <string:object>

    temporaryArgumentDictionary = {}


app = Flask(__name__)
api = Api(app)

# creating argument parser

csvReaderArgumentParser = reqparse.RequestParser()
csvReaderArgumentParser.add_argument('csvFilePath', type=str)


class CsvReader(Resource):

    def get(self, path_id):
        # reading csv
        arguments = UserData.temporaryArgumentDictionary[path_id]
        UserData.dataFrame = pd.read_csv(arguments["csvFilePath"])

        columns = np.array(UserData.dataFrame.columns)
        print(columns)
        columns_json = json.dumps(columns.tolist())
        return {ApiEndpointConfigurations.csvColumn_key: columns_json}

    def put(self, path_id):
        # reading argument and put it into a dictionary
        UserData.temporaryArgumentDictionary[path_id] = csvReaderArgumentParser.parse_args()

        print("put request")
        return {"Csv Path": UserData.temporaryArgumentDictionary[path_id]["csvFilePath"]}


histogram_argument_parser = PlotArgumentParser.HistogramPlotRequestParser()
class ColumnToHistogram(Resource):

    def get(self, plot_id):
        # getting request's argument
        arguments = UserData.temporaryArgumentDictionary[plot_id]

        column_name = arguments["xColumnName"]
        plotName = arguments["plotName"]
        xLabel = arguments["xLabel"]
        yLabel = arguments["yLabel"]
        #
        barColor=arguments["barColor"]
        plotNameColor = arguments["plotNameColor"]
        xAxisLabelColor = arguments["xAxisLabelColor"]
        yAxisLabelColor = arguments["yAxisLabelColor"]
        bottomSpineColor = arguments["bottomSpineColor"]
        topSpineColor = arguments["topSpineColor"]
        leftSpineColor = arguments["leftSpineColor"]
        rightSpineColor = arguments["rightSpineColor"]

        # get the plot in array of rgb
        x = UserData.dataFrame[column_name]
        image_in_numpy_array = CsvPlotter.histogram(x=x,barColor=barColor, plotName=plotName, xLabel=xLabel, yLabel=yLabel,
                                                    plotNameColor=plotNameColor, xAxisColorLabel=xAxisLabelColor,
                                                    yAxisColorLabel=yAxisLabelColor, bottomSpineColor=bottomSpineColor,
                                                    topSpineColor=topSpineColor, rightSpineColor=rightSpineColor,
                                                    leftSpineColor=leftSpineColor)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self, plot_id):
        # reading argument and put it into a dictionary
        arguments = histogram_argument_parser.parse_args()

        UserData.temporaryArgumentDictionary[plot_id] = arguments
        print("put request")
        return 200


scatter_argument_parser = PlotArgumentParser.ScatterPlotRequestParser()



class ColumnsToScatterPlot(Resource):

    def get(self, plot_id):
        # getting request's argument
        arguments = UserData.temporaryArgumentDictionary[plot_id]

        x_column_name = arguments["xColumnName"]
        y_column_name = arguments["yColumnName"]
        plotName = arguments["plotName"]
        xLabel = arguments["xLabel"]
        yLabel = arguments["yLabel"]
        #
        dotColor=arguments["dotColor"]
        plotNameColor = arguments["plotNameColor"]
        xAxisLabelColor = arguments["xAxisLabelColor"]
        yAxisLabelColor = arguments["yAxisLabelColor"]
        bottomSpineColor = arguments["bottomSpineColor"]
        topSpineColor = arguments["topSpineColor"]
        leftSpineColor = arguments["leftSpineColor"]
        rightSpineColor = arguments["rightSpineColor"]

        # get the plot in array of rgb
        x = UserData.dataFrame[x_column_name]
        y = UserData.dataFrame[y_column_name]
        image_in_numpy_array = CsvPlotter.scatter(x=x,dotColor=dotColor,y=y, plotName=plotName, xLabel=xLabel, yLabel=yLabel,
                                                  plotNameColor=plotNameColor, xAxisColorLabel=xAxisLabelColor,
                                                  yAxisColorLabel=yAxisLabelColor, bottomSpineColor=bottomSpineColor,
                                                  topSpineColor=topSpineColor, rightSpineColor=rightSpineColor,
                                                  leftSpineColor=leftSpineColor)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self, plot_id):
        # reading argument and put it into a dictionary
        arguments = scatter_argument_parser.parse_args()

        UserData.temporaryArgumentDictionary[plot_id] = arguments
        print("put request")
        return 200


# api resource routing
api.add_resource(CsvReader, '/CsvReader/<string:path_id>')
api.add_resource(ColumnToHistogram, '/Plotter/ColumnToHistogram/<string:plot_id>')
api.add_resource(ColumnsToScatterPlot, '/Plotter/ColumnsToScatterPlot/<string:plot_id>')

if __name__ == '__main__':
    #assing False if ready to turn to exe
    app.run(debug=True)
