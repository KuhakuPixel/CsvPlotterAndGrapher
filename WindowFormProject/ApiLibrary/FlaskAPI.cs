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


            #region PythonBackEndDirectory
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            //navigate one folder up
            string solutionDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\"));

            string pythonBackendDirectory = Path.Combine(solutionDirectory, "PythonBackend");

            //getting pythonscript dir
            string pythonScriptDirectory = Path.Combine(pythonBackendDirectory,
                                                         Path.GetFileName("main.py"));

            //getting executable dir
            string pythonExeDirectory = Path.Combine(new string[] { pythonBackendDirectory, "venv", "scripts", Path.GetFileName("python.exe") });
            #endregion


            start.FileName = pythonExeDirectory;
            start.Arguments = pythonScriptDirectory;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = false;
            //runnning cmd

            Process.Start(start);
            //suspend control until the process ended
            Thread.Sleep(3000);

        }
        public static async Task<Dictionary<string, object>> GetRequest(string apiEndPointUrl, bool printResponse=true)
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
