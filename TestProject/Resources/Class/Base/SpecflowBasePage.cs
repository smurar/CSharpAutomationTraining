using TechTalk.SpecFlow;
using TestProject.Resources.Reports;
using TestProject.Resources.Class;

namespace TestProject.Course3
{
    [Binding]
    public class SpecflowBasePage : Driver
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
            ConfigureDriver();
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
