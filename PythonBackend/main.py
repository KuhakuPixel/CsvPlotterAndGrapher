from flask_restful import Resource, Api,reqparse
from flask import Flask, request
import pandas as pd
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
        #print(csvFilesPathDictionary)
        #print(type(csvFilesPathDictionary))
        #self.dataFrame = pd.read_csv(csvFilesPathDictionary)
        #return {"Column Name":self.dataframe.columns}
        return {pathID : csvFilesPathDictionary[pathID]}


    def put(self,pathID):
        #reading csv
        arguments=parser.parse_args()
        csvFilesPathDictionary[pathID]=arguments["csvFilePath"]

        return {pathID:csvFilesPathDictionary[pathID]}

#api resource routing
api.add_resource(CsvReader, '/CsvReader/<string:pathID>')

if __name__ == '__main__':
    app.run(debug=True)