using ApiLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class CsvPlotter
    {
        static public async Task<string[]> DisplayHistogram(string columnToHistogram)
        {
            string apiURL = "http://localhost:5000/Plotter/ColumnToHistogram/plot1";
            await FlaskApi.PutRequest(apiURL, new KeyValuePair<string, string>("columnName", columnToHistogram));
            string json = await FlaskApi.GetRequest(apiURL);
            //deserialize json
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);


            //result["path1"] should be an array of the columns in string data types
            string columnsString = result["plot1"] as string;
            return StringDataStructureConverter.ConvertStringToArray(columnsString);

        }
    }
}
