using Course1.Course2.Pages;
using Course1.Data;
using NUnit.Framework;

namespace Course1.Course2.Tests
{
    [TestFixture]
    public class HomePageTests : TestBase
    {
        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            GoToHomePage()
                .CheckHomeHeaderLinkIsDisplayed(true)
                .CheckWikiPageHeaderLinkIsDisplayed(true)
                .CheckHeaderImageIsDisplayed(true);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void HomePageTitleIsCorrectTest()
        {
            GoToHomePage()
                .CheckPageTitle(Data.Pages.HomePage);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void PageHeadingTitleH1IsCorrectTest()
        {
            GoToHomePage()
                .CheckPageHeadingTitle(Titles.HtmlHomePageTitle);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P1")]
        public void DefaultEmailAndPasswordTextIsCorrectTest()
        {
            GoToHomePage()
                .DefaultLoginInfo(Credentials.DefaultEmailText)
                .DefaultLoginInfo(Credentials.DefaultPasswordText)
                .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
                .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P1")]
        public void LoginFieldsAreDisplayedTest()
        {
            GoToHomePage()
                .CheckEmailTextFieldIsDisplayed(true)
                .CheckPasswordTextFiekdIsDisplayed(true);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void ErrorMessageEmailAddressCanTBeNullIsDisplayedAndContainTheExpectedValues()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<HomePage>("", "")
                .ChecEmailErrorMessage(Messages.NullEmailError);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void ErrorMessageEmailAddressFormatIsNotValidIsDisplayedWhenArontCharacterIsNotPresentInTheEmailBodyTest()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<HomePage>(Credentials.WrongEmailFormat, "")
                .ChecEmailErrorMessage(Messages.EmailFormatError);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void ErrorMessageInvalidPasswordEmailIsDisplayedWhenEmailAndPasswordAreNotValidTest()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<HomePage>(Credentials.InvalidEmail, Credentials.InvalidPassword)
                .ChecPasswordErrorMessage(Messages.InvalidPasswordEmail);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void UserCanLoginWithValidCredetialsAndCheckLandingPageTitleTest()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<DashboardPage>(Credentials.Email, Credentials.Password)
                .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void UserCanNavigateToWikiPageAndCheckLandingPageTitleTest()
        {
            GoToHomePage()
                .ClickWikiPageHeaderLink()
                .CheckPageTitle(Data.Pages.WikiPage);
        }

        [Test]
        [Category("HomePage")]
        [Property("Severity", "P2")]
        public void FooterLinksAreDisplayedTest()
        {
            GoToHomePage()
                .CheckHomeFooterLinkIsDisplayed(true)
                .CheckWikiPageFooterLinkIsDisplayed(true)
                .CheckContactFooterLinkIsDisplayed(true);
        }
    }
}