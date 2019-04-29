using NUnit.Framework;
using TestProject.Course2.Base;

namespace TestProject.Course2.Tests.DashboardPage
{
    class DashboardPageTests : BasePage
    {           
        [Test]
        public void HeaderItemsDisplayed()
        {
            GoToHomePage()
                .GoToDashboarPage()
                .CheckPageHeaderElements();
        }

        [Test]
        public void PageTitleOk()
        {
            GoToHomePage()
                .GoToDashboarPage()
                .CheckPageTitle();
        }

        [Test]
        public void PageHeadlingTitleOk()
        {
            GoToHomePage()
                .GoToDashboarPage()
                .CheckHeadlingTitle();
        }

        [Test]
        public void EditPersonalInformationSuccesful()
        {
            GoToHomePage()
                .GoToDashboarPage()
                .CompleteAllFields()
                .ClickSaveButton()
                .CheckMessageAfterSave();
        }

        [Test]
        public void SuccessfulLogOut()
        {
            GoToHomePage()
                .GoToDashboarPage()
                .GoToHomePage()
                .CheckPageTitle();
        }

        [Test]
        public void FooterLinksAreDisplayed()
        {
            GoToHomePage()
                .GoToDashboarPage()
                .CheckFooterElements();
        }
    }
}
