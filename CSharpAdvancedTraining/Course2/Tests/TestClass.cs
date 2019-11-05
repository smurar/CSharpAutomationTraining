using CSharpAdvancedTraining.Course2.Helpers;
using NUnit.Framework;

namespace CSharpAdvancedTraining.Course2.Tests
{
	public class TestClass : BaseTest
	{

		[Test]
		[Category("homepagetests")]
		[Property("Severity", "P1")]
		public void HomePageHeaderLinksAndImageAreDisplayedTest()
		{
			GoToHomepage().CheckHomePageLinkIsDisplayed()
						  .CheckWikipediaLinkIsDisplayed()
						  .CheckImageIsDisplayed();
			Reporter.LogScreenShot("screenshot test 'HomePageHeaderLinksAndImageAreDisplayed'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("homepagetests")]
		public void HomePageHeadingTitleIsCorrectTest()
		{
			GoToHomepage().CheckPageHeadingTitle(MyResource.HomePageHeadingTitle);
			Reporter.LogScreenShot("screenshot test 'HomePageHeadingTitleIsCorrect'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("homepagetests")]
		[Property("Severity", "P2")]
		public void DefaultEmailAndPasswordLabelChecksTest()
		{
			GoToHomepage().CheckDefaultEmailLabelText(MyResource.EmailLabelText)
						  .CheckDefaultPasswordLabelText(MyResource.PasswordLabelText);
			Reporter.LogScreenShot("screenshot test 'DefaultEmailAndPasswordLabelChecks'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("homepagetests")]
		public void LoginFieldsAreDisplayedTest()
		{
			GoToHomepage().CheckEmailFieldIsDisplayed()
						  .CheckPasswordFieldIsDisplayed();
			Reporter.LogScreenShot("screenshot test 'LoginFieldsAreDisplayed'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("homepagetests")]
		public void EmptyEmailAddressErrorMessageTest()
		{
			GoToHomepage().ClickLoginButtonWithError()
						  .CheckEmailErrorMesssage(MyResource.EmptyEmailErrorMessage);
			Reporter.LogScreenShot("screenshot test 'EmailAddressErrorMessage'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("homepagetests")]
		public void EmailAddressNotValidTest()
		{
			GoToHomepage().FillInEmail(MyResource.InvalidEmailAddress)
						  .ClickLoginButtonWithError()
						  .CheckEmailErrorMesssage(MyResource.InvalidEmailErrorMessage);
			Reporter.LogScreenShot("screenshot test 'EmailAddressNotValid'", ImageHelper.CaptureScreen(WebDriver));
		}


		[Test]
		[Category("homepagetests")]
		public void EmailAddressOrPasswordNotValidTest()
		{
			GoToHomepage().FillInEmail(MyResource.Email)
						  .FillInPassword(MyResource.InvalidPassword)
						  .ClickLoginButtonWithError()
						  .CheckPasswordErrorMesssage(MyResource.InvalidEmailOrPasswErrrorMsg);
			Reporter.LogScreenShot("screenshot test 'EmailAddressOrPasswordNotValid'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("smoke")]
		public void LoginSuccessfulTest()
		{
			GoToHomepage().FillInEmail(MyResource.Email)
						 .FillInPassword(MyResource.Password)
						 .ClickLoginButton()
						 .CheckPageTitle(MyResource.DashboardPageTitle);
			Reporter.LogScreenShot("screenshot test 'LoginSuccessful'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("dashboardpagetests")]
		public void NavigateToWikiPageTest()
		{
			GoToHomepage().LoginWithSuccess(MyResource.Email, MyResource.Password)
						  .ClickWikiPageLink()
						  .CheckLandingPageTitle(MyResource.WikipageTitle);
			Reporter.LogScreenShot("screenshot test 'NavigateToWikiPage'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("homepagetests")]
		public void HomePageFooterLinksAreDisplayedTest()
		{
			GoToHomepage().CheckFooterHomeLinkIsDisplayed()
						  .CheckFooterWikipageLinkIsDisplayed()
						  .CheckFooterContactLinkIsDisplayed();
			Reporter.LogScreenShot("screenshot test 'HomePageFooterLinksAreDisplayed'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("dashboardpagetests")]
		public void DashboardHeaderLinksAndImageTest()
		{
			GoToHomepage().LoginWithSuccess(MyResource.Email, MyResource.Password)
						  .CheckHomeLinkIsDisplayed()
						  .CheckWikipageLinkIsDisplayed()
						  .CheckImageIsDisplayed();
			Reporter.LogScreenShot("screenshot test 'DashboardHeaderLinksAndImage'", ImageHelper.CaptureScreen(WebDriver));
		}


		[Test]
		[Category("smoke")]
		public void LogoutTest()
		{
			GoToHomepage().LoginWithSuccess(MyResource.Email, MyResource.Password)
						  .CheckPageTitle(MyResource.DashboardPageTitle)
						  .ClickLogoutButton()
						  .CheckPasswordFieldIsDisplayed();
			Reporter.LogScreenShot("screenshot test 'Logout with sucess'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("dashboardpagetests")]
		public void DashboardFooterLinksTest()
		{
			GoToHomepage().LoginWithSuccess(MyResource.Email, MyResource.Password)
						  .CheckHomeLinkIsDisplayed()
						  .CheckWikipageLinkIsDisplayed()
						  .CheckImageIsDisplayed();
			Reporter.LogScreenShot("screenshot test 'DashboardFooterLinks'", ImageHelper.CaptureScreen(WebDriver));
		}

		[Test]
		[Category("dashboardpagetests")]
		public void EditUserInfoTest()
		{
			GoToHomepage().LoginWithSuccess(MyResource.Email, MyResource.Password)
						  .FillInFirstNameInput(MyResource.FirstNameValue)
						  .FillInLastNameInput(MyResource.LastNameValue)
						  .ClickSaveButton()
						  .CheckDetailsSavedMessage(MyResource.DetailsSavedMessage);
		}
	}
}
