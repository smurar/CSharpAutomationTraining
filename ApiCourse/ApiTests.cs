using CSharpAutoTraining.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course5
{
    public class ApiTests
    {


        [Test]
        public void ApiGetListUsers()
        {
            var apiBase = new ApiBase();
            apiBase.Get(ApiData.URL_Rest, ApiData.ServiceName_GetUsersList);

            Reporter.LogInfo("Check status code is 200");
            Assert.AreEqual(200, apiBase.StatusCode);
            Reporter.LogPass("Pass");
            Reporter.LogInfo("Check result is not null");
            Assert.True(!string.IsNullOrEmpty(apiBase.Result));
            Reporter.LogPass("Pass");
        }
    }
}
