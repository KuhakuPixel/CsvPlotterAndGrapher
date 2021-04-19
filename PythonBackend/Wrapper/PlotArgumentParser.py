import warnings

from flask_restful import reqparse


class PlotRequestParser:
    """
    This Class is used as a wrapper for  [flask_restful.reqparse.RequestParser()] and
    will be the base class and  be used to parse the arguments for different kind of plot

    The purpose is to have all of the other class their own implementation of  [flask_restful.reqparse.RequestParser()]
    according to the plot type ,anticipating changes and increase usability

    It also contains Functions to get all of the arguments from the request (explicitly) to avoid "KeyError Exceptions"
    And the caller will be able to expect what arguments is available
    """
    parse_args_has_been_called = False
    arguments = {}

    def __init__(self):
        """
        Initialize all of the basic arguments that are required to create a plot
        """
        self.argumentParser = reqparse.RequestParser()

        self.argumentParser.add_argument('barColor', type=str, default="blue", required=False,
                                         help="Color of the bar")
        self.argumentParser.add_argument('plotName', type=str, default="", required=False,
                                         help="The name of the plot")
        self.argumentParser.add_argument('plotNameColor', type=str, default="black", required=False,
                                         help="The color of the plot name")
        self.argumentParser.add_argument('xLabel', type=str, default="black", required=False,
                                         help="The label of the x axes")
        self.argumentParser.add_argument('xAxisLabelColor', type=str, default="", required=False,
                                         help="The label color of the x axes")
        self.argumentParser.add_argument('yLabel', type=str, default="", required=False,
                                         help="The label of the y axes")
        self.argumentParser.add_argument('yAxisLabelColor', type=str, default="black", required=False,
                                         help="The label color of the y axes")

        self.argumentParser.add_argument('bottomSpineColor', type=str, default="black", required=False,
                                         help="The color of the plot 's bottom spine")
        self.argumentParser.add_argument('topSpineColor', type=str, default="", required=False,
                                         help="The color of the plot 's top spine")
        self.argumentParser.add_argument('leftSpineColor', type=str, default="", required=False,
                                         help="The color of the plot 's left  spine")
        self.argumentParser.add_argument('rightSpineColor', type=str, default="black", required=False,
                                         help="The color of the plot 's right spine")

    def parse_args(self):
        """
        Parse all arguments from the provided request and return a dictionary from the result
        """
        self.arguments = self.argumentParser.parse_args()
        self.parse_args_has_been_called = True
        pass

    def raise_parse_args_warning(self):
        warnings.warn("parse_args hasn't been called call parse_args first before getting the argument")

    def get_bar_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['barColor']
        else:
            self.raise_parse_args_warning()

    def get_plot_name(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['plotName']
        else:
            self.raise_parse_args_warning()

    def get_plot_name_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['plotNameColor']
        else:
            self.raise_parse_args_warning()

    def get_x_label(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['xLabel']
        else:
            self.raise_parse_args_warning()

    def get_x_axis_label_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['xAxisLabelColor']
        else:
            self.raise_parse_args_warning()

    def get_y_label(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['yLabel']
        else:
            self.raise_parse_args_warning()

    def get_y_axis_label_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['yAxisLabelColor']
        else:
            self.raise_parse_args_warning()

    def get_bottom_spine_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['bottomSpineColor']
        else:
            self.raise_parse_args_warning()

    def get_top_spine_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['topSpineColor']
        else:
            self.raise_parse_args_warning()

    def get_left_spine_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['leftSpineColor']
        else:
            self.raise_parse_args_warning()

    def get_right_spine_color(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['rightSpineColor']
        else:
            self.raise_parse_args_warning()

    pass


"""
note: super().__init__() will call the base constructor to initialize argumentParser
"""


class HistogramPlotRequestParser(PlotRequestParser):
    def __init__(self):
        super().__init__()
        self.argumentParser.add_argument('xColumnName', type=str,
                                         help="the column that will be plotted on the x axis of the plot")

    def get_x_column_name(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['xColumnName']
        else:
            self.raise_parse_args_warning()

    pass


class ScatterPlotRequestParser(PlotRequestParser):
    def __init__(self):
        super().__init__()
        self.argumentParser.add_argument('xColumnName', type=str,
                                         help="the column that will be plotted on the x axis of the plot")
        self.argumentParser.add_argument('yColumnName', type=str,
                                         help="the column that will be plotted on the y axis of the plot")

    def get_x_column_name(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['xColumnName']
        else:
            self.raise_parse_args_warning()

    def get_y_column_name(self) -> str:
        if (self.parse_args_has_been_called):
            return self.arguments['yColumnName']
        else:
            self.raise_parse_args_warning()

    pass
