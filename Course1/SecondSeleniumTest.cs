using Course1.Course2.Pages;
using Course1.Data;
using NUnit.Framework;

namespace Course1
{
    [TestFixture]
    public class SecondSeleniumTest : TestBase
    {
        [Test]
        public void LoginSeleniumTest()
        {
            GoToHomePage()
                .CheckPageTitle(Pages.HomePage)
                .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password);
        }
    }
}