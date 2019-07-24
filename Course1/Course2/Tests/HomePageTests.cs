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
                .DefaultLoginInfo("Default password: 111111");
               //.Login(UserData.Email, UserData.Password)
               //.CheckPageTitle(Data.Pages.DashboardPage);
        }
    }
}