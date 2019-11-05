using CSharpAutoTraining.Course5.Constants;
using CSharpAutoTraining.Course5.Helpers;
using CSharpAutoTraining.Course5.ResponseMappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CSharpAutoTraining.Course5.Tests
{
    class RestTests : BaseTest
    {
        [Test]
        public void GetAllProducts()
        {
            ApiBaseInstance.Get(ApiData.URL_Rest, ApiData.ServiceName_GetProductList);

            ReporterAPI.LogInfo("Check status code is 200");
            Assert.AreEqual(200, ApiBaseInstance.StatusCode);
            ReporterAPI.LogPass("Pass");

            ReporterAPI.LogInfo("Check result is not null");
            Assert.True(!string.IsNullOrEmpty(ApiBaseInstance.Result));
            ReporterAPI.LogPass("Pass");

            ReporterAPI.LogInfo("Check ProductID is not null");
            var obj = ApiBaseInstance.DeserializeRootObjectList<Products>("GetProductListRestResult");

            foreach (var product in obj)
            {
                ReporterAPI.LogInfo("Check that user ID is not null");
                Assert.IsTrue(!string.IsNullOrEmpty(product.ProductId.ToString()));
                ReporterAPI.LogPass("Pass, existing user ID: " + product.ProductId);
            }
        }


        [Test]
        public void GetAllProductsWithTrainingMapper()
        {
            ApiBaseInstance.Get(ApiData.URL_Rest, ApiData.ServiceName_GetProductList);

            ReporterAPI.LogInfo("Check status code is 200");
            Assert.AreEqual(200, ApiBaseInstance.StatusCode);
            ReporterAPI.LogPass("Pass");

            ReporterAPI.LogInfo("Check result is not null");
            Assert.True(!string.IsNullOrEmpty(ApiBaseInstance.Result));
            ReporterAPI.LogPass("Pass");

            ReporterAPI.LogInfo("Check ProductID is not null");
            var obj = ApiBaseInstance.MapResultsToObject<ProductListResults>();

            foreach (var product in obj.GetProductListRestResults)
            {
                ReporterAPI.LogInfo("Check that user ID is not null");
                Assert.IsTrue(!string.IsNullOrEmpty(product.ProductId.ToString()));
                ReporterAPI.LogPass("Pass, existing user ID: " + product.ProductId);
            }
        }


        [Test]
        public void PostProduct()
        {
            var requestBodyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\POSTData\PostDataRest.json";
            ApiBaseInstance.Post(ApiData.URL_Rest, ApiData.ServiceName_PostProductRest, requestBodyPath, "application/json");
            Assert.AreEqual(200, ApiBaseInstance.StatusCode);
            //declaring list directly since POST response does not contain RootObject in JSON
            List<Products> obj = ApiBaseInstance.MapResultsToObject<List<Products>>();

            Assert.That(obj.Any(p => p.ProductId == 3));
        }

        [Test]
        public void DeleteProduct()
        {
            ApiBaseInstance.Delete(ApiData.URL_Rest, ApiData.ServiceName_DeleteProductRest, "3");
            Assert.AreEqual(200, ApiBaseInstance.StatusCode);

            List<Products> obj = ApiBaseInstance.MapResultsToObject<List<Products>>();

            Assert.That(!obj.Any(p => p.ProductId == 3));
        }

        [Test]
        public void PostWithParamsSentFromObject()
        {
            Products productPayload = new Products
            {
                CategoryName = "Test Cat Name",
                Name = "Test Product Name",
                Price = 33,
                ProductId = 4
            };

            ApiBaseInstance.PostWithParams(ApiData.URL_Rest, ApiData.ServiceName_PostProductRest, productPayload, "application/json");
            List<Products> products = ApiBaseInstance.MapResultsToObject<List<Products>>();

            string latestProductAdded = JsonConvert.SerializeObject(productPayload);

            Assert.IsTrue(products.Exists(w => w.ProductId == productPayload.ProductId), "The product: {0} was not added to the list of products!", latestProductAdded);
            //Assert.IsTrue(products.Find());

            ////a more dirty way of asserting that product is in response list
            //List<string> ActualList = new List<string>();

            //foreach (Products item in products)
            //{
            //    var itemString = JsonConvert.SerializeObject(item);
            //    ActualList.Add(itemString);
            //}
            
            //Assert.Contains(latestProductAdded, ActualList);
        }
    }
}
