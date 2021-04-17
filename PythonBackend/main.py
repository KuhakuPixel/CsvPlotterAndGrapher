import json

import numpy as np
import pandas as pd
from flask import Flask
from flask_restful import Resource, Api, reqparse

from ApiEndpointConfigurations import ApiEndpointConfigurations
from CsvPlotter import CsvPlotter

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


columnToHistogramArgumentParser = reqparse.RequestParser()
columnToHistogramArgumentParser.add_argument('columnName', type=str,
                                             help="the column that will be plotted as histogram")
columnToHistogramArgumentParser.add_argument('barColor', type=str, default="blue", required=False,
                                             help="Color of the bar")
columnToHistogramArgumentParser.add_argument('plotName', type=str, default="", required=False,
                                             help="The name of the plot")
columnToHistogramArgumentParser.add_argument('plotNameColor', type=str, default="black", required=False,
                                             help="The color of the plot name")
columnToHistogramArgumentParser.add_argument('xLabel', type=str, default="black", required=False,
                                             help="The label of the x axes")
columnToHistogramArgumentParser.add_argument('xAxisLabelColor', type=str, default="", required=False,
                                             help="The label color of the x axes")
columnToHistogramArgumentParser.add_argument('yLabel', type=str, default="", required=False,
                                             help="The label of the y axes")
columnToHistogramArgumentParser.add_argument('yAxisLabelColor', type=str, default="black", required=False,
                                             help="The label color of the y axes")

columnToHistogramArgumentParser.add_argument('bottomSpineColor', type=str, default="black", required=False,
                                             help="The color of the plot 's bottom spine")
columnToHistogramArgumentParser.add_argument('topSpineColor', type=str, default="", required=False,
                                             help="The color of the plot 's top spine")
columnToHistogramArgumentParser.add_argument('leftSpineColor', type=str, default="", required=False,
                                             help="The color of the plot 's left spine")
columnToHistogramArgumentParser.add_argument('rightSpineColor', type=str, default="black", required=False,
                                             help="The color of the plot 's right spine")


class ColumnToHistogram(Resource):

    def get(self, plot_id):
        # getting request's argument
        arguments = UserData.temporaryArgumentDictionary[plot_id]
        column_name = arguments["columnName"]
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
        arguments = columnToHistogramArgumentParser.parse_args()

        UserData.temporaryArgumentDictionary[plot_id] = arguments
        print("put request")
        return 200


columnsToScatterPlotArgumentParser = reqparse.RequestParser()
columnsToScatterPlotArgumentParser.add_argument('xColumnName', type=str,
                                                help="the column that will be plotted on the x axis of the plot")

columnsToScatterPlotArgumentParser.add_argument('yColumnName', type=str,
                                                help="the column that will be plotted on the y axis of the plot")
columnsToScatterPlotArgumentParser.add_argument('plotName', type=str, default="", required=False,
                                                help="The name of the plot")
columnsToScatterPlotArgumentParser.add_argument('dotColor', type=str, default="blue", required=False,
                                                help="The color of the dot")
columnsToScatterPlotArgumentParser.add_argument('plotNameColor', type=str, default="black", required=False,
                                                help="The color of the plot name")
columnsToScatterPlotArgumentParser.add_argument('xLabel', type=str, default="black", required=False,
                                                help="The label of the x axes")
columnsToScatterPlotArgumentParser.add_argument('xAxisLabelColor', type=str, default="", required=False,
                                                help="The label color of the x axes")
columnsToScatterPlotArgumentParser.add_argument('yLabel', type=str, default="", required=False,
                                                help="The label of the y axes")
columnsToScatterPlotArgumentParser.add_argument('yAxisLabelColor', type=str, default="black", required=False,
                                                help="The label color of the y axes")

columnsToScatterPlotArgumentParser.add_argument('bottomSpineColor', type=str, default="black", required=False,
                                                help="The color of the plot 's bottom spine")
columnsToScatterPlotArgumentParser.add_argument('topSpineColor', type=str, default="", required=False,
                                                help="The color of the plot 's top spine")
columnsToScatterPlotArgumentParser.add_argument('leftSpineColor', type=str, default="", required=False,
                                                help="The color of the plot 's left spine")
columnsToScatterPlotArgumentParser.add_argument('rightSpineColor', type=str, default="black", required=False,
                                                help="The color of the plot 's right spine")


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
        arguments = columnsToScatterPlotArgumentParser.parse_args()

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
