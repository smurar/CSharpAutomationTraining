using CSharpAutoTraining.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Course5
{
    public class ApiBase
    {
        public string Result { get; set; }
        public int StatusCode { get; set; }

        public void Get(string URL, string serviceName)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(URL + serviceName)).Result;

                Result = response.Content.ReadAsStringAsync().Result;
                Reporter.LogInfo(PrettyPrintJson(Result.ToString()));
                StatusCode = (int)response.StatusCode;
            }
        }

        private string PrettyPrintJson(string json)
        {
            return JToken.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
