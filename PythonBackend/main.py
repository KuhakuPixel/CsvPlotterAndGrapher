import json

import numpy as np
import pandas as pd
from flask import Flask
from flask_restful import Resource, Api, reqparse

from CsvPlotter import CsvPlotter

"""
containing the data such as dataframe,columns or ect
"""


class UserData:
    dataFrame = pd.DataFrame(columns=['A', 'B', 'C'], index=range(5))
    # <string:object>
    csvFilesPathDictionary = {}
    columnNametoBePlottedDictionary = {}


app = Flask(__name__)
api = Api(app)

# creating argument parser

csvReaderArgumentParser = reqparse.RequestParser()
csvReaderArgumentParser.add_argument('csvFilePath', type=str)


class CsvReader(Resource):

    def get(self, path_id):
        # reading csv

        UserData.dataFrame = pd.read_csv(UserData.csvFilesPathDictionary[path_id])

        columns = np.array(UserData.dataFrame.columns)
        print(columns)
        columns_json = json.dumps(columns.tolist())
        return {path_id: columns_json}

    def put(self, path_id):
        # reading argument and put it into a dictionary
        arguments = csvReaderArgumentParser.parse_args()
        UserData.csvFilesPathDictionary[path_id] = arguments["csvFilePath"]
        return {path_id: UserData.csvFilesPathDictionary[path_id]}


columnToHistogramArgumentParser = reqparse.RequestParser()
columnToHistogramArgumentParser.add_argument('columnName', type=str)
class ColumnToHistogram(Resource):

    def get(self, plot_id):
        column_name = UserData.columnNametoBePlottedDictionary[plot_id]
        x = UserData.dataFrame[column_name]
        image_in_numpy_array = CsvPlotter.histogram(x=x)

        # dimension of the array
        img_shape = image_in_numpy_array.shape
        img_shape_json = json.dumps(img_shape)

        img_json = json.dumps(image_in_numpy_array.tolist())

        return {plot_id: img_json, "img_shape": img_shape_json}

    def put(self, plot_id):
        # reading argument and put it into a dictionary
        arguments = columnToHistogramArgumentParser.parse_args()
        UserData.columnNametoBePlottedDictionary[plot_id] = arguments["columnName"]
        return {plot_id: UserData.columnNametoBePlottedDictionary[plot_id]}


# api resource routing
api.add_resource(CsvReader, '/CsvReader/<string:path_id>')
api.add_resource(ColumnToHistogram, '/Plotter/ColumnToHistogram/<string:plot_id>')

if __name__ == '__main__':
    app.run(debug=True)
