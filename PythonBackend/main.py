

import numpy as np
import pandas as pd
from flask import Flask
from flask_restful import Resource, Api, reqparse

from ApiEndpointConfigurations import ApiEndpointConfigurations
from MyPlotter import Plotter
from Wrapper import PlotAttributesAndParser
import json
from UserData import UserData
"""
containing the data such as dataframe,columns or ect
"""





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


histogram_attributes_parser = PlotAttributesAndParser.HistogramPlotAttributesAndParser()


class ColumnToHistogram(Resource):

    def get(self, plot_id):

        image_in_numpy_array = Plotter.histogram(attributes=histogram_attributes_parser)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self, plot_id):
        # reading argument and put it into a dictionary
        histogram_attributes_parser.initialize_args()


        return 200


scatter_attributes_parser = PlotAttributesAndParser.ScatterPlotAttributesAndParser()


class ColumnsToScatterPlot(Resource):

    def get(self, plot_id):

        image_in_numpy_array = Plotter.scatter(attributes=scatter_attributes_parser)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self, plot_id):
        scatter_attributes_parser.initialize_args()
        return 200


# api resource routing
api.add_resource(CsvReader, '/CsvReader/<string:path_id>')
api.add_resource(ColumnToHistogram, '/Plotter/ColumnToHistogram/<string:plot_id>')
api.add_resource(ColumnsToScatterPlot, '/Plotter/ColumnsToScatterPlot/<string:plot_id>')

if __name__ == '__main__':
    # assing False if ready to turn to exe
    app.run(debug=True)
