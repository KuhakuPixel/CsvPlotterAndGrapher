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
from CsvPlotter import CsvPlotter
from Converter import Converter
import numpy as np

def read_csv():
    API_ENDPOINT = 'http://localhost:5000/CsvReader/path1'
    CSV_FILE_PATH = 'C:/Users/Nicho/Desktop/Projects/CsvPlotterAndGrapher/csvTest.csv'

    put(API_ENDPOINT, data={'csvFilePath': CSV_FILE_PATH})

    print(get('http://localhost:5000/CsvReader/path1').json())


def histogramPlotApi():
    API_ENDPOINT = 'http://localhost:5000/Plotter/ColumnToHistogram/plot1'
    columnToBeHistogrammed = "sepal length"
    put(API_ENDPOINT, data={'columnName': columnToBeHistogrammed})
    response=get(API_ENDPOINT).json()

    #convert response in string to array
    img_array=Converter.convert_array_in_string_to_array(response["plot1"])
    img_shape=Converter.convert_array_in_string_to_array(response["img_shape"])

    #convert to numpy array
    img_array=np.array(img_array)
    img_array=img_array.reshape(tuple(img_shape))

    CsvPlotter.array_to_img(img_array)



read_csv()
histogramPlotApi()
