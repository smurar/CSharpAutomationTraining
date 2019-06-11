using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Course2;
using ClassLibrary2.Course2.Pages;
using TechTalk.SpecFlow;

namespace ClassLibrary2.Course33.Steps
{
	[Binding]
	public class DasboardPageSteps
	{

		private HomePage homePage;
		private DashboardPage dashboardPage;
		private WikiPage wikipage;

		[When(@"I login with success using  email '(.*)' and password '(.*)'")]
		public void WhenILoginWithSuccessUsingEmailAndPassword(string p0, int p1)
		{
			homePage = new HomePage(TestBaseBDD.WebDriver);
			dashboardPage = homePage.LoginWithSuccess(p0, p1.ToString());
		}

		[When(@"I click on Wikipage link")]
		public void WhenIClickOnWikipageLink()
		{
			dashboardPage = new DashboardPage(TestBaseBDD.WebDriver);
			var wikipage = dashboardPage.ClickWikiPageLink();

		}

		[Then(@"landing page with title '(.*)' is displayed")]
		public void ThenLandingPageWithTitleIsDisplayed(string p0)
		{
			wikipage = new WikiPage(TestBaseBDD.WebDriver);
			wikipage.CheckLandingPageTitle(p0);
		}

		[When(@"I click logout button")]
		public void WhenIClickLogoutButton()
		{
			dashboardPage = new DashboardPage(TestBaseBDD.WebDriver);
			homePage = dashboardPage.ClickLogoutButton();
		}

		[Then(@"footer home link is displayed")]
		public void ThenFooterHomeLinkIsDisplayed()
		{
			dashboardPage = new DashboardPage(TestBaseBDD.WebDriver);
			dashboardPage.CheckHomeLinkIsDisplayed();
		}

		[Then(@"footer wikipage link is displayed")]
		public void ThenFooterWikipageLinkIsDisplayed()
		{
			dashboardPage.CheckFooterWikipageLinkIsDisplayed();
		}

		[Then(@"dashboard image is displayed")]
		public void ThenDashboardImageIsDisplayed()
		{
			dashboardPage.CheckImageIsDisplayed();
		}


		[When(@"I update firstname with value '(.*)'")]
		public void WhenIUpdateFirstnameWithValue(string p0)
		{
			dashboardPage.FillInFirstNameInput(p0);
		}

		[When(@"I update lastname with value '(.*)'")]
		public void WhenIUpdateLastnameWithValue(string p0)
		{
			dashboardPage.FillInLastNameInput(p0);
		}

		[When(@"I click save button")]
		public void WhenIClickSaveButton()
		{
			dashboardPage.ClickSaveButton();
		}

		[Then(@"on Dashboard page message '(.*)' is displayed")]
		public void ThenOnDashboardPageMessageIsDisplayed(string p0)
		{
			dashboardPage.CheckDetailsSavedMessage(p0);
		}


	}
}
