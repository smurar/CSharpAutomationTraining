using CSharpAutoTraining.Course5.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course5
{
    class ApiBase
    {
        public string Result { get; set; }
        public int StatusCode { get; set; }

        public static string PrettyPrintJSON(string json)
        {
            return JToken.Parse(json).ToString(Formatting.Indented);
        }

        public T MapResultsToObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(Result);
        }

        //HTTP Methods
        public void Get(string URL, string serviceName)
        {
            
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(URL + serviceName)).Result;

                Result = response.Content.ReadAsStringAsync().Result;

                ReporterAPI.LogInfo(PrettyPrintJSON(Result.ToString()));

                StatusCode = (int)response.StatusCode;
            }
        }

        public void GetByID(string URL, string serviceName, string ID)
        {

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(URL + serviceName + "/" + ID)).Result;

                Result = response.Content.ReadAsStringAsync().Result;

                ReporterAPI.LogInfo(PrettyPrintJSON(Result.ToString()));

                StatusCode = (int)response.StatusCode;
            }
        }
    }
}
