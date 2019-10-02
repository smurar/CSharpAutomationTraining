using System;
using TechTalk.SpecFlow;
using CSharpAutoTraining.Course3.PageObjects;
using NUnit.Framework;


namespace CSharpAutoTraining.Course3.TestSteps
{
    [Binding]
    public class DashboardTestsSteps
    {
        private Dashboard dashboard;
        private HomePage homepage;

        [Given(@"I am on dashboard Page")]
        public void GivenIAmOnDashboardPage()
        {
            dashboard = new Dashboard(WebDriverClass.WebDriver);
            dashboard.GoToDashboard();
        }
        
        [Then(@"The Dashboard Header image is displayed")]
        public void ThenTheDashboardHeaderImageIsDisplayed()
        {
            Assert.IsTrue(dashboard.DashboardHeaderImage.Displayed);
            
        }

        [Then(@"The Home Header image is displayed")]
        public void ThenTheHomeHeaderImageIsDisplayed()
        {
            Assert.IsTrue(dashboard.HomepageHeaderLink.Displayed);
        }

        [Then(@"The Wiki Header image is displayed")]
        public void ThenTheWikiHeaderImageIsDisplayed()
        {
            Assert.IsTrue(dashboard.WikiPageHeaderLink.Displayed);
        }

        [Then(@"The Dashboard Title is correct")]
        public void ThenTheDashboardTitleIsCorrect()
        {
            dashboard.CheckDashboardTitle(TestData.ExpectedDashboardPageTitle);
        }

        [Then(@"The Dashboard Heading is correct")]
        public void ThenTheDashboardHeadingIsCorrect()
        {
            Assert.AreEqual(TestData.ExpectedDashboardHeading, dashboard.DashboardHeading1.Text);
        }

        [When(@"I fill in first name")]
        public void WhenIFillInFirstName()
        {
            dashboard.FillInFirstName(TestData.FirstNameData);
        }

        [When(@"I click on Save Details button")]
        public void WhenIClickOnSaveDetailsButton()
        {
            dashboard.ClickSaveDetailsButton();
        }

        [Then(@"First name is saved")]
        public void ThenFirstNameIsSaved()
        {
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }

        [Then(@"Last name is saved")]
        public void ThenLastNameIsSaved()
        {
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }

        [When(@"I click on Female button")]
        public void WhenIClickOnFemaleButton()
        {
            dashboard.SelectFemaleButton();
        }

        [Then(@"Female button is selected")]
        public void ThenFemaleButtonIsSelected()
        {
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }
        [When(@"I click on Male button")]
        public void WhenIClickOnMaleButton()
        {
            dashboard.SelectMaleButton();
        }

        [Then(@"Male button is selected")]
        public void ThenMaleButtonIsSelected()
        {
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }

        [When(@"I click on Bike button")]
        public void WhenIClickOnBikeButton()
        {
            dashboard.SelectBikeButton();
        }

        [Then(@"Bike button is selected")]
        public void ThenBikeButtonIsSelected()
        {
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }

        [When(@"I click on Car button")]
        public void WhenIClickOnCarButton()
        {
            dashboard.SelectCarButton();
        }

        [Then(@"Car button is selected")]
        public void ThenCarButtonIsSelected()
        {
            Assert.IsTrue(dashboard.DetailsSavedMessage.Displayed);
            Assert.AreEqual(TestData.ExpectedDetailsSavedMessage, dashboard.DetailsSavedMessage.Text);
        }

        [Given(@"I am logged in with a valid user")]
        public void GivenIAmLoggedInWithAValidUser()
        {
            homepage = new HomePage(WebDriverClass.WebDriver);
            homepage.GoToHomepage()
                    .FillInEmail(TestData.ValidEmail)
                    .FillInPassword(TestData.ValidPassword)
                    .ClickLoginButton();
        }

        [When(@"I click the Logout button")]
        public void WhenIClickTheLogoutButton()
        {
            dashboard = homepage.LoginRedirectToDashboard();
            dashboard.ClickLogoutButton();
        }

        [Then(@"I am logged out successfully")]
        public void ThenIAmLoggedOutSuccessfully()
        {
            var homeredirect = dashboard.LogoutRedirectToHomepage();
            homeredirect.CheckHomepageTitle(TestData.ExpectedHomepageTitle);
        }

        [Then(@"Home footer link is displayed on dashboard")]
        public void ThenHomeFooterLinkIsDisplayedOnDashboard()
        {
            Assert.IsTrue(dashboard.HomeFooterLink.Displayed);
        }

        [Then(@"Wiki footer link is displayed on dashboard")]
        public void ThenWikiFooterLinkIsDisplayedOnDashboard()
        {
            Assert.IsTrue(dashboard.WikiFooterLink.Displayed);
        }

        [Then(@"Contact footer link is displayed on dashboard")]
        public void ThenContactFooterLinkIsDisplayedOnDashboard()
        {
            Assert.IsTrue(dashboard.ContactsFooterLink.Displayed);
        }

    }
}
