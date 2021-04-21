import json

from flask_restful import reqparse

from ColorsCollection import ColorCollection


class PlotAttributesAndParser:
    """
    This Class is used as a wrapper for  [flask_restful.reqparse.RequestParser()] and
    will be the base class and  be used to parse the arguments for different kind of plot

    The purpose is to have all of the other class their own implementation of  [flask_restful.reqparse.RequestParser()]
    according to the plot type ,anticipating changes and increase usability

    The instance of the class that is derived from this  will be used as an argument to draw the plot (struct alternative)

    """

    arguments = {}

    # plot properties
    plotName = ""
    xLabel = ""
    yLabel = ""
    # color

    plotNameColor = ()
    xAxisLabelColor = ()
    yAxisLabelColor = ()

    bottomSpineColor = ()
    topSpineColor = ()
    leftSpineColor = ()
    rightSpineColor = ()

    figureBackgroundColor = ColorCollection.white
    axesBackgroundColor = ColorCollection.white

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

        self.argumentParser.add_argument('figureBackgroundColor', type=str, default=ColorCollection.white,
                                         required=False,
                                         help="")
        self.argumentParser.add_argument('axesBackgroundColor', type=str, default=ColorCollection.white, required=False,
                                         help="")

    def initialize_args(self):
        """
        Parse all arguments from the provided request And initialize the object
        """
        self.arguments = self.argumentParser.parse_args()

        self.plotName = self.arguments["plotName"]
        self.xLabel = self.arguments["xLabel"]
        self.yLabel = self.arguments["yLabel"]

        # convert array in json format(representing color) to tuple

        self.plotNameColor = tuple(json.loads(self.arguments["plotNameColor"]))
        self.xAxisLabelColor = tuple(json.loads(self.arguments["xAxisLabelColor"]))
        self.yAxisLabelColor = tuple(json.loads(self.arguments["yAxisLabelColor"]))
        self.bottomSpineColor = tuple(json.loads(self.arguments["bottomSpineColor"]))
        self.topSpineColor = tuple(json.loads(self.arguments["topSpineColor"]))
        self.leftSpineColor = tuple(json.loads(self.arguments["leftSpineColor"]))
        self.rightSpineColor = tuple(json.loads(self.arguments["rightSpineColor"]))

        # bg color
        self.figureBackgroundColor = tuple(json.loads(self.arguments["figureBackgroundColor"]))
        self.axesBackgroundColor = tuple(json.loads(self.arguments["axesBackgroundColor"]))


"""
note: super().__init__() will call the base constructor to initialize argumentParser
"""


class HistogramPlotAttributesAndParser(PlotAttributesAndParser):
    xColumnName = ""
    barColor = ColorCollection.blue

    def __init__(self):
        super().__init__()
        self.argumentParser.add_argument('xColumnName', type=str,
                                         help="the column that will be plotted on the x axis of the plot")
        self.argumentParser.add_argument('barColor', type=str, default=ColorCollection.blue, required=False,
                                         help="Color of the bar")

    def initialize_args(self):
        super().initialize_args()
        self.xColumnName = self.arguments["xColumnName"]
        self.barColor = tuple(json.loads(self.arguments["barColor"]))


class ScatterPlotAttributesAndParser(PlotAttributesAndParser):
    xColumnName = ""
    yColumnName = ""
    dotColor = ColorCollection.blue

    def __init__(self):
        super().__init__()
        self.argumentParser.add_argument('xColumnName', type=str,
                                         help="the column that will be plotted on the x axis of the plot")
        self.argumentParser.add_argument('yColumnName', type=str,
                                         help="the column that will be plotted on the y axis of the plot")
        self.argumentParser.add_argument('dotColor', type=str, default=ColorCollection.blue, required=False,
                                         help="Color of the dot")

    def initialize_args(self):
        super().initialize_args()
        self.xColumnName = self.arguments["xColumnName"]
        self.xColumnName = self.arguments["yColumnName"]
        self.dotColor = tuple(json.loads(self.arguments["dotColor"]))

    pass
