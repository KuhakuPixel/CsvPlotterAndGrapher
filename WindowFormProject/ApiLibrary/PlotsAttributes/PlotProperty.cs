using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    /// <summary>
    /// This class or the other classess that derrive from this  will be instantiated by using [PropertyGrid].
    /// Class's properties will be displayed to be filled by the user
    /// common property for plot like name,size color of the background that are unrelated to the plot types
    /// </summary>
    class PlotProperty
    {
        protected string name;
    }
}
