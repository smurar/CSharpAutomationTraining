﻿
using CSharpAdvancedTraining.Course2;
using CSharpAdvancedTraining.Course2.Helpers;

namespace CSharpAdvancedTraining.Course5
{
	public class ApiTestClass
	{

		public void ApiGetListUsers()
		{
			var apiBase = new ApiBase();
			apiBase.Get(ApiData.URL_Rest, ApiData.ServiceName_GetUsersList);
			Verifier.CheckThatAreEqual("Check expected status code is 200", 200, apiBase.StatusCode);
			Reporter.LogPass("Pass");

			Verifier.CheckThatAreEqual("Check result is not null", true, !string.IsNullOrEmpty(apiBase.Result));
			Reporter.LogPass("Pass");

			var obj = apiBase.MapResultToObject<ProductListResults>();
			foreach (var product in obj.GetProductListRestResult)
			{
				Verifier.CheckThatAreEqual("Check that user id is not null", true, !string.IsNullOrEmpty(product.ProductId.ToString()));
				Reporter.LogPass("Pass, existing user id: " + product.ProductId);
			}
		}
	}
}
