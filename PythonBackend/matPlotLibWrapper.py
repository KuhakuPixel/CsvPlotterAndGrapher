import matplotlib.pyplot as plt
class MatPlotLibWrapper:
    @staticmethod
    def decorate_axes(ax:plt.axes, plotName: str = "", xLabel: str = "", yLabel: str = "",
                  plotNameColor: str = "black", xAxisColorLabel: str = "black",
                  yAxisColorLabel: str = "black", bottomSpineColor: str = "black", topSpineColor: str = "black",
                  leftSpineColor: str = "black", rightSpineColor: str = "black")->plt.axes:
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
        return ax