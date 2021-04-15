"""
Testing Script
testing from commandline:
put:
    curl http://localhost:5000/CsvReader/path1 -d "csvFilePath=C:/Users/Nicho/Desktop/Projects/CsvPlotterAndGrapher/csvTest.csv" -X PUT
get:
    curl http://localhost:5000/CsvReader/path1
"""
from flask import Flask, request
from requests import get,put



def read_csv():
    API_ENDPOINT = 'http://localhost:5000/CsvReader/path1'
    CSV_FILE_PATH = 'C:/Users/Nicho/Desktop/Projects/CsvPlotterAndGrapher/csvTest.csv'

    put(API_ENDPOINT, data={'csvFilePath': CSV_FILE_PATH})

    print(get('http://localhost:5000/CsvReader/path1').json())



def histogram_api():
    API_ENDPOINT = 'http://localhost:5000/Plotter/ColumnToHistogram/plot1'


    put(API_ENDPOINT, data={'columnName':"sepal length"})
    get(API_ENDPOINT)

read_csv()
histogram_api()