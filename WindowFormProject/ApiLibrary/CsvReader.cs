using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiLibrary;
using Newtonsoft.Json;

namespace ProjectLibrary
{
    public class CsvReader
    {
        static public async Task<string[]>  GetCsvColumns(string csvFilePath)
        {
            string apiURL = "http://localhost:5000/CsvReader/path1";
            await FlaskApi.PutRequest(apiURL, new KeyValuePair<string, string>("csvFilePath", csvFilePath));
            string json = await FlaskApi.GetRequest(apiURL);
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string,object>>(json);
            ///JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return new string[0];
        }
    }
}
