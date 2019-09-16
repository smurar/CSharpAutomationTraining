using CSharpAutoTraining.Course2.PageObjects;
using CSharpAutoTraining.Properties;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2.Tests
{
    public class HomePageTest : BaseTest
    {
        //[Test, Order(1)]
        //public void TestHeaderLinksAndImageAreDisplayed()
        //{
        //    GoToHomePage()
        //        .CheckHeaderLinksAreDisplayed()
        //        .CheckHeaderImageIsDisplayed();
        //}

        //[Test, Order(2)]
        //public void TestPageTitleIsCorrect()
        //{
        //    GoToHomePage().CheckPageTitle("Home page");
        //}

        [Test, Order(1)]
        public void TestHeaderLinksAndImageAreDisplayed()
        {
            HomePage page = GoToHomePage();

            Assert.True(page.HeaderImageIsDisplayed());
            Assert.True(page.HeaderLinksAreAllDisplayed());
        }

        [Test, Order(2)]
        public void TestPageTitleIsCorrect()
        {
            // This test uses a resource file, that has a key which holds the title value
            // It is, by all intents and purposes the same as TestPageTitleIsCorrectAgain.
            Assert.AreEqual(DataHomePage.PageTitle, GoToHomePage().GetPageTitle());
        }

        [Test, Order(2)]
        public void TestPageTitleIsCorrectAgain()
        {
            // This test uses a custom static class, that has a field which holds the title value
            // It is, by all intents and purposes the same as TestPageTitleIsCorrect().
            Assert.AreEqual(DataHomePageCustom.HomePageTitle, GoToHomePage().GetPageTitle());
        }

        [Test, Order(3)]
        public void TestHeadingTitleIsCorrect()
        {
            Assert.AreEqual(DataHomePage.HomePageHeadingTitle, GoToHomePage().GetPageHeadingTitle());
        }

        [Test, Order(4)]
        public void TestDefaultEmailIsCorrect()
        {
            Assert.AreEqual(DataHomePage.DefaultEmail, GoToHomePage().GetDefaultEmail());
        }

        [Test, Order(5)]
        public void TestDefaultPasswordIsCorrect()
        {
            Assert.AreEqual(DataHomePage.DefaultPassword, GoToHomePage().GetDefaultPassword());
        }

        [Test, Order(6)]
        public void TestAuthenticationFieldsDisplayed()
        {          
            Assert.True(GoToHomePage().AuthenticationFieldsDisplayed());
        }

        [Test, Order(7)]
        public void TestAuthenticationIsSuccessful()
        {
            HomePage page = GoToHomePage();

            page.Authenticate(DataHomePage.AdminLoginEmail, DataHomePage.AdminLoginPassword);

            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings[DataHomePage.DashboardURL], 
                page.GetUrl()
            );
        }

        [Test, Order(8)]
        public void TestMissingEmailAuthenticationReturnsExpectedError()
        {
            HomePage page = GoToHomePage();

            page.Authenticate(null, DataHomePage.AdminLoginPassword);

            // Check we're still on the same page
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings[DataHomePage.HomepageURL],
                page.GetUrl()
            );

            // Check proper error message is displayed
            Assert.AreEqual(page.GetEmailErrorMessage(), DataHomePage.EmailErrorMessage);
        }

        [Test, Order(9)]
        public void TestInvalidEmailAuthenticationReturnsExpectedError()
        {
            HomePage page = GoToHomePage();

            page.Authenticate(DataHomePage.WrongUsername, DataHomePage.AdminLoginPassword);

            // Check we're still on the same page
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings[DataHomePage.HomepageURL],
                page.GetUrl()
            );

            // Check proper error message is displayed
            Assert.AreEqual(page.GetEmailErrorMessage(), DataHomePage.InvalidEmailFormat);
        }

        [Test, Order(10)]
        public void TestFooterLinksAreDisplayed()
        {
            HomePage page = GoToHomePage();

            Assert.True(page.FooterLinksAreDisplayed());
        }
    }
}
