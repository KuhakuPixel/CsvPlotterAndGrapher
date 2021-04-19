

from flask_restful import reqparse
from ColorsCollection import ColorCollection

class PlotRequestParser:
    """
    This Class is used as a wrapper for  [flask_restful.reqparse.RequestParser()] and
    will be the base class and  be used to parse the arguments for different kind of plot

    The purpose is to have all of the other class their own implementation of  [flask_restful.reqparse.RequestParser()]
    according to the plot type ,anticipating changes and increase usability


    """



    def __init__(self):
        """
        Initialize all of the basic arguments that are required to create a plot
        """
        self.argumentParser = reqparse.RequestParser()


        self.argumentParser.add_argument('plotName', type=str, default="", required=False,
                                         help="The name of the plot")

        self.argumentParser.add_argument('xLabel', type=str, default="", required=False,
                                         help="The label of the x axes")

        self.argumentParser.add_argument('yLabel', type=str, default="", required=False,
                                         help="The label of the y axes")

        # color of plot
        self.argumentParser.add_argument('plotNameColor', type=str, default=ColorCollection.black, required=False,
                                         help="The color of the plot name")
        self.argumentParser.add_argument('xAxisLabelColor', type=str, default=ColorCollection.black, required=False,
                                         help="The label color of the x axes")
        self.argumentParser.add_argument('yAxisLabelColor', type=str, default=ColorCollection.black, required=False,
                                         help="The label color of the y axes")

        self.argumentParser.add_argument('bottomSpineColor', type=str, default=ColorCollection.black, required=False,
                                         help="The color of the plot 's bottom spine")
        self.argumentParser.add_argument('topSpineColor', type=str, default=ColorCollection.black, required=False,
                                         help="The color of the plot 's top spine")
        self.argumentParser.add_argument('leftSpineColor', type=str, default=ColorCollection.black, required=False,
                                         help="The color of the plot 's left  spine")
        self.argumentParser.add_argument('rightSpineColor', type=str, default=ColorCollection.black, required=False,
                                         help="The color of the plot 's right spine")

    def parse_args(self):
        """
        Parse all arguments from the provided request and return a dictionary from the result
        """
        return self.argumentParser.parse_args()

        pass




"""
note: super().__init__() will call the base constructor to initialize argumentParser
"""


class HistogramPlotRequestParser(PlotRequestParser):
    def __init__(self):
        super().__init__()
        self.argumentParser.add_argument('xColumnName', type=str,
                                         help="the column that will be plotted on the x axis of the plot")
        self.argumentParser.add_argument('barColor', type=str, default=ColorCollection.blue, required=False,
                                         help="Color of the bar")







class ScatterPlotRequestParser(PlotRequestParser):
    def __init__(self):
        super().__init__()
        self.argumentParser.add_argument('xColumnName', type=str,
                                         help="the column that will be plotted on the x axis of the plot")
        self.argumentParser.add_argument('yColumnName', type=str,
                                         help="the column that will be plotted on the y axis of the plot")
        self.argumentParser.add_argument('dotColor', type=str, default=ColorCollection.blue, required=False,
                                         help="Color of the dot")



    pass
