using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
   public class HomePageTests : BaseTest
    {

        [Test]
        public void HomePageTitleTest()
        {
            GoToHomePage()
                .CheckHomeTitle(MyResource.HomeTitle);
        }

        [Test]
        public void HomePageHeaderLinksTest()
        {
            GoToHomePage()
                .CheckHeaderLinks();
        }

        [Test]
        public void HomePageHeadingTitleTest()
        {
            GoToHomePage()
                .CheckHeadingTitle(MyResource.HomeHeading);
        }

        [Test]
        public void DefaultEmailPasswordTextTest()
        {
            GoToHomePage()
                .CheckDefaultEmailPassText(MyResource.DefaultEmail, MyResource.DefaultPassword);
        }

        [Test]
        public void LoginFieldsDisplayedTest()
        {
            GoToHomePage()
                .CheckLoginFields();
        }

        [Test]
        public void FooterLinksDisplayedTest()
        {
            GoToHomePage()
                .CheckFooterLinks(MyResource.FooterHome, MyResource.FooterWiki, MyResource.FooterContact);
        }

        public void NavigateToWikiTest()
        {
            GoToHomePage()
                .GoToWiki(MyResource.WikiTitle);
        }

        [Test]
        public void EmptyEmailErrorTest()
        {
            GoToHomePage()
                .FillInPassword(MyResource.Password, "Password")
                .ClickLoginButton()
                .CheckEmailError(MyResource.EmptyEmailError);
        }

        [Test]
        public void EmailFormatErrorTest()
        {
            GoToHomePage()
                .FillInEmail(MyResource.InvalidEmail, "Email")
                .FillInPassword(MyResource.Password, "Password")
                .ClickLoginButton()
                .CheckEmailError(MyResource.InvalidEmailFormatError);
        }

        [Test]
        public void InvalidLoginDataTest()
        {
            GoToHomePage()
                .FillInEmail(MyResource.Email, "Email")
                .FillInPassword(MyResource.InvalidPassword, "Password")
                .ClickLoginButton()
                .CheckPasswordError(MyResource.InvalidLoginError);
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            GoToHomePage()
                .FillInEmail(MyResource.Email, "Email")
                .FillInPassword(MyResource.Password, "Password")
                .ClickLoginButton()
                .OnDashboard()
                .CheckDashboardTitle(MyResource.DashboardTitle);
        }
    }
}
