using Course1.Course2.Pages;
using Course1.Data;
using NUnit.Framework;

namespace Course1.Course2.Tests
{
    [TestFixture]
    public class HomePageTests : TestBase
    {
        [Test]
        public void HeaderLinksAndImageAreDisplayedTest()
        {
            GoToHomePage()
                .CheckHomeHeaderLinkIsDisplayed(true)
                .CheckWikiPageHeaderLinkIsDisplayed(true)
                .CheckHeaderImageIsDisplayed(true);
        }

        [Test]
        public void HomePageTitleIsCorrectTest()
        {
            GoToHomePage()
                .CheckPageTitle(Data.Pages.HomePage);
        }

        [Test]
        public void PageHeadingTitleH1IsCorrectTest()
        {
            GoToHomePage()
                .CheckPageHeadingTitle(Titles.HtmlHomePageTitle);
        }

        [Test]
        public void DefaultEmailAndPasswordTextIsCorrectTest()
        {
            GoToHomePage()
                .DefaultLoginInfo("Default email: admin@domain.org")
                .DefaultLoginInfo("Default password: 111111")
                .FillInCredentialsAndLogin<DashboardPage>(UserData.Email, UserData.Password)
                .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        public void LoginFieldsAreDisplayedTest()
        {
            GoToHomePage()
                .CheckEmailTextFieldIsDisplayed(true)
                .CheckPasswordTextFiekdIsDisplayed(true);
        }

        [Test]
        public void ErrorMessageEmailAddressCanTBeNullIsDisplayedAndContainTheExpectedValues()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<HomePage>("", "")
                .ChecEmailErrorMessage(Messages.NullEmailError);
        }

        [Test]
        public void ErrorMessageEmailAddressFormatIsNotValidIsDisplayedWhenArontCharacterIsNotPresentInTheEmailBodyTest()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<HomePage>(Credentials.WrongEmailFormat, "")
                .ChecEmailErrorMessage(Messages.EmailFormatError);
        }

        [Test]
        public void ErrorMessageInvalidPasswordEmailIsDisplayedWhenEmailAndPasswordAreNotValidTest()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<HomePage>(Credentials.InvalidEmail, Credentials.InvalidPassword)
                .ChecPasswordErrorMessage(Messages.InvalidPasswordEmail);
        }

        [Test]
        public void UserCanLoginWithValidCredetialsAndCheckLandingPageTitleTest()
        {
            GoToHomePage()
                .FillInCredentialsAndLogin<DashboardPage>(Credentials.Email, Credentials.Password)
                .CheckPageTitle(Data.Pages.DashboardPage);
        }

        [Test]
        public void UserCanNavigateToWikiPageAndCheckLandingPageTitleTest()
        {
            GoToHomePage()
                .ClickWikiPageHeaderLink()
                .CheckPageTitle(Data.Pages.WikiPage);
        }
    }
}