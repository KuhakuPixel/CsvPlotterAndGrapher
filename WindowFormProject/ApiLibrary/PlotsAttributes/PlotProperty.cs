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
        private string name;
        public string Name { get => name; set => name = value; }
    }
    public class HistogramAttributes : PlotProperty
    {
        private string xColumnName;

        /// <summary>
        /// the column name for x (histogram's data)
        /// </summary>
        public string XColumnName { get => xColumnName; set => xColumnName = value; }
       
    }
    public class ScatterAttributes : PlotProperty
    {

        private string xColumnName;
        /// <summary>
        /// the column name for x (histogram's data)
        /// </summary>
        public string XColumnName { get => xColumnName; set => xColumnName = value; }
      

        private string yColumnName;

        /// <summary>
        /// the column name for y (histogram's data)
        /// </summary>
        public string YColumnName { get => yColumnName; set => yColumnName = value; }

    }
}
