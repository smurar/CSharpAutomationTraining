using Course1.Data;
using NUnit.Framework;

namespace Course1
{
    [TestFixture]
    public class SecondSeleniumTest : BaseTest
    {
        [Test]
        public void LoginSeleniumTest()
        {
            GoToHomePage()
                .CheckPageTitle(Pages.HomePage)
                .FillInEmail(UserData.Email)
                .FillInPassword(UserData.Password)
                .ClickLogin();
        }
    }
}