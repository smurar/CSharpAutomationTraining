using Course2.Course5.Resources;
using Course2.Reports;
using Course2.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Course5
{
    class ApiTest:ApiBaseTest
    {
        [Test]
        public void ApiGetProductsList()
        {
            var apiBase = new ApiBase();
            apiBase.Get(ApiData.URL_Rest, ApiData.ServiceName_GetProductsList);
            Reporter.LogInfo("Check status code is 200");
            Assert.AreEqual(200, apiBase.StatusCode);
            Reporter.LogPass("Pass");
            Reporter.LogInfo("Check result is not null");
            Assert.True(!string.IsNullOrEmpty(apiBase.Result));
            Reporter.LogPass("Pass");

           

        }

        [Test]
        public void ApiGetProduct()
        {
            var apiBase = new ApiBase();
            apiBase.Get(ApiData.URL_Rest, ApiData.ServiceName_GetProductsList+"/"+APITestData.GetProduct);
            Reporter.LogInfo("Check status code is 200");
            Assert.AreEqual(200, apiBase.StatusCode);
            Reporter.LogPass("Pass");
            Reporter.LogInfo("Check result is not null");
            Assert.True(!string.IsNullOrEmpty(apiBase.Result));
            Reporter.LogInfo("Check returned Product id");
            //Products product = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(apiBase.Result);
            var obj = apiBase.MapResultToObject<ProductResult>();
            
            Assert.AreEqual(APITestData.GetProduct, obj.GetProductRestResult.ProductId.ToString());
            Reporter.LogPass("Pass");



        }

        [Test]
        public void CheckProductIdIsNotNull()
        {
            var apiBase = new ApiBase();
            apiBase.Get(ApiData.URL_Rest, ApiData.ServiceName_GetProductsList);
            var obj = apiBase.MapResultToObject<ProductListResults>();
            foreach (var product in obj.GetProductListRestResult)
            {
                Reporter.LogInfo("Check that product id is not null");
                Assert.IsTrue(!string.IsNullOrEmpty(product.ProductId.ToString()));
                Reporter.LogPass("Pass, existing product id: " + product.ProductId);
            }
        }

        [Test]
        public void ApiPostProduct()
        {
            var apiBase = new ApiBase();
            var requestBodyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\RestProductPost.json";
            apiBase.Post(ApiData.URL_Rest, ApiData.ServiceName_PostRegister, requestBodyPath, "application/json");
            Reporter.LogInfo("Check status code is 200");
            Assert.AreEqual(200, apiBase.StatusCode);
            Reporter.LogPass("Pass");
            Products product = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(apiBase.GetJsonFromFile(requestBodyPath));
            List<Products> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Products>>(apiBase.Result);
            Reporter.LogInfo("Check that the Product have been successfully created");
            Assert.IsTrue(obj.Contains(product));
            Reporter.LogPass("The Product " + product.ProductId + " has been successfully created");
            
        }

        [Test]
        public void ApiDeleteProduct()
        {
            var apiBase = new ApiBase();
            apiBase.Delete(ApiData.URL_Rest, ApiData.ServiceName_Delete+'/'+APITestData.ProductToBeDeleted);
            Reporter.LogInfo("Check status code is 200");
            Assert.AreEqual(200, apiBase.StatusCode);
            Reporter.LogPass("Pass");
           
            List<Products> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Products>>(apiBase.Result);
            Reporter.LogInfo("Check that the Product have been successfully deleted");
            foreach (Products product in obj)
            {
                Assert.AreNotEqual(product.ProductId, APITestData.ProductToBeDeleted.ToString());
            }
            Reporter.LogPass("The product " + APITestData.ProductToBeDeleted + " has been successfully deleted");
            
        }

        [Test]
        public void ApiPutProduct()
        {
            var apiBase = new ApiBase();
            var requestBodyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\RestProductPut.json";
            apiBase.Put(ApiData.URL_Rest, ApiData.ServiceName_PutRegister, requestBodyPath, "application/json");
            Reporter.LogInfo("Check status code is 200");
            Assert.AreEqual(200, apiBase.StatusCode);
            Reporter.LogPass("Pass");
            Products product = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(apiBase.GetJsonFromFile(requestBodyPath));
            List<Products> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Products>>(apiBase.Result);
            Reporter.LogInfo("Check that the Product have been successfully updated");
            foreach (Products o in obj)
            {
                if (o.ProductId.Equals(product.ProductId))
                {
                    Assert.AreEqual(o.CategoryName, product.CategoryName);
                    Assert.AreEqual(o.Name, product.Name);
                    Assert.AreEqual(o.Price, product.Price);
                }
            }
            Reporter.LogPass("The Product " + product.ProductId + " has been successfully updated");
        }

        //Soap Tests
        [Test]
        public void ApiSoapAdd()
        {
            var apiBase = new ApiBase();
            var xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Add.xml";
            var SOAPActionHeader = "http://tempuri.org/IService1/Add";
            var mediaType = "text/xml";
            apiBase.PostSoap(ApiData.URL_Calculator, xmlPath, SOAPActionHeader, mediaType);
            var response = apiBase.DeserializeXmlResponseToObject<AddResponseModel>();

            int sum=int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Add.xml","Add").val1)
                    + int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Add.xml","Add").val2);
            Reporter.LogInfo("Check that the returned result " + response.AddResponse.AddResult + " equals the expected result " + sum.ToString());
            Assert.AreEqual(sum, int.Parse(response.AddResponse.AddResult));
            Reporter.LogPass("Pass");
            
        }

        [Test]
        public void ApiSoapDivide()
        {
            var apiBase = new ApiBase();
            var xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Divide.xml";
            var SOAPActionHeader = "http://tempuri.org/IService1/Divide";
            var mediaType = "text/xml";
            apiBase.PostSoap(ApiData.URL_Calculator, xmlPath, SOAPActionHeader, mediaType);
            var response = apiBase.DeserializeXmlResponseToObject<DivideResponseModel>();

            int sum = int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Divide.xml","Divide").val1)
                    / int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Divide.xml", "Divide").val2);
            Reporter.LogInfo("Check that the returned result " + response.DivideResponse.DivideResult + " equals the expected result " + sum.ToString());
            Assert.AreEqual(sum, int.Parse(response.DivideResponse.DivideResult));
            Reporter.LogPass("Pass");

        }

        [Test]
        public void ApiSoapMultiply()
        {
            var apiBase = new ApiBase();
            var xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Multiply.xml";
            var SOAPActionHeader = "http://tempuri.org/IService1/Multiply";
            var mediaType = "text/xml";
            apiBase.PostSoap(ApiData.URL_Calculator, xmlPath, SOAPActionHeader, mediaType);
            var response = apiBase.DeserializeXmlResponseToObject<MultiplyResponseModel>();

            int sum = int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Multiply.xml", "Multiply").val1)
                    * int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Multiply.xml", "Multiply").val2);
            Reporter.LogInfo("Check that the returned result " + response.MultiplyResponse.MultiplyResult+ " equals the expected result " + sum.ToString());
            Assert.AreEqual(sum, int.Parse(response.MultiplyResponse.MultiplyResult));
            Reporter.LogPass("Pass");

        }

        [Test]
        public void ApiSoapSubtract()
        {
            var apiBase = new ApiBase();
            var xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Subtract.xml";
            var SOAPActionHeader = "http://tempuri.org/IService1/Subtract";
            var mediaType = "text/xml";
            apiBase.PostSoap(ApiData.URL_Calculator, xmlPath, SOAPActionHeader, mediaType);
            var response = apiBase.DeserializeXmlResponseToObject<SubtractResponseModel>();

            int sum = int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Subtract.xml", "Subtract").val1)
                    - int.Parse(apiBase.DeserializeXml<XMLValues>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\Resources\Subtract.xml", "Subtract").val2);
            Reporter.LogInfo("Check that the returned result " + response.SubtractResponse.SubtractResult + " equals the expected result " + sum.ToString());
            Assert.AreEqual(sum, int.Parse(response.SubtractResponse.SubtractResult));
            Reporter.LogPass("Pass");

        }

    }
}
