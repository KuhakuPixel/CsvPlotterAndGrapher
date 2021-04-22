import matplotlib.pyplot as plt
import numpy as np
from matplotlib.backends.backend_agg import FigureCanvasAgg as FigureCanvas

from UserData import UserData
from Wrapper.PlotAttributesAndParser import HistogramPlotAttributesAndParser
from Wrapper.PlotAttributesAndParser import LineOrMarkerPlotAttributesAndParser
from Wrapper.PlotAttributesAndParser import ScatterPlotAttributesAndParser
from Wrapper.matPlotLibWrapper import MatPlotLibWrapper

# Turn interactive plotting off
# turn off Interactive Mode, and only call plt.show() when  ready to display the plots:
plt.ioff()


class Plotter:
    @staticmethod
    def pyplot_figure_to_image_array(figure):
        """
           turn pyplot.figure to an image in array format
        """
        canvas = FigureCanvas(figure)
        # draw the canvas, cache the renderer
        canvas.draw()

        width, height = figure.get_size_inches() * figure.get_dpi()
        # convert to array
        img = np.frombuffer(canvas.tostring_rgb(), dtype='uint8').reshape(int(height), int(width), 3)
        return img

    @staticmethod
    def histogram(attributes: HistogramPlotAttributesAndParser) -> np.ndarray:
        """
           x is a numpy array
           return a numpy array of the graph
        """
        x = UserData.dataFrame[attributes.xColumnName]

        fig, ax = plt.subplots()
        ax.hist(x=x, color=attributes.barColor)
        MatPlotLibWrapper.decorate_plot(fig=fig, ax=ax, attributes=attributes)
        return Plotter.pyplot_figure_to_image_array(figure=fig)

    @staticmethod
    def scatter(attributes: ScatterPlotAttributesAndParser) -> np.ndarray:
        """
           x is a numpy array
           return a numpy array of the graph
        """
        x = UserData.dataFrame[attributes.xColumnName]
        y = UserData.dataFrame[attributes.yColumnName]

        fig, ax = plt.subplots()
        ax.scatter(x=x, y=y, color=attributes.dotColor)
        MatPlotLibWrapper.decorate_plot(fig=fig, ax=ax, attributes=attributes)
        return Plotter.pyplot_figure_to_image_array(figure=fig)

    @staticmethod
    def line_or_marker(attributes: LineOrMarkerPlotAttributesAndParser) -> np.ndarray:
        """
           x is a numpy array
           return a numpy array of the graph
        """
        x = UserData.dataFrame[attributes.xColumnName]
        y = UserData.dataFrame[attributes.yColumnName]

        fig, ax = plt.subplots()
        ax.plot(x, y, color=attributes.lineOrMarkerColor)
        MatPlotLibWrapper.decorate_plot(fig=fig, ax=ax, attributes=attributes)
        return Plotter.pyplot_figure_to_image_array(figure=fig)
