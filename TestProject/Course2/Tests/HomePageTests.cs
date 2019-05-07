using NUnit.Framework;
using TestProject.Course2.Base;
using TestProject.Course2.Resources.Resx;

namespace TestProject.Course2.HomePageTests
{
    class HomePageTests : BasePage
    {
        [Test]
        public void HeaderItemsDisplayed()
        {
            GoToHomePage()
                .CheckPageHeaderElements();
        }

        [Test]
        public void PageTitleOk()
        {
            GoToHomePage()
                .CheckPageTitle();
        }

        [Test]
        public void PageHeadlingTitleOk()
        {
            GoToHomePage()
                .CheckHeadlingTitle();
        }

        [Test]
        public void DefaultLogInDetailsDisplayed()
        {
            GoToHomePage()
                .CheckDefaultLogInCredentials();
        }

        [Test]
        public void LogInFieldsDisplayed()
        {
            GoToHomePage()
                .CheckLogInFields();
        }

        [Test]
        public void MissingLogInDetailsErrorMessage()
        {
            GoToHomePage()
                .ClickLogInButton()
                .ChecLogInWithEmptyCredentialsError();
        }

        [Test]
        public void InvalidEmailFormatErrorMessage()
        {
            GoToHomePage()
                .EnterUser(HomePageResx.InvalidUser)
                .ClickLogInButton()
                .CheckEmailFieldError(HomePageResx.EmailFormatError);
        }

        [Test]
        public void InvalidEmailOrPasswordErrorMessage()
        {
            GoToHomePage()
                .EnterInvalidLogInCredentials()
                .ClickLogInButton()
                .CheckPasswrodFieldError(HomePageResx.InvalidPasswordEmailError);
        }

        [Test]
        public void SuccessfulLogIn()
        {      
            GoToHomePage()
                .LogInSuccesful()
                .CheckPageTitle();
        }

        [Test]
        public void SuccesfulNavigateToWikiPage()
        {
            GoToHomePage()
                .GoToWikiPage()
                .CheckPageTitle();
        }

        [Test]
        public void FooterLinksAreDisplayed()
        {
            GoToHomePage()
                .CheckFooterElements();
        }
    }
}
