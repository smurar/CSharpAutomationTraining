using CSharpAutoTraining.Course2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2
{
    class DashboardTests : BaseTest
    {
        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void DashboardHeaderImageDisplayed()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Dashboard header image is displayed");
            Assert.IsTrue(dashboard.DashboardHeaderImage.Displayed);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void HomeHeaderLinkDisplayed()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Home header link is displayed");
            Assert.IsTrue(dashboard.HomepageHeaderLink.Displayed);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void WikiPageHeaderLinkDisplayed()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Wiki header link is displayed");
            Assert.IsTrue(dashboard.WikiPageHeaderLink.Displayed);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void DashboardTitleCorrect()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();

            dashboard.CheckDashboardTitle(TestData.ExpectedDashboardPageTitle);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void DashboardHeadingCorrect()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Dashboard heading is correct");
            Assert.AreEqual(TestData.ExpectedDashboardHeading, dashboard.DashboardHeading1.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Medium")]
        public void EditFirstNameSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard()
                     .FillInFirstName(TestData.FirstNameData)
                     .ClickSaveDetailsButton();
            Reporter.LogInfo("Check if first name is saved successfully");
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Medium")]
        public void EditLastNameSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard()
                     .FillInLastName(TestData.LastNameData)
                     .ClickSaveDetailsButton();
            Reporter.LogInfo("Check if last name is saved successfully");
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Medium")]
        public void EditFemaleRadioButtonSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard()
                     .SelectFemaleButton()
                     .ClickSaveDetailsButton();
            Reporter.LogInfo("Check if Female radio button state is saved successfully");
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Medium")]
        public void EditMaleRadioButtonSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard()
                     .SelectMaleButton()
                     .ClickSaveDetailsButton();
            Reporter.LogInfo("Check if Male radio button state is saved successfully");
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Medium")]
        public void EditBikeButtonSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard()
                     .SelectBikeButton()
                     .ClickSaveDetailsButton();
            Reporter.LogInfo("Check if Bike button state is saved successfully");
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Medium")]
        public void EditCarButtonSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard()
                     .SelectCarButton()
                     .ClickSaveDetailsButton();
            Reporter.LogInfo("Check if Car button state is saved successfully");
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "High")]
        public void UserLogoutSuccessfully()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            var home = dashboard.GoToDashboard()
                                .ClickLogoutButton()
                                .LogoutRedirectToHomepage();
            Reporter.LogInfo("Check if logout is successful and Redirect to Homepage");
            home.CheckHomepageTitle(TestData.ExpectedHomepageTitle);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void HomeFooterLinkDisplayed()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Home footer link is displayed");
            Assert.IsTrue(dashboard.HomeFooterLink.Displayed);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void WikiFooterLinkDisplayed()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Wiki footer link is displayed");
            Assert.IsTrue(dashboard.WikiFooterLink.Displayed);
        }


        [Test]
        [Category("Dashboard")]
        [Property("Prio", "Low")]
        public void ContactsFooterLinkDisplayed()
        {
            Dashboard dashboard = new Dashboard(WebDriver);

            dashboard.GoToDashboard();
            Reporter.LogInfo("Check if Contacts footer link is displayed");
            Assert.IsTrue(dashboard.ContactsFooterLink.Displayed);
        }


    }
}
