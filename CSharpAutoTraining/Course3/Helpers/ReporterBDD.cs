using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Helpers
{   /// <summary>
    /// Reporter class
    /// </summary>
    class ReporterBDD
    {
        private static ExtentReports extent;

        private static ExtentTest test;

        /// <summary>
        /// Start Reporting method. It starts the reporter by creating new object or appends the existing one.
        /// </summary>
        public static void StartReporting()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\\";

            System.IO.Directory.CreateDirectory(path);


            if (extent == null)
            {
                extent = new ExtentReports();
            }

            var htmlReporter = new ExtentHtmlReporter(path + "\\ExtentReport.html");

            htmlReporter.AppendExisting = true;

            extent.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// Stop reporting method
        /// </summary>
        public static void EndReporting()
        {
            extent.Flush();
        }

        /// <summary>
        /// Starts reporting for a test. Test name is passed in method.
        /// </summary>
        /// <param name="testName"></param>
        public static void StartTest(string testName)
        {
            test = extent.CreateTest("Test Name: " + testName);
        }

        /// <summary>
        /// Stops reporting for test and logs status.
        /// </summary>
        public static void EndTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);


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

            LogInfo("Ending test");

            extent.Flush();
        }

        /// <summary>
        /// Logs info when used. Param is passed in test to log specific action.
        /// </summary>
        /// <param name="info">text to be logged as info</param>
        public static void LogInfo(string info)
        {
            test.Info(info);
        }

        /// <summary>
        /// Logs passed test.
        /// </summary>
        /// <param name="info">text to be logged as info</param>
        public static void LogPass(string info)
        {
            test.Pass(info);
        }

        /// <summary>
        /// Logs failed test.
        /// </summary>
        /// <param name="info">text to be logged as info</param>
        public static void LogFail(string info)
        {
            test.Fail(info);
        }

        /// <summary>
        /// Log screenshot method. Takes info argument and screenshot path.
        /// </summary>
        /// <param name="info">text to be logged as info</param>
        /// <param name="screenshotpath"></param>
        public static void LogScreenshot(string info, string screenshotpath)
        {
            test.Info(info).AddScreenCaptureFromPath(screenshotpath);
        }
    }
}
