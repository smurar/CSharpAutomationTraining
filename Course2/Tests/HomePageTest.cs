using Course2.BrowserFactory;
using Course2.PageObjects;
using Course2.Reports;
using Course2.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    class HomePageTest:BaseTest
    {
        [Test]
        public void HeaderImageTest()
        {
            GoToHomePage()
                .CheckHeaderImage();
        }

        [Test]
        public void PageTitleTest()
        {
            GoToHomePage()
                .CheckPageTitle(DataHomePage.Title);
        }

        [Test]
        public void HeaderLinksTest()
        {
           
            GoToHomePage()
                .CheckHomePageLink()
                .CheckWikiPageLink();
        }

        [Test]
        public void HeadingTitleTest()
        {
            GoToHomePage()
                .CheckHeadingTitle(DataHomePage.HeadingTitle);
        }

        [Test]
        public void DefaultEmailPasswordTest()
        {
            GoToHomePage()
                .CheckDefaultEmail(DataHomePage.DefaultEmailText)
                .CheckDefaultPassword(DataHomePage.DefaultPasswordText);
        }

        [Test]
        public void LoginDisplayTest()
        {
            GoToHomePage()
                .CheckLoginFieldsAreDisplayed();
        }

        [Test]
        public void EmailValidationsTest()
        {
            GoToHomePage()
                .ClickLogin<HomePage>()
                .CheckNullEmailValidationText(DataHomePage.NullEmailValidationText)
                .FillInEmail(DataHomePage.InvalidEmail)
                .ClickLogin<HomePage>()
                .CheckFormatEmailValidationText(DataHomePage.FormatEmailValidationText);
        }

        [Test]
        public void PasswordValidationTest()
        {
            GoToHomePage()
                .FillInEmail(DataHomePage.InvalidEmail)
                .FillInPassword(DataHomePage.InvalidPassword)
                .ClickLogin<HomePage>()
                .CheckInvalidPasswordValidationMessage(DataHomePage.PasswordValidationText);
        }

        [Test]
        public void SuccessfullyLoginTest()
        {
            GoToHomePage()
                .FillInEmail(DataHomePage.ValidEmail)
                .FillInPassword(DataHomePage.ValidPassword)
                .ClickLogin<DashboardPage>()
                
                .CheckPageTitle(DataDashboardPage.Title);
        }

        [Test]
        public void WikiPageTest()
        {
            GoToHomePage()
                .GoToWikiPage()
                .CheckPageTitle(DataWikiPage.Title);
        }

    }
}
