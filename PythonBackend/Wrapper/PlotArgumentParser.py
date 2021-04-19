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
    parse_args_has_been_called=False
    arguments = {}
    def __init__ (self):
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
        self.parse_args_has_been_called=True
        pass

    """
    Functions to get all of the arguments from the request (explicitly)
    """
    def get_bar_color(self)->str:
        if(self.parse_args_has_been_called):
            return self.arguments['barColor']
        else:
            
        pass
    pass
