using NUnit.Framework;
using TestProject.Resources.Base;

namespace TestProject.Courses.Course4.DashboardPageTests
{
    class DashboardPageTests : NUnitBasePage
    {
        [Category("Course4")]
        [Property("Page","Dashboard")]
        [Test]
        public void HeaderItemsDisplayed()
        {
           GoToDashboardPage()
                .CheckPageHeaderElements();
        }

        [Category("Course4")]
        [Property("Page", "Dashboard")]
        [Test]
        public void PageTitleOk()
        {
            GoToDashboardPage()
                .CheckPageTitle();
        }

        [Category("Course4")]
        [Property("Page", "Dashboard")]
        [Test]
        public void PageHeadlingTitleOk()
        {
            GoToDashboardPage()
                .CheckHeadlingTitle();
        }

        [Category("Course4")]
        [Property("Page", "Dashboard")]
        [Test]
        public void EditPersonalInformationSuccesful()
        {
            GoToDashboardPage()
                .CompleteAllFields()
                .ClickSaveButton()
                .CheckMessageAfterSave();
        }

        [Category("Course4")]
        [Property("Page", "Dashboard")]
        [Test]
        public void SuccessfulLogOut()
        {
            GoToDashboardPage()
                .GoToHomePage()
                .CheckPageTitle();
        }

        [Category("Course4")]
        [Property("Page", "Dashboard")]
        [Test]
        public void FooterLinksAreDisplayed()
        {
            GoToDashboardPage()
                .CheckFooterElements();
        }
    }
}
