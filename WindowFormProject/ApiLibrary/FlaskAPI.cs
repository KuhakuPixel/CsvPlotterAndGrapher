using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace ApiLibrary
{

    public class FlaskApi
    {
        private static readonly HttpClient client = new HttpClient();




        /// <summary>
        /// set isTesting to true if calling from console project(testing) 
        /// </summary>
        /// <param name="isTesting"></param>
        public static void StartAPIServer()
        {
            ProcessStartInfo start = new ProcessStartInfo();


        

            start.FileName = "main.exe";
     
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = false;
            //runnning cmd
            Process.Start(start);
            //suspend control until the process ended
            Thread.Sleep(3000);

        }
        public static async Task<Dictionary<string, object>> GetRequest(string apiEndPointUrl, bool printResponse = true)
        {
            HttpResponseMessage response = await client.GetAsync(apiEndPointUrl);
            string responseString = await response.Content.ReadAsStringAsync();



            if (printResponse)
            {
                string debugMessage = "Get request to " + apiEndPointUrl + "\n" + responseString;
                Debug.Write(debugMessage);
                Console.WriteLine(debugMessage);
            }

            return JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);
        }





        /// <summary>
        /// make a put request through the api url
        /// </summary>
        /// <param name="keysAndArguments">DataID specified by the key and the data specified by the value, </param>
        /// <returns></returns>
        public static async Task PutRequest(string apiEndPointUrl, Dictionary<string, string> keysAndArguments, bool printResponse = true)
        {

            //encode keyAndArgument
            FormUrlEncodedContent content = new FormUrlEncodedContent(keysAndArguments);






            HttpResponseMessage response = await client.PutAsync(apiEndPointUrl, content);

            if (printResponse)
            {
                string responseString = await response.Content.ReadAsStringAsync();



                string debugMessage = "Put request to " + apiEndPointUrl + "\n" + responseString;
                Debug.Write(debugMessage);
                Console.WriteLine(debugMessage);
            }

        }

    }

}
