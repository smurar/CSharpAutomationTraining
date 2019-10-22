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
    }
}
