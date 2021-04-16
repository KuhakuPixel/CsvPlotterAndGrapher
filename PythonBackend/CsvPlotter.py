import matplotlib.pyplot as plt
import numpy as np
from matplotlib.backends.backend_agg import FigureCanvasAgg as FigureCanvas

# Turn interactive plotting off
# turn off Interactive Mode, and only call plt.show() when  ready to display the plots:
plt.ioff()


class CsvPlotter:
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
    def histogram(x: np.ndarray, plotName: str = "", xLabel: str = "", yLabel: str = "",
                  plotNameColor: str = "black", xAxisColorLabel: str = "black",
                  yAxisColorLabel: str = "black", bottomSpineColor: str = "black", topSpineColor: str = "black",
                  leftSpineColor: str = "black", rightSpineColor: str = "black") -> np.ndarray:
        """
           x is a numpy array
           return a numpy array of the graph
        """
        fig, ax = plt.subplots()
        ax.hist(x=x)
        ax.set_title(label=plotName)
        ax.set_xlabel(xlabel=xLabel)
        ax.set_ylabel(ylabel=yLabel)
        # decorate plot's label
        ax.title.set_color(plotNameColor)
        ax.yaxis.label.set_color(xAxisColorLabel)
        ax.xaxis.label.set_color(yAxisColorLabel)

        # decorate plot's spine
        ax.spines['bottom'].set_color(bottomSpineColor)
        ax.spines['top'].set_color(topSpineColor)
        ax.spines['right'].set_color(rightSpineColor)
        ax.spines['left'].set_color(leftSpineColor)
        return CsvPlotter.pyplot_figure_to_image_array(figure=fig)
