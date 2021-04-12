using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ApiLibrary;
using Newtonsoft.Json;

namespace ProjectLibrary
{
    static public class CsvReader
    {
        private static string csvFilePath;
        private static string[] columns;
       
        static public async Task<string[]>  GetCsvColumns(string csvFilePath)
        {
            CsvReader.csvFilePath = csvFilePath;

            string apiURL = "http://localhost:5000/CsvReader/path1";
            await FlaskApi.PutRequest(apiURL, new KeyValuePair<string, string>("csvFilePath", csvFilePath));
            string json = await FlaskApi.GetRequest(apiURL);
            //deserialize json
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string,object>>(json);


            //result["path1"] should be an array of the columns in string data types
            string columnsString = result["path1"] as string;
            CsvReader.columns = DataStructureConverter.ConvertStringToArrayOfString(columnsString);
            return CsvReader.columns;
            
        }
        /// <summary>
        /// Check if [columnName] exist 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        static public bool DoesColumnExist(string columnName)
        {
           for(int i = 0; i < CsvReader.columns.Length; i++)
           {
                if (CsvReader.columns[i] == columnName)
                {
                    return true;
                }
           }
            return false;
        }
    }
}
