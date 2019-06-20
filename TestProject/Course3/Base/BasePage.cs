using TechTalk.SpecFlow;
using TestProject.Resources.Reports;
using TestProject.Resources.Class;

namespace TestProject.Course3
{
    [Binding]
    public static class BasePage
    {        
        private static bool IsReportCreated = false;

        [BeforeScenario]
        public static void BeforeTest()
        {
            if (!IsReportCreated)
            {
                Reporter.StartReporting();
                IsReportCreated = true;
            }

            Reporter.StartTest(Helpers.GetCurrentTestName());
            Driver.ConfigureDriver();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Driver.DriverInstance.Quit();
            Reporter.EndTest();            
        }    

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Reporter.EndReporting();
        }
    }
}
