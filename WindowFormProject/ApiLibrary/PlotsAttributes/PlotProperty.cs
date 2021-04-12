using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    /// <summary>
    /// This class or the other classess that derrive from this  will be instantiated by using [PropertyGrid].
    /// Class's properties will be displayed to be filled by the user.
    /// common property for plot like name,size,background color that are unrelated to the plot types
    /// </summary>
    public class PlotProperty
    {
        protected string name;
    }
    public class HistogramAttributes : PlotProperty
    {
        /// <summary>
        /// the column name for x (histogram's data)
        /// </summary>
        public string xColumnName;

    }
    public class ScatterAttributes : PlotProperty
    {
        /// <summary>
        /// the column name for x (histogram's data)
        /// </summary>
        public string xColumnName;

        /// <summary>
        /// the column name for y (histogram's data)
        /// </summary>
        public string yColumnName;

    }
}
