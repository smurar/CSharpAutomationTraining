using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using TestProject.Course2.Base;
using TestProject.Course2.Resources.Class;
using TestProject.Course2.Resources.Resx;

namespace TestProject.Course2.Reports
{
    public class Reporter : BasePage
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
          //  EmailSender.SendReportEmail(); //for the moment it works only for one namespace
        }

        public static void StartTest(string testName)
        {
            test = extent.CreateTest("Test name: " + testName);
        }

        public static void EndTest()
        {
            Status logStatus;
            var testStatus = Helpers.GetCurrentTestOutcome();
            var stackTrace = Helpers.GetCurrentTestFinalStackTrace();

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

            test.Log(logStatus, "Test ended with :" + logStatus + stackTrace);                     
            //extent.Flush(); //for the moment it works only for one namespace           
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
