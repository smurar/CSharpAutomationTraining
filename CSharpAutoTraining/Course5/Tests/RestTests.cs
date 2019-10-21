using CSharpAutoTraining.Course5.Constants;
using CSharpAutoTraining.Course5.Helpers;
using CSharpAutoTraining.Course5.ResponseMappers;
using CSharpAutoTraining.Course5.ResponseModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var obj = ApiBaseInstance.MapResultsToObject<ProductListResults>();

            foreach (var product in obj.GetProductListRestResults)
            {
                ReporterAPI.LogInfo("Check that user ID is not null");
                Assert.IsTrue(!string.IsNullOrEmpty(product.ProductId.ToString()));
                ReporterAPI.LogPass("Pass, existing user ID: " + product.ProductId);
            }
        }
    }
}
