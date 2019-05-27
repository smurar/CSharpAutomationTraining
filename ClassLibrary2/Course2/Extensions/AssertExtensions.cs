using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ClassLibrary2.Course2.Extensions
{
	public static class AssertExtensions
	{

		public static void AssertThatAreEqual<T>(String info, T expected, T actual)
		{
			Reporter.LogInfo(info + " | Expected: '" + string.Format("{0}", expected) + "' | Actual: '" + string.Format("{0}", actual));

			Assert.AreEqual(expected, actual);
			Reporter.LogPass("Checker has passed");
		}

		public static void AssertThatContains(String info, string expected, string actual)
		{
			Reporter.LogInfo(info);

			StringAssert.Contains(expected, actual);
			Reporter.LogPass("Checker has passed");
		}
	}
}
