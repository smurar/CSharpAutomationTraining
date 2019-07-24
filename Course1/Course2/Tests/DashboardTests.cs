using System.Threading;
using Course1.Data;
using NUnit.Framework;

namespace Course1.Course2.Tests
{
    [TestFixture]
    public class DashboardTests : TestBase
    {
        [Test]
        public void DashboardTitleIsCorrectTest()
        {
            GoToHomePage()
               .Login(UserData.Email, UserData.Password)
               .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            GoToHomePage()
               .Login(UserData.Email, UserData.Password)
               .CheckHeaderImageIsDisplayed(true)
               .CheckHomeHeaderLinkIsDisplayed(true)
               .CheckWikiPageHeaderLinkIsDisplayed(true);
        }

        [Test]
        public void FooterLinksAreDisplayedTest()
        {
            GoToHomePage()
               .Login(UserData.Email, UserData.Password)
               .CheckHomeFooterLinkIsDisplayed(true)
               .CheckWikiPageFooterLinkIsDisplayed(true)
               .CheckFooterContactNALinkIsDisplayed(true);
        }

        [Test]
        public void LogoutTest()
        {
            GoToHomePage()
               .Login(UserData.Email, UserData.Password)
               .CheckPageTitle(Data.Pages.DashboardPage)
               .ClickLogoutButton()
               .CheckPageTitle(Data.Pages.HomePage);
        }

        [Test]
        public void UserEditInfoTest()
        {
            GoToHomePage()
               .Login(UserData.Email, UserData.Password)
               .ClickFemaleRadioButton()
               .ClickBikeRadioButton()
               .ClickCarRadioButton()
               .ClickSaveButton();
        }
    }
}