using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private string plotName=" ";

        [Category("Appearance (Optional)")]
        [DisplayName("Plot name")]
        [Description("Plot name will be displayed on top of the plot")]
        public string PlotName { get => plotName; set => plotName = value; }


        
        private CsvPlotter.ColorsCollection plotNameColor = CsvPlotter.ColorsCollection.black;
        [Category("Appearance (Optional)")]
        [DisplayName("Plot Name Color")]
        [Description("The text color of plot name")]
        public CsvPlotter.ColorsCollection PlotNameColor { get => plotNameColor; set => plotNameColor = value; }
    }

    public class PlotProperty2d : PlotProperty
    {
        


        #region X Label
        private string xLabel=" ";
        [Category("Appearance (Optional)")]
        [DisplayName("X Axes Label")]
        [Description("Label for the X axes")]
        public string XLabel { get => xLabel; set => xLabel = value; }

        private CsvPlotter.ColorsCollection xAxisLabelColor = CsvPlotter.ColorsCollection.black;
        [Category("Appearance (Optional)")]
        [DisplayName("X Axis Label Color")]
        [Description("The Color of the X axis label")]
        public CsvPlotter.ColorsCollection XAxisLabelColor { get => xAxisLabelColor; set => xAxisLabelColor = value; }
        #endregion

        #region YLabel
        private string yLabel=" ";
        [Category("Appearance (Optional)")]
        [DisplayName("Y Axes Label")]
        [Description("Label for the Y axes")]
        public string YLabel { get => yLabel; set => yLabel = value; }



        private CsvPlotter.ColorsCollection yAxisLabelColor = CsvPlotter.ColorsCollection.black;
        [Category("Appearance (Optional)")]
        [DisplayName("Y Axis Label Color")]
        [Description("The Color of the Y axis label")]
        public CsvPlotter.ColorsCollection YAxisLabelColor { get => yAxisLabelColor; set => yAxisLabelColor = value; }
        #endregion
        
    }
   
    public class HistogramAttributes : PlotProperty2d,IPlotProperty
    {
        private string xColumnName;
        [Category("Data (Mandatory)")]
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

        /// <summary>
        /// the column name for x 
        /// </summary>
        public string XColumnName { get => xColumnName; set => xColumnName = value; }

        private string yColumnName;

        /// <summary>
        /// the column name for y 
        /// </summary>
        public string YColumnName { get => yColumnName; set => yColumnName = value; }

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
