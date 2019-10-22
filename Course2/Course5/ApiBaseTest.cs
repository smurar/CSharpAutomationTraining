using Course2.Reports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Course5
{
    class ApiBaseTest
    {
        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            Reporter.StartReporting();
        }

        [SetUp]
        public void BeforeTest()
        {
            Reporter.StartTest(TestContext.CurrentContext.Test.ClassName + ": " + TestContext.CurrentContext.Test.MethodName);
            

        }

       
        [TearDown]
        public void AfterTest()
        {
            
           

            Reporter.EndTest();
        }


        [OneTimeTearDown]
        public void AfterTestClass()
        {
            Reporter.EndReporting();
        }
    }
}
