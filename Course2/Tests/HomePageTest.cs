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
        [Category("ItemsVisibilityTests")]
        public void HeaderImageTest()
        {
            GoToHomePage()
                .CheckHeaderImage();
        }

        
        [Test]
        [Category("ItemsVisibilityTests")]
        public void PageTitleTest()
        {
            GoToHomePage()
                .CheckPageTitle(DataHomePage.Title);
        }

        
        [Test]
        [Category("ItemsVisibilityTests")]
        public void HeaderLinksTest()
        {
           
            GoToHomePage()
                .CheckHomePageLink()
                .CheckWikiPageLink();
        }

        
        [Test]
        [Category("ItemsVisibilityTests")]
        public void HeadingTitleTest()
        {
            GoToHomePage()
                .CheckHeadingTitle(DataHomePage.HeadingTitle);
        }

        
        [Test]
        [Category("ItemsVisibilityTests")]
        public void DefaultEmailPasswordTest()
        {
            GoToHomePage()
                .CheckDefaultEmail(DataHomePage.DefaultEmailText)
                .CheckDefaultPassword(DataHomePage.DefaultPasswordText);
        }

        
        [Test]
        [Category("ItemsVisibilityTests")]
        public void LoginDisplayTest()
        {
            GoToHomePage()
                .CheckLoginFieldsAreDisplayed();
        }

        
        [Test]
        [Category("ValidationTests")]
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
        [Category("ValidationTests")]
        public void PasswordValidationTest()
        {
            GoToHomePage()
                .FillInEmail(DataHomePage.InvalidEmail)
                .FillInPassword(DataHomePage.InvalidPassword)
                .ClickLogin<HomePage>()
                .CheckInvalidPasswordValidationMessage(DataHomePage.PasswordValidationText);
        }

        
        [Test]
        [Category("WorkflowTests")]
        [Property("Severity", "P1")]
        public void SuccessfullyLoginTest()
        {
            GoToHomePage()
                .FillInEmail(DataHomePage.ValidEmail)
                .FillInPassword(DataHomePage.ValidPassword)
                .ClickLogin<DashboardPage>()
                
                .CheckPageTitle(DataDashboardPage.Title);
        }

        
        [Test]
        [Category("WorkflowTests")]
        public void WikiPageTest()
        {
            GoToHomePage()
                .GoToWikiPage()
                .CheckPageTitle(DataWikiPage.Title);
        }

    }
}
