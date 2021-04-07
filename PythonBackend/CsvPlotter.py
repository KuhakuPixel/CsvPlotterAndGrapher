import matplotlib.pyplot as plt
import numpy as np
from matplotlib.backends.backend_agg import FigureCanvasAgg as FigureCanvas
from PIL import Image


class CsvPlotter:

    @staticmethod
    def array_to_img(img_array : np.ndarray):
        plt.imshow(img_array, interpolation='nearest')
        plt.show()

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
        return CsvPlotter.pyplotFigureToImageArray(figure=fig)
