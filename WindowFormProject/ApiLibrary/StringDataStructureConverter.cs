using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    public class StringDataStructureConverter
    {
        /// <summary>
        /// example: convert "[name,car,house]" to [name,car,house]
        /// </summary>
        /// <returns></returns>
        public static string[] ConvertStringToArray(string arrayInString)
        {
            //remove brackets in the string (array leftover)
            arrayInString=arrayInString.Replace("[", "");
            arrayInString=arrayInString.Replace("]", "");
            return arrayInString.Split(',');


        }
    }
}
