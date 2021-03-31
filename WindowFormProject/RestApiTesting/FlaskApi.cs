using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace RestApiTesting
{
     class FlaskApi
     {
        private static readonly HttpClient client = new HttpClient();






        public static void StartAPIServer()
        {
            ProcessStartInfo start = new ProcessStartInfo();


            #region PythonBackEndDirectory
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            //navigate one folder up
            string solutionDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\"));

            string pythonBackendDirectory = Path.Combine(solutionDirectory, "PythonBackend");

            string pythonScriptDirectory = Path.Combine(pythonBackendDirectory,            
                                                         Path.GetFileName("main.py"));




            #endregion


            start.FileName = pythonScriptDirectory;
           //start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
        public static async Task GetRequest(string apiEndPointUrl)
        {
            HttpResponseMessage response =await client.GetAsync(apiEndPointUrl);
            string responseString=await response.Content.ReadAsStringAsync();


            //clearing [responseString]
            //using double backslash to escape the special backslash character
            //responseString.Replace("\\","");
           // responseString.Replace("/", "");
            string debugMessage = "Get request to " + apiEndPointUrl + "\n" + responseString;
            Debug.Write(debugMessage);
            Console.WriteLine(debugMessage);
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



            string debugMessage = "Put request to " + apiEndPointUrl + "\n" + responseString;
            Debug.Write(debugMessage);
            Console.WriteLine(debugMessage);
        }

    }
}
