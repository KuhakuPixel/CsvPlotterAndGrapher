import json

import numpy as np
import pandas as pd
from flask import Flask
from flask_restful import Resource, Api, reqparse

from CsvPlotter import CsvPlotter
from ApiEndpointConfigurations import ApiEndpointConfigurations
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
columnToHistogramArgumentParser.add_argument('columnName', type=str,help="the column that will be plotted as histogram")
columnToHistogramArgumentParser.add_argument('plotName', type=str,default="",required=False,help="The name of th plot")
columnToHistogramArgumentParser.add_argument('xLabel', type=str,default="",required=False,help="The label of the x axes")
columnToHistogramArgumentParser.add_argument('yLabel', type=str,default="",required=False,help="The label of the y axes")
class ColumnToHistogram(Resource):

    def get(self, plot_id):
        #getting request's argument
        arguments = UserData.temporaryArgumentDictionary[plot_id]
        column_name = arguments["columnName"]
        plotName=arguments["plotName"]
        xLabel=arguments["xLabel"]
        yLabel=arguments["yLabel"]
        #get the plot in array of rgb
        x = UserData.dataFrame[column_name]
        image_in_numpy_array = CsvPlotter.histogram(x=x, plotName=plotName,xLabel=xLabel,yLabel=yLabel)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.histogramImageData_key: img_json, ApiEndpointConfigurations.histogramImageShape_key: img_shape_json}

    def put(self, plot_id):
        # reading argument and put it into a dictionary
        arguments = columnToHistogramArgumentParser.parse_args()

        UserData.temporaryArgumentDictionary[plot_id] = arguments
        print("put request")
        return {plot_id: arguments["columnName"]}


# api resource routing
api.add_resource(CsvReader, '/CsvReader/<string:path_id>')
api.add_resource(ColumnToHistogram, '/Plotter/ColumnToHistogram/<string:plot_id>')

if __name__ == '__main__':
    app.run(debug=True)
