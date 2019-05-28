using CSharpAutoTraining.Course2.PageObjects;
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
            Assert.AreEqual("Home page", GoToHomePage().GetPageTitle());
        }

        [Test, Order(3)]
        public void TestHeadingTitleIsCorrect()
        {
            Assert.AreEqual("HTML", GoToHomePage().GetPageHeadingTitle());
        }

        [Test, Order(4)]
        public void TestDefaultEmailIsCorrect()
        {
            Assert.AreEqual("Default email: admin@domain.org", GoToHomePage().GetDefaultEmail());
        }

        [Test, Order(5)]
        public void TestDefaultPasswordIsCorrect()
        {
            Assert.AreEqual("Default password: 111111", GoToHomePage().GetDefaultPassword());
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

            page.Authenticate("admin@domain.org", "111111");

            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings["DASHBOARD_PAGE_URL"], 
                page.GetUrl()
            );
        }

        [Test, Order(8)]
        public void TestMissingEmailAuthenticationReturnsExpectedError()
        {
            HomePage page = GoToHomePage();

            page.Authenticate(null, "111111");

            // Check we're still on the same page
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings["HOME_PAGE_URL"],
                page.GetUrl()
            );

            // Check proper error message is displayed
            Assert.AreEqual(page.GetEmailErrorMessage(), "Email address can't be null");
        }

        [Test, Order(9)]
        public void TestInvalidEmailAuthenticationReturnsExpectedError()
        {
            HomePage page = GoToHomePage();

            page.Authenticate("jvngbbfsdxdeu", "111111");

            // Check we're still on the same page
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings["HOME_PAGE_URL"],
                page.GetUrl()
            );

            // Check proper error message is displayed
            Assert.AreEqual(page.GetEmailErrorMessage(), "Email address format is not valid");
        }

        [Test, Order(10)]
        public void TestFooterLinksAreDisplayed()
        {
            HomePage page = GoToHomePage();

            Assert.True(page.FooterLinksAreDisplayed());
        }
    }
}
