using CSharpAutoTraining.Course2.PageObjects;
using CSharpAutoTraining.Properties;
using NUnit.Framework;
using System;

namespace CSharpAutoTraining.Course2.Tests
{
    public class DashboardPageTest : BaseTest
    {
        [Test, Order(1)]
        [Category("Dev")]
        [Category("Prod")]
        public void TestHeaderLinksAndImageAreDisplayed()
        {
            HomePage page = GoToHomePage();

            Assert.True(page.HeaderImageIsDisplayed());
            Assert.True(page.HeaderLinksAreAllDisplayed());
        }

        [Test, Order(2)]
        [Category("Dev")]
        public void TestDashboardTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardTitle, GoToDashboardPage().GetPageTitle());
        }

        [Test, Order(3)]
        [Category("Prod")]
        public void TestPageHeadingTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardPageHeadingTitle, GoToDashboardPage().GetPageHeadingTitle());
        }

        [Test, Order(4)]
        [Category("Dev")]
        public void TestDetailsSaved()
        {
            DashboardPage page = GoToDashboardPage();
            page.SaveForm();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Assert.AreEqual(
                DataDashboardPage.DetailsSavedMessage,
                page.GetDetailsMessageText()
            );
        }

        [Test, Order(5)]
        [Category("Prod")]
        public void TestFooterLinksAreDisplayed()
        {
            DashboardPage page = GoToDashboardPage();

            Assert.True(page.FooterLinksAreDisplayed());
        }

        [Test, Order(6)]
        [Category("Dev")]
        public void LogoutRedirect()
        {
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings[DataHomePage.HomepageURL],
                GoToDashboardPage().Logout()
            );
        }
    }
}
