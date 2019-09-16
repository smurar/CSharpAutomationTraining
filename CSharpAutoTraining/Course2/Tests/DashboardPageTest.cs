using CSharpAutoTraining.Course2.PageObjects;
using CSharpAutoTraining.Properties;
using NUnit.Framework;
using System;

namespace CSharpAutoTraining.Course2.Tests
{
    public class DashboardPageTest : BaseTest
    {
        [Test, Order(1)]
        public void TestHeaderLinksAndImageAreDisplayed()
        {
            HomePage page = GoToHomePage();

            Assert.True(page.HeaderImageIsDisplayed());
            Assert.True(page.HeaderLinksAreAllDisplayed());
        }

        [Test, Order(2)]
        public void TestDashboardTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardTitle, GoToDashboardPage().GetPageTitle());
        }

        [Test, Order(3)]
        public void TestPageHeadingTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardPageHeadingTitle, GoToDashboardPage().GetPageHeadingTitle());
        }

        [Test, Order(4)]
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
        public void TestFooterLinksAreDisplayed()
        {
            DashboardPage page = GoToDashboardPage();

            Assert.True(page.FooterLinksAreDisplayed());
        }

        [Test, Order(6)]
        public void LogoutRedirect()
        {
            Assert.AreEqual(
                System.Configuration.ConfigurationManager.AppSettings[DataHomePage.HomepageURL],
                GoToDashboardPage().Logout()
            );
        }
    }
}
