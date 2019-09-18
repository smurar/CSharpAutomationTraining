using System.Threading;
using Course1.Course2.Pages;
using Course1.Data;
using NUnit.Framework;

namespace Course1.Course2.Tests
{
    [TestFixture]
    public class DashboardTests : TestBase
    {

        [Test]
        [Category("Dashboard")]
        [Property("Severity", "P2")]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            GoToHomePage()
               .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
               .CheckHeaderImageIsDisplayed(true)
               .CheckHomeHeaderLinkIsDisplayed(true)
               .CheckWikiPageHeaderLinkIsDisplayed(true);
        }

        [Test]
        [Category("Dashboard")]
        [Property("Severity", "P2")]
        public void PageTitleIsCorrectLinkTest()
        {
            GoToHomePage()
               .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
               .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        [Category("Dashboard")]
        [Property("Severity", "P2")]
        public void FooterLinksAreDisplayedTest()
        {
            GoToHomePage()
               .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
               .CheckHomeFooterLinkIsDisplayed(true)
               .CheckWikiPageFooterLinkIsDisplayed(true)
               .CheckFooterContactNALinkIsDisplayed(true);
        }

        [Test]
        [Category("Dashboard")]
        [Property("Severity", "P1")]
        public void LogoutTest()
        {
            GoToHomePage()
               .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
               .CheckPageTitle(Data.Pages.DashboardPage)
               .ClickLogoutButton()
               .CheckPageTitle(Data.Pages.HomePage);
        }

        [Test]
        [Category("Dashboard")]
        [Property("Severity", "P2")]
        public void UserEditInfoTest()
        {
            GoToHomePage()
               .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
               .ClickFemaleRadioButton()
               .ClickBikeRadioButton()
               .ClickCarRadioButton()
               .ClickSaveButton();
        }
    }
}