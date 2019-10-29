using CSharpAutoTraining.Course5.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

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


        public List<Y> DeserializeRootObjectList<Y>(string rootObject)
        {
            var jobj = JObject.Parse(Result);
            return JsonConvert.DeserializeObject<List<Y>>(jobj[rootObject].ToString());
        }

        public T MapResultsToObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(Result);
        }

        public string GetJsonFromFile(string path)
        {
            JObject obj = JObject.Parse(File.ReadAllText(path));
            return obj.ToString();
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

        public void Post(string URL, string serviceName, string requestBodyPath, string mediaType)
        {
            var requestBody = GetJsonFromFile(requestBodyPath);

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(requestBody.ToString() , Encoding.UTF8, mediaType);
                var response = httpClient.PostAsync(new Uri(URL + serviceName), content).Result;

                Result = response.Content.ReadAsStringAsync().Result;
                StatusCode = (int)response.StatusCode;
                ReporterAPI.LogInfo(PrettyPrintJSON(Result.ToString()));
            }
        }

        public void Delete(string URL, string serviceName, string ID)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(new Uri(URL + serviceName + "/" + ID)).Result;
                Result = response.Content.ReadAsStringAsync().Result;
                StatusCode = (int)response.StatusCode;
                ReporterAPI.LogInfo(PrettyPrintJSON(Result.ToString()));
            }
        }
    }
}
