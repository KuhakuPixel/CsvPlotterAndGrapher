using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
namespace RestApiTesting
{
     class FlaskApi
     {
        private static readonly HttpClient client = new HttpClient();
       






        public static async Task GetRequest(string apiEndPointUrl)
        {
            HttpResponseMessage response =await client.GetAsync(apiEndPointUrl);
            string responseString=await response.Content.ReadAsStringAsync();
            Debug.Write(responseString);
        }





        /// <summary>
        /// make a put request through the api url
        /// </summary>
        /// <param name="keyAndArgument">DataID specified by the key and the data specified by the value, </param>
        /// <returns></returns>
        public static async Task PutRequest(string apiEndPointUrl,KeyValuePair<string,string> keyAndArgument)
        {
            //encode keyAndArgument
            FormUrlEncodedContent content = new FormUrlEncodedContent(
                       new[] {
                           keyAndArgument
                          //new KeyValuePair<string, string>("csvFilePath", "C:/Users/Nicho/Desktop/Projects/CsvPlotterAndGrapher/csvTest.csv"),
                       }

                       );

            HttpResponseMessage response = await client.PutAsync(apiEndPointUrl, content);

            string responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseString);
        }

    }
}
