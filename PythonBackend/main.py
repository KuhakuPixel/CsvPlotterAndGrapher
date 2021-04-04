from flask_restful import Resource, Api,reqparse
from flask import Flask, request
import pandas as pd
import numpy as np
import json
app = Flask(__name__)
api = Api(app)
print("test")



#creating argument parser
parser = reqparse.RequestParser()
parser.add_argument('csvFilePath',type=str)
csvFilesPathDictionary= {}
class CsvReader(Resource):



    def get(self,pathID):
        #reading csv

        print(csvFilesPathDictionary[pathID])
        print(type(csvFilesPathDictionary[pathID])==str)
        DataFrame=pd.read_csv(csvFilesPathDictionary[pathID])

        columns=np.array(DataFrame.columns)
        print(columns)
        columnsJSON=json.dumps(columns.tolist())
        return {pathID:columnsJSON}


    def put(self,pathID):
        #reading argument and put it into a dictionary
        arguments=parser.parse_args()
        csvFilesPathDictionary[pathID]=arguments["csvFilePath"]

        return {pathID:csvFilesPathDictionary[pathID]}

#api resource routing
api.add_resource(CsvReader, '/CsvReader/<string:pathID>')

if __name__ == '__main__':
    app.run(debug=True)