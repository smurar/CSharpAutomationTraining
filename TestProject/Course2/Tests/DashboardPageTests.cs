using NUnit.Framework;
using TestProject.Course2.Base;

namespace TestProject.Course2.DashboardPageTests
{
    class DashboardPageTests : BasePage
    {           
        [Test]
        public void HeaderItemsDisplayed()
        {
           GoToDashboardPage()
                .CheckPageHeaderElements();
        }

        [Test]
        public void PageTitleOk()
        {
            GoToDashboardPage()
                .CheckPageTitle();
        }

        [Test]
        public void PageHeadlingTitleOk()
        {
            GoToDashboardPage()
                .CheckHeadlingTitle();
        }

        [Test]
        public void EditPersonalInformationSuccesful()
        {
            GoToDashboardPage()
                .CompleteAllFields()
                .ClickSaveButton()
                .CheckMessageAfterSave();
        }

        [Test]
        public void SuccessfulLogOut()
        {
            GoToDashboardPage()
                .GoToHomePage()
                .CheckPageTitle();
        }

        [Test]
        public void FooterLinksAreDisplayed()
        {
            GoToDashboardPage()
                .CheckFooterElements();
        }
    }
}
