import json

import numpy as np
import pandas as pd
from flask import Flask
from flask_restful import Resource, Api, reqparse

from ApiEndpointConfigurations import ApiEndpointConfigurations
from MyPlotter import Plotter
from UserData import UserData
from Wrapper import PlotAttributesAndParser

"""
containing the data such as dataframe,columns or ect
"""

app = Flask(__name__)
api = Api(app)

# creating argument parser

csvReaderArgumentParser = reqparse.RequestParser()
csvReaderArgumentParser.add_argument('csvFilePath', type=str)


class CsvReader(Resource):

    def get(self):
        # reading csv
        csvPath = UserData.csvPath
        UserData.dataFrame = pd.read_csv(csvPath)
        columns = np.array(UserData.dataFrame.columns)
        print(columns)
        columns_json = json.dumps(columns.tolist())
        return {ApiEndpointConfigurations.csvColumn_key: columns_json}

    def put(self):
        # reading argument and put it into a dictionary
        arguments = csvReaderArgumentParser.parse_args()
        UserData.csvPath = arguments["csvFilePath"]
        print("put request")
        return 200


histogram_attributes_parser = PlotAttributesAndParser.HistogramPlotAttributesAndParser()


class ColumnToHistogram(Resource):

    def get(self):
        image_in_numpy_array = Plotter.histogram(attributes=histogram_attributes_parser)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self):
        # reading argument and put it into a dictionary
        histogram_attributes_parser.initialize_args()

        return 200


scatter_attributes_parser = PlotAttributesAndParser.ScatterPlotAttributesAndParser()


class ColumnsToScatterPlot(Resource):

    def get(self):
        image_in_numpy_array = Plotter.scatter(attributes=scatter_attributes_parser)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self):
        scatter_attributes_parser.initialize_args()
        return 200


line_or_marker_plot_attributes_parser = PlotAttributesAndParser.LineOrMarkerPlotAttributesAndParser()


class ColumnsToLineOrMarkerPlot(Resource):

    def get(self):
        image_in_numpy_array = Plotter.line_or_marker(attributes=line_or_marker_plot_attributes_parser)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {ApiEndpointConfigurations.plotImageData_key: img_json,
                ApiEndpointConfigurations.plotImageShape_key: img_shape_json}

    def put(self):
        line_or_marker_plot_attributes_parser.initialize_args()
        return 200


# api resource routing
api.add_resource(CsvReader, '/CsvReader')
api.add_resource(ColumnToHistogram, '/Plotter/ColumnToHistogram')
api.add_resource(ColumnsToScatterPlot, '/Plotter/ColumnsToScatterPlot')
api.add_resource(ColumnsToLineOrMarkerPlot, '/Plotter/ColumnsToLineOrMarkerPlot')

if __name__ == '__main__':
    # assing False if ready to turn to exe
    app.run(debug=True)
