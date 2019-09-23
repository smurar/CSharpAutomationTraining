using Course1.Course2;
using Course1.Course2.Pages;
using Course1.Data;
using NUnit.Framework;

namespace Course1.Course4
{
    public class SelenimCourse4Tests : TestBase
    {
        [Test]
        public void Course4SeleniumTest()
        {
            Reporter.LogInfo("Testing negative case for login");
            GoToHomePage()
            .CheckPageTitle(Data.Pages.DashboardPage)
            .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.EmptyPassword);
            Reporter.LogScreenshot("screenshot", ImageHelper.CaptureScreen(WebDriver));
        }
    }
}