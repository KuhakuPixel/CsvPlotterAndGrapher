using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectLibrary
{
    interface IPlotProperty
    {
        bool AreColumnsNamesValid();
    }
    /// <summary>
    /// This class or the other classess that derrive from this  will be instantiated by using [PropertyGrid].
    /// Class's properties will be displayed to be filled by the user.
    /// common property for plot like name,size,background color that are unrelated to the plot types
    /// </summary>
    public class PlotProperty
    {
        private string plotName;

        [Category("Trivial")]
        [DisplayName("Plot name")]
        [Description("Plot name will be displayed on top of the plot")]
        public string PlotName { get => plotName; set => plotName = value; }
    }
    public class OneDataPlotAttributes : PlotProperty,IPlotProperty
    {
        private string xColumnName;

        /// <summary>
        /// the column name for x (histogram's data)
        /// </summary>
        public string XColumnName { get => xColumnName; set => xColumnName = value; }

        public bool AreColumnsNamesValid()
        {
            return CsvReader.DoesColumnExist(xColumnName);
           
        }
    }
    public class TwoDataPlotAttributes : PlotProperty, IPlotProperty
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

        public bool AreColumnsNamesValid()
        {
            bool columnsNameAreValid = false;
            columnsNameAreValid = CsvReader.DoesColumnExist(xColumnName);
            columnsNameAreValid = CsvReader.DoesColumnExist(yColumnName);
            return columnsNameAreValid;
        }
    }


    public class HistogramAttributes : OneDataPlotAttributes
    {


    }
    public class ScatterAttributes : TwoDataPlotAttributes
    {



    }
}
