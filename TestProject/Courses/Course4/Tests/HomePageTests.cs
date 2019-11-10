using NUnit.Framework;
using TestProject.Resources.Base;
using TestProject.Resources.Resx;

namespace TestProject.Courses.Course4.HomePageTests
{
    class HomePageTests : NUnitBasePage
    {
        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void HeaderItemsDisplayed()
        {
            GoToHomePage()
                .CheckPageHeaderElements();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void PageTitleOk()
        {
            GoToHomePage()
                .CheckPageTitle();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void PageHeadlingTitleOk()
        {
            GoToHomePage()
                .CheckHeadlingTitle();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void DefaultLogInDetailsDisplayed()
        {
            GoToHomePage()
                .CheckDefaultLogInCredentials();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void LogInFieldsDisplayed()
        {
            GoToHomePage()
                .CheckLogInFields();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void MissingLogInDetailsErrorMessage()
        {
            GoToHomePage()
                .ClickLogInButton()
                .ChecLogInWithEmptyCredentialsError();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void InvalidEmailFormatErrorMessage()
        {
            GoToHomePage()
                .EnterUser(HomePageResx.InvalidUser)
                .ClickLogInButton()
                .CheckEmailFieldError(HomePageResx.EmailFormatError);
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void InvalidEmailOrPasswordErrorMessage()
        {
            GoToHomePage()
                .EnterInvalidLogInCredentials()
                .ClickLogInButton()
                .CheckPasswrodFieldError(HomePageResx.InvalidPasswordEmailError);
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void SuccessfulLogIn()
        {      
            GoToHomePage()
                .LogInSuccesful()
                .CheckPageTitle();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void SuccesfulNavigateToWikiPage()
        {
            GoToHomePage()
                .GoToWikiPage()
                .CheckPageTitle();
        }

        [Category("Course4")]
        [Property("Page", "Home")]
        [Test]
        public void FooterLinksAreDisplayed()
        {
            GoToHomePage()
                .CheckFooterElements();
        }
    }
}
