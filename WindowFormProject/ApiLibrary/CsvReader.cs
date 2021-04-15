using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiLibrary;
using Newtonsoft.Json;

namespace ProjectLibrary
{
    static public class CsvReader
    {
        private static string csvFilePath;
        private static string[] columns;

        static public async Task ReadAndInitializeCsv(string csvFilePath)
        {
            CsvReader.csvFilePath = csvFilePath;

            string apiURL = "http://localhost:5000/CsvReader/path1";
            //await FlaskApi.PutRequest(apiURL,[ new KeyValuePair<string, string>("csvFilePath", csvFilePath)]);
            await FlaskApi.PutRequest(apiURL, new Dictionary<string, string>
            {
                {"csvFilePath",csvFilePath },
            });


            Dictionary<string, object> result = await FlaskApi.GetRequest(apiURL);



            //result["path1"] should be an array of the columns in string data types
            string columnsString = result["path1"] as string;
            CsvReader.columns = DataStructureConverter.ConvertStringToArrayOfString(columnsString);


        }
        /// <summary>
        /// Check if [columnName] exist 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        static public bool HasColumn(string columnName)
        {
            //regex to remove non alphanumeric
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");

            string newColumnName = rgx.Replace(columnName, "");
            //remove empty space
            newColumnName = newColumnName.Replace(" ", String.Empty);
            for (int i = 0; i < CsvReader.columns.Length; i++)
            {
                string columnToCompare = rgx.Replace(CsvReader.columns[i], "");
                columnToCompare = columnToCompare.Replace(" ", String.Empty);

                if (columnToCompare.ToLower() == newColumnName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
