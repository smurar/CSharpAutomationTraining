﻿using System;
using NUnit.Framework;

namespace ClassLibrary2.Course2.Helpers
{
	public class Verifier
	{
		/// <summary>
		///  Check expected object equals the actual object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="info"></param>
		/// <param name="expected"></param>
		/// <param name="actual"></param>
		public void CheckThatAreEqual<T>(string info, T expected, T actual)
		{
			Reporter.LogInfo(info +" | Expected: '"+string.Format("{0}", expected)+"' | Actual: '"+string.Format("{0}", actual));
			try {
				Assert.AreEqual(expected, actual);
				Reporter.LogPass("Checker has passed");
			} catch (Exception e) {
				Reporter.LogFail(info + " - has failed. | Expected: '" + string.Format("{0}", expected) + "' | Actual: '" + string.Format("{0}", actual));
			}

		}
	}
}
