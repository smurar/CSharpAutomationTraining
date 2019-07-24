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
                .Login(UserData.Email, UserData.Password);
        }
    }
}