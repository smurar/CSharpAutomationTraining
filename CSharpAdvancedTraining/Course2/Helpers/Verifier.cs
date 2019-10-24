using System;
using NUnit.Framework;

namespace CSharpAdvancedTraining.Course2.Helpers
{
	public static class Verifier
	{
		/// <summary>
		///  Check expected object equals the actual object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="info"></param>
		/// <param name="expected"></param>
		/// <param name="actual"></param>
		public static  void CheckThatAreEqual<T>(string info, T expected, T actual)
		{
			Reporter.LogInfo(info +" | Expected: '"+string.Format("{0}", expected)+"' | Actual: '"+string.Format("{0}", actual));
			try {
				Assert.AreEqual(expected, actual);
				Reporter.LogPass("Checker has passed");
			} catch (Exception e) {
				Reporter.LogFail(info + " - has failed. | Expected: '" + string.Format("{0}", expected) + "' | Actual: '" + string.Format("{0}", actual));
			}

		}

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
