using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;
using System.Reflection;

namespace CSharpAutoTraining.Utils
{
    public class Reporter
    {
        private static ExtentReports extent;
        private static ExtentTest test;

        public static void StartReporting(string methodName)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\\";
            Directory.CreateDirectory(path);

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
            test = extent.CreateTest("Test name: " + testName);

            //grab test name like the following:
            //Reports.startTest(testContext.CurrentContext.Test.MethodName);
        }

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

        public static void LogInfo(string info)
        {
            test.Info("<pre>"+info+"</pre>");
        }

        public static void LogPass(string info)
        {
            test.Pass(info);
        }

        public static void LogFail(string info)
        {
            test.Fail(info);
        }

        public static void LogScreenshot(string info, string screenshotpath)
        {
            test.Info(info).AddScreenCaptureFromPath(screenshotpath);
            //how to use
            //Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(driver));
        }
    }
}
