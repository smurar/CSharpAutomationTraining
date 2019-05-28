using System.Threading;
using Course1.Data;
using NUnit.Framework;

namespace Course1.Course2.Tests
{
    [TestFixture]
    public class DashboardTests : BaseTest
    {
        [Test]
        public void DashboardTitleIsCorrectTest()
        {
            GoToHomePage()
               .FillInEmail(UserData.Email)
               .FillInPassword(UserData.Password)
               .ClickLogin()
               .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            GoToHomePage()
               .FillInEmail(UserData.Email)
               .FillInPassword(UserData.Password)
               .ClickLogin()
               .CheckHeaderImageIsDisplayed(true)
               .CheckHomeHeaderLinkIsDisplayed(true)
               .CheckWikiPageHeaderLinkIsDisplayed(true);
        }

        [Test]
        public void FooterLinksAreDisplayedTest()
        {
            GoToHomePage()
               .FillInEmail(UserData.Email)
               .FillInPassword(UserData.Password)
               .ClickLogin()
               .CheckHomeFooterLinkIsDisplayed(true)
               .CheckWikiPageFooterLinkIsDisplayed(true)
               .CheckFooterContactNALinkIsDisplayed(true);
        }

        [Test]
        public void LogoutTest()
        {
            var dashboardPage = GoToHomePage()
               .FillInEmail(UserData.Email)
               .FillInPassword(UserData.Password)
               .ClickLogin()
               .CheckPageTitle(Data.Pages.DashboardPage);

            Thread.Sleep(3000);//will be replaced with wait method

            dashboardPage
               .ClickLogout()
               .CheckPageTitle(Data.Pages.HomePage);
        }

        [Test]
        public void UserEditInfoTest()
        {
            var dashboardPage = GoToHomePage()
               .FillInEmail(UserData.Email)
               .FillInPassword(UserData.Password)
               .ClickLogin();

            Thread.Sleep(3000);//will be replaced with wait method

            dashboardPage
               .ClickFemaleRadioButton()
               .ClickBikeRadioButton()
               .ClickCarRadioButton();
        }
    }
}