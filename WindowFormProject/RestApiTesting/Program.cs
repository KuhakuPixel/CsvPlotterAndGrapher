﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApiTesting
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static string apiURL = "http://localhost:5000/CsvReader/path1";
        private static async Task Main(string[] args)
        {
            
            await FlaskApi.PutRequest(apiURL, new KeyValuePair<string, string>("csvFilePath", "C:/Users/Nicho/Desktop/Projects/CsvPlotterAndGrapher/csvTest.csv"));

            await FlaskApi.GetRequest(apiURL);
           
        }
    }
}