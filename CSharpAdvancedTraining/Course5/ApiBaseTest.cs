using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAdvancedTraining.Course2;
using NUnit.Framework;

namespace CSharpAdvancedTraining.Course5
{
	public class ApiBaseTest
	{

		public ApiBase ApiBaseInstance { get; set; }

		[OneTimeSetUp]
		public void BeforeTestClass()
		{
			Reporter.StartReporting();
		}

		[SetUp]
		public void BeforeTest()
		{
			Reporter.StartTest(TestContext.CurrentContext.Test.ClassName + ": " + TestContext.CurrentContext.Test.MethodName);
			ApiBaseInstance = new ApiBase();
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
