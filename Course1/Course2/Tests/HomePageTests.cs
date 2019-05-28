using Course1.Data;
using NUnit.Framework;

namespace Course1.Course2.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTest
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
               .FillInEmail(UserData.Email)
               .FillInPassword(UserData.Password)
               .ClickLogin()
               .CheckPageTitle(Data.Pages.DashboardPage);
        }
    }
}