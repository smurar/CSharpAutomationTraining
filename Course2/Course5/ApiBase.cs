using Course2.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Course2.Course5
{
    class ApiBase
    {
        public string Result { get; set; }
        public int StatusCode { get; set; }
        public object XmlDocumentsoapEnvelopeXml { get; private set; }

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
            return JToken.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);

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

        //SOAP
        public void PostSoap(string URL, string xmlPath, string SOAPActionHeader, string mediaType)
        {
            var xmlString = ReadXmlDocument(xmlPath);
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("SOAPAction", SOAPActionHeader);
                var content = new StringContent(xmlString, Encoding.UTF8, mediaType);
                var response = httpClient.PostAsync(new Uri(URL), content).Result;
                Result = response.Content.ReadAsStringAsync().Result;
                StatusCode = (int)response.StatusCode;
                Reporter.LogInfo("Check status code is 200");
                Assert.AreEqual(200, StatusCode);
                Reporter.LogPass("Pass");
                Reporter.LogInfo("Check result is not null");
                Assert.True(!string.IsNullOrEmpty(Result));
                Reporter.LogPass("Pass");
            }
        }

        private string ReadXmlDocument(string path)
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.Load(path);
            return soapEnvelopeXml.OuterXml;
        }

        public T DeserializeXmlResponseToObject<T>()
        {
            //load soap result in XDocument
            XDocument xDoc= XDocument.Load(new StringReader(Result));
            //remove s:Envelope and s:Body
            XNamespace soap = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
            var xmlString= string.Concat(xDoc.Descendants(soap + "Body").Elements());
            //load parsed soap result (without s:Envelope and s:Body) in XDocument
            XDocument xDocParsed= XDocument.Load(new StringReader(xmlString));
            //map xml to json
            var jsonFromXml= JsonConvert.SerializeXNode(xDocParsed);
            Reporter.LogInfo(jsonFromXml);
            //map jsonto object model
            var objFromJson= JsonConvert.DeserializeObject<T>(jsonFromXml);
            return objFromJson;
        }

        public T DeserializeXml<T>(string file, string root)
        {
            var xdoc = XDocument.Load(file);
            XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace m = "http://tempuri.org/";
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = root;
            xRoot.Namespace = "http://tempuri.org/";
            var responseXml = xdoc.Element(soap + "Envelope").Element(soap + "Body")
                                  .Element(m + root);

            var serializer = new XmlSerializer(typeof(T),xRoot);
            return (T)serializer.Deserialize(responseXml.CreateReader());


        }

       


    }
}
