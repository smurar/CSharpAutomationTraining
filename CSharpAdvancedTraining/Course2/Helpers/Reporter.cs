﻿using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace CSharpAdvancedTraining.Course2
{
	public class Reporter
	{
		private static ExtentReports extent;
		private static ExtentTest test;


		public static void StartReporting()
		{
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\\"; System.IO.Directory.CreateDirectory(path);
			if (extent == null)
			{
				extent = new ExtentReports();
			}
			var htmlReporter = new ExtentHtmlReporter(path + "\\ExtentReport.html");
			htmlReporter.AppendExisting = true;
			extent.AttachReporter(htmlReporter);
		}

		public static void EndReporting()
		{
			extent.Flush();
		}

		public static void StartTest(string testName)
		{
			Console.WriteLine("Start test: " + testName);
			test = extent.CreateTest("Test name: " + testName);
		}

		public static void EndTest()
		{
			var status = TestContext.CurrentContext.Result.Outcome.Status;

			var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

			Status logstatus;

			switch (status)
			{
				case TestStatus.Failed:
					logstatus = Status.Fail;
					break;
				case TestStatus.Inconclusive:
					logstatus = Status.Warning;
					break;
				case TestStatus.Skipped:
					logstatus = Status.Skip;
					break;
				default:
					logstatus = Status.Pass;
					break;
			}

			test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
			LogInfo("Ending Test");
			Console.WriteLine("Test ended with status: " + logstatus);

			extent.Flush();
		}


		public static void LogInfo(string info)
		{
			test.Info("<pre>" + info + "</pre>");
		}

		public static void LogPass(string info)
		{
			test.Pass(info);
		}
		public static void LogFail(string info)
		{
			test.Fail(info);
		}

		public static void LogScreenShot(string info, string screenshotpath)
		{
			test.Info(info).AddScreenCaptureFromPath(screenshotpath);
			//Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(driver));
		}

	}
}
