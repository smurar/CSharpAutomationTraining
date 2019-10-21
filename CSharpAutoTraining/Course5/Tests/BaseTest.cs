using CSharpAutoTraining.Course5.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course5.Tests
{
    class BaseTest
    {
        public ApiBase ApiBaseInstance { get; private set; }

        [OneTimeSetUp]
        public void beforeTestClass()
        {
            ReporterAPI.StartReporting();
        }


        [OneTimeTearDown]
        public void afterTestClass()
        {
            ReporterAPI.EndReporting();
        }


        [SetUp]
        public void InitializeTest()
        {
            ReporterAPI.StartTest(TestContext.CurrentContext.Test.MethodName);

            ApiBaseInstance = new ApiBase();
        }


        [TearDown]
        public void CloseTest()
        {
            ReporterAPI.EndTest();
        }
    }
}
