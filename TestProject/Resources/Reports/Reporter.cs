using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TestProject.Resources.Class;
using TestProject.Resources.Resx;

namespace TestProject.Resources.Reports
{
    public class Reporter 
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        public static readonly string ReportFileName = Templates.fileName + FileTypeResx.HTML;        

        public static void StartReporting()
        {
            InitializeExtentReports();
            CreateHtmlReportFile();
        }

        public static void InitializeExtentReports()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
            }
        }

        public static void CreateHtmlReportFile()
        {
            var htmlReporter = new ExtentHtmlReporter(Paths.ReportFilesFolder + ReportFileName)
            {
                AppendExisting = true
            };
            extent.AttachReporter(htmlReporter);
        }

        public static void EndReporting()
        {
            extent.Flush();
            EmailSender.SendReportEmail(); //if email is sent it works only for one namespace (NUnit)
        }

        public static void StartTest(string testName)
        {
            test = extent.CreateTest("Test name: " + testName);
        }

        public static void EndTest()
        {
            Status logStatus;
            var testStatus = Helpers.GetCurrentTestOutcome();          
            var stackTrace = Helpers.GetCurrentTestStacktrace();
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                default:
                    logStatus = Status.Pass;
                    break;
            }
            
            test.Log(logStatus, "StackTrace : " +stackTrace);                     
            test.Log(logStatus, "Message : " + message);                     
            extent.Flush(); //if email is sent it works only for one namespace (NUnit)         
        }     

        public static void LogInfo(string info)
        {
            test.Info(info);
        }

        public static void LogPass(string info)
        {
            test.Pass(info);
        }

        public static void LogFail(string info)
        {
            test.Fail(info);
        }

        public static void LogScreenshot(string screenshotPath)
        {
            test.AddScreenCaptureFromPath(screenshotPath);
        }
    }
}
