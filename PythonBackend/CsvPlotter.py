import matplotlib.pyplot as plt
import numpy as np
from matplotlib.backends.backend_agg import FigureCanvasAgg as FigureCanvas


class CsvPlotter:
    @staticmethod
    def pyplotFigureToImageArray(figure):
        """
           turn pyplot.figure to an image in array format
        """
        canvas = FigureCanvas(figure)
        # draw the canvas, cache the renderer
        canvas.draw()

        width, height = figure.get_size_inches() * figure.get_dpi()
        img = np.frombuffer(canvas.tostring_rgb(), dtype='uint8').reshape(int(height), int(width), 3)
        return img

    @staticmethod
    def histogram(x: np.ndarray) -> np.ndarray:
        """
           x is a numpy array
           return a numpy array of the graph
        """
        fig, ax = plt.subplots()
        ax.hist(x=x)
        #show fig(figure)
        plt.show()
        return CsvPlotter.pyplotFigureToImageArray(figure=fig)
