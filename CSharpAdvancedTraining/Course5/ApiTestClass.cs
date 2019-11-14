
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharpAdvancedTraining.Course2;
using CSharpAdvancedTraining.Course2.Helpers;
using NUnit.Framework;

namespace CSharpAdvancedTraining.Course5
{
	public class ApiTestClass : ApiBaseTest
	{
		[Test]
		[Category("rest_tests")]
		public void ApiGetListUsers()
		{
			ApiBaseInstance.Get(ApiData.URL_Rest, ApiData.ServiceName_GetUsersList);
			Verifier.CheckThatAreEqual("Check expected status code is 200", 200, ApiBaseInstance.StatusCode);

			Verifier.CheckThatAreEqual("Check result is not null", true, !string.IsNullOrEmpty(ApiBaseInstance.Result));

			var obj = ApiBaseInstance.MapResultToObject<ProductListResults>();
			foreach (var product in obj.GetProductListRestResult)
			{
				Verifier.CheckThatAreEqual("Check that user id is not null", true, !string.IsNullOrEmpty(product.ProductId.ToString()));
				Reporter.LogPass("Pass, existing user id: " + product.ProductId);
			}
		}

		[Test]
		[Category("rest_tests")]
		public void ApiPostRegister()
		{
			var requestBodyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\RegisterPost.json";
			ApiBaseInstance.Post(ApiData.URL_Rest, ApiData.ServiceName_PostRegister, requestBodyPath, "application/json");
			Verifier.CheckThatAreEqual("Check expected status code is 200", 200, ApiBaseInstance.StatusCode);
		}

		[Test]
		public void PostProduct()
		{
			var requestBodyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Course5\RegisterPut.json";
			ApiBaseInstance.Post(ApiData.URL_Rest, ApiData.ServiceName_PostProductRest, requestBodyPath, "application/json");
			Verifier.CheckThatAreEqual("Check expected status code is 200", 200, ApiBaseInstance.StatusCode);
		}
	}
}
