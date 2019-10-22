using Course2.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Course2.Course5
{
    class ApiBase
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

        public static string PrettyPrintJson(string json)
        {
            return JToken.Parse(json).ToString(Formatting.Indented);

        }

        public T MapResultToObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(Result);
        }
       

        public void Post(string URL, string serviceName, string requestBodyPath, string mediaType)
        {
            var requestBody = GetJsonFromFile(requestBodyPath);
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(requestBody.ToString(), Encoding.UTF8, mediaType);
                var response = httpClient.PostAsync(new Uri(URL + serviceName), content).Result;
                Result = response.Content.ReadAsStringAsync().Result;
                StatusCode = (int)response.StatusCode;
                Reporter.LogInfo(PrettyPrintJson(Result.ToString()));
            }
        }

        public void Delete(string URL, string serviceName)
        {
           
            using (var httpClient = new HttpClient())
            {
               
                var response = httpClient.DeleteAsync(new Uri(URL + serviceName)).Result;
                Result = response.Content.ReadAsStringAsync().Result;
                StatusCode = (int)response.StatusCode;
                Reporter.LogInfo(PrettyPrintJson(Result.ToString()));
            }
        }

        public void Put(string URL, string serviceName, string requestBodyPath, string mediaType)
        {
            var requestBody = GetJsonFromFile(requestBodyPath);
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(requestBody.ToString(), Encoding.UTF8, mediaType);
                var response = httpClient.PutAsync(new Uri(URL + serviceName), content).Result;
                Result = response.Content.ReadAsStringAsync().Result;
                StatusCode = (int)response.StatusCode;
                Reporter.LogInfo(PrettyPrintJson(Result.ToString()));
            }
        }

       

        
        public string GetJsonFromFile(string path)
        {
            JObject obj = JObject.Parse(File.ReadAllText(path));
            return obj.ToString();
        }
    }
}
