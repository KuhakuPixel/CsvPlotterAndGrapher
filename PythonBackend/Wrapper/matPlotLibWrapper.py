import matplotlib.pyplot as plt


from Wrapper.PlotAttributesAndParser import PlotAttributesAndParser

class MatPlotLibWrapper:

    @staticmethod
    def decorate_plot(fig : plt.figure, ax: plt.axes, attributes: PlotAttributesAndParser):
        """
        Decorate the passed [ax] anf [fig]  (ex: title color,axes spine color ,x label and ect)
        :param attributes: will be used to decorate an axes
        :param ax : an instance of pyplot.axes that will be decorated
        :param fig : an instance of pyplot.figure that will be decorated
        :return:
        """

        ax.set_title(label=attributes.plotName)
        ax.set_xlabel(xlabel=attributes.xLabel)
        ax.set_ylabel(ylabel=attributes.yLabel)
        # decorate plot's label
        ax.title.set_color(attributes.plotNameColor)
        ax.yaxis.label.set_color(attributes.yAxisLabelColor)
        ax.xaxis.label.set_color(attributes.xAxisLabelColor)

        # decorate plot's spine
        ax.spines['bottom'].set_color(attributes.bottomSpineColor)
        ax.spines['top'].set_color(attributes.topSpineColor)
        ax.spines['right'].set_color(attributes.rightSpineColor)
        ax.spines['left'].set_color(attributes.leftSpineColor)

        #decorate plot 's background
        ax.set_facecolor(attributes.axesBackgroundColor)
        fig.patch.set_facecolor(attributes.figureBackgroundColor)

        # decorate ticks
        ax.tick_params(axis='x', colors=attributes.xTickColor,which="both")
        ax.tick_params(axis='y', colors=attributes.yTickColor, which="both")
        pass
