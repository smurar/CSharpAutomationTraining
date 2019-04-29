using NUnit.Framework;
using TestProject.Course2.Base;

namespace TestProject.Course2.Tests.HomePage
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
                .CheckEmptyLogInError();
        }

        [Test]
        public void InvalidEmailFormatErrorMessage()
        {
            GoToHomePage()
                .EnterLogInUser("testUser")
                .ClickLogInButton()
                .CheckEmailFieldError("Email address format is not valid");
        }

        [Test]
        public void InvalidEmailOrPasswordErrorMessage()
        {
            GoToHomePage()
                .EnterInvalidLogInCredentials()
                .ClickLogInButton()
                .CheckPasswrodFieldError("Invalid password/email");
        }

        [Test]
        public void SuccessfulLogIn()
        {      
            GoToHomePage()
                .GoToDashboarPage()
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
