using CSharpAdvancedTraining.Course2;
using CSharpAdvancedTraining.Course2.Pages;
using TechTalk.SpecFlow;

namespace CSharpAdvancedTraining
{
	[Binding]
	public class HomePageTestsSteps
	{
		private HomePage homePage;
		private DashboardPage dashboardPage;

		[Given(@"I am on the homepage")]
		public void GivenIAmOnTheHomepage()
		{
			homePage = new HomePage(TestBaseBDD.WebDriver);
		}

		[Then(@"the homepage link is displayed")]
		public void ThenTheHomepageLinkIsDisplayed()
		{
			homePage.CheckHomePageLinkIsDisplayed();
		}



		[Then(@"the wikipedia link is displayed")]
		public void ThenTheWikipediaLinkIsDisplayed()
		{
			homePage.CheckWikipediaLinkIsDisplayed();
		}

		[Then(@"the image is displayed")]
		public void ThenTheImageIsDisplayed()
		{
			homePage.CheckImageIsDisplayed();
		}

		[Then(@"the expected title is '(.*)'")]
		public void ThenTheExpectedTitleIs(string p0)
		{
			homePage.CheckPageHeadingTitle(p0);
		}

		[Then(@"the default email label text is '(.*)'")]
		public void ThenTheDefaultEmailLabelTextIs(string p0)
		{
			homePage.CheckDefaultEmailLabelText(p0);
		}

		[Then(@"default password label text is '(.*)'")]
		public void ThenDefaultPasswordLabelTextIs(string p0)
		{
			homePage.CheckDefaultPasswordLabelText(p0);
		}

		[Then(@"email field is displayed")]
		public void ThenEmailFieldIsDisplayed()
		{
			homePage.CheckEmailFieldIsDisplayed();
		}

		[Then(@"password field is displayed")]
		public void ThenPasswordFieldIsDisplayed()
		{
			homePage.CheckPasswordFieldIsDisplayed();
		}

		[Given(@"I click login button leaving email field empty")]
		public void GivenIClickLoginButtonLeavingEmailFieldEmpty()
		{
			homePage.ClickLogin<HomePage>();
		}

		[Then(@"'(.*)' message is displayed above the email field")]
		public void ThenTBeNullMessageIsDisplayedAboveTheEmailField(string p0)
		{
			homePage.CheckEmailErrorMesssage(p0);
		}

		[When(@"I type '(.*)' in the email textbox")]
		public void WhenITypeInTheEmailTextbox(string p0)
		{
			homePage.FillInEmail(p0);
		}

		[When(@"I click login button")]
		public void WhenIClickLoginButton()
		{
			homePage.ClickLogin<HomePage>();
		}

		[Then(@"'(.*)' is displayed above the email textbox")]
		public void ThenIsDisplayedAboveTheEmailTextbox(string p0)
		{
			homePage.CheckEmailErrorMesssage(p0);
		}

		[When(@"I type '(.*)' in the password textbox")]
		public void WhenITypeInThePasswordTextbox(int p0)
		{
			homePage.FillInPassword(p0.ToString());
		}

		[When(@"I click login button successfully")]
		public void WhenIClickLoginButtonSuccessfully()
		{
		 homePage.ClickLogin<DashboardPage>();
		}

		[Then(@"'(.*)' message is displayed above the password textbox")]
		public void ThenMessageIsDisplayedAboveThePasswordTextbox(string p0)
		{
			homePage.CheckPasswordErrorMesssage(p0);
		}

		[Then(@"Dasboard page is displayed with title '(.*)'")]
		public void ThenDasboardPageIsDisplayedWithTitle(string p0)
		{
			dashboardPage = new DashboardPage(TestBaseBDD.WebDriver);
			dashboardPage.CheckPageTitle(p0);
		}

	}
}
