using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace ProjectLibrary
{
    interface IPlotProperty
    {
        bool ColumnsNamesAreValid(ref string exceptionMessage);
    }
    /// <summary>
    /// This class or the other classess that derrive from this  will be instantiated by using [PropertyGrid].
    /// Class's properties will be displayed to be filled by the user.
    /// common property for plot like name,size,background color that are unrelated to the plot types
    /// </summary>
    public class PlotProperty
    {
        #region Category String
        public const string plotTextCategoryText="Plot Text (Optional)";
        public  const string plotColorCategoryText = "Plot Color(Optional)";
        public const string plotDataCategoryText = "Data (Mandatory)";
        #endregion
        private string plotName=" ";

        [Category(PlotProperty.plotTextCategoryText)]
        [DisplayName("Plot name")]
        [Description("Plot name will be displayed on top of the plot")]
        public string PlotName { get => plotName; set => plotName = value; }


        
        private CsvPlotter.ColorsCollection plotNameColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Plot Name Color")]
        [Description("The text color of plot name")]
        public CsvPlotter.ColorsCollection PlotNameColor { get => plotNameColor; set => plotNameColor = value; }
    }

    public class PlotProperty2d : PlotProperty
    {
        


        #region X Label
        private string xLabel=" ";
        [Category(PlotProperty.plotTextCategoryText)]
        [DisplayName("X Axes Label")]
        [Description("Label for the X axes")]
        public string XLabel { get => xLabel; set => xLabel = value; }

        private CsvPlotter.ColorsCollection xAxisLabelColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("X Axis Label Color")]
        [Description("The Color of the X axis label")]
        public CsvPlotter.ColorsCollection XAxisLabelColor { get => xAxisLabelColor; set => xAxisLabelColor = value; }
        #endregion

        #region YLabel
        private string yLabel=" ";
        [Category(PlotProperty.plotTextCategoryText)]
        [DisplayName("Y Axes Label")]
        [Description("Label for the Y axes")]
        public string YLabel { get => yLabel; set => yLabel = value; }



        private CsvPlotter.ColorsCollection yAxisLabelColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Y Axis Label Color")]
        [Description("The Color of the Y axis label")]
        public CsvPlotter.ColorsCollection YAxisLabelColor { get => yAxisLabelColor; set => yAxisLabelColor = value; }
        #endregion

        #region Plot 's Spine color

        //bottom
        private CsvPlotter.ColorsCollection bottomSpineColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Bottom Spine Color")]
        [Description("The color of the plot 's bottom spine")]
        public CsvPlotter.ColorsCollection BottomSpineColor { get => bottomSpineColor; set => bottomSpineColor = value; }

        //top
        private CsvPlotter.ColorsCollection topSpineColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Top Spine Color")]
        [Description("The color of the plot 's top spine")]
        public CsvPlotter.ColorsCollection TopSpineColor { get => topSpineColor; set => topSpineColor = value; }

        //left
        private CsvPlotter.ColorsCollection leftSpineColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Left Spine Color")]
        [Description("The color of the plot 's left spine")]
        public CsvPlotter.ColorsCollection LeftSpineColor { get => leftSpineColor; set => leftSpineColor = value; }

        //right
        private CsvPlotter.ColorsCollection rightSpineColor = CsvPlotter.ColorsCollection.black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Right Spine Color")]
        [Description("The color of the plot 's right spine")]
        public CsvPlotter.ColorsCollection RightSpineColor { get => rightSpineColor; set => rightSpineColor = value; }
        

        //color test
        private Color colorTest;
        public Color ColorTest { get => colorTest; set => colorTest = value; }
        #endregion
    }

    public class HistogramAttributes : PlotProperty2d,IPlotProperty
    {
        private CsvPlotter.ColorsCollection barColor = CsvPlotter.ColorsCollection.blue;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Bar Color")]
        [Description("The color of the bar")]
        public CsvPlotter.ColorsCollection BarColor { get => barColor; set => barColor = value; }

        private string xColumnName;
        [Category(PlotProperty.plotDataCategoryText)]
        [DisplayName("X Column Name")]
        [Description("The name of the column that will be plotted into histogram")]
        /// <summary>
        /// the column name for x (histogram's data)
        /// </summary>
        public string XColumnName { get => xColumnName; set => xColumnName = value; }

        public bool ColumnsNamesAreValid(ref string exceptionMessage)
        {
            exceptionMessage = " ";
            if (CsvReader.HasColumn(xColumnName))
            {
                return true;
            }
            else
            {
                exceptionMessage = "X Column Name doesnt exist in the specified name ";
                return false;
            }
         
        }
    }
    public class ScatterAttributes : PlotProperty2d,IPlotProperty
    {
        private string xColumnName;

        [Category(PlotProperty.plotDataCategoryText)]
        [DisplayName("X Column Name")]
        [Description("The name of the column that will be plotted into the scatter plot (X axis)")]
        public string XColumnName { get => xColumnName; set => xColumnName = value; }

        private string yColumnName;
        [Category(PlotProperty.plotDataCategoryText)]
        [DisplayName("Y Column Name")]
        [Description("The name of the column that will be plotted into the scatter plot (Y axis)")]
        public string YColumnName { get => yColumnName; set => yColumnName = value; }

        private CsvPlotter.ColorsCollection dotColor = CsvPlotter.ColorsCollection.blue;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Dot Color")]
        [Description("The color of the dot")]
        public CsvPlotter.ColorsCollection DotColor { get => dotColor; set => dotColor = value; }
        public bool ColumnsNamesAreValid(ref string exceptionMessage)
        {
            if (!CsvReader.HasColumn(xColumnName))
            {
                return false;
            }
            else if (!CsvReader.HasColumn(yColumnName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
