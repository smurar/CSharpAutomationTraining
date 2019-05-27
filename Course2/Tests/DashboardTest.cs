using Course2.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    class DashboardTest:BaseTest
    {
        [Test]
        public void HeaderImageTest()
        {
            GoToDashboardPage()
                
                .CheckHeaderImage();
        }

        [Test]
        public void HeaderLinksTest()
        {

            GoToDashboardPage()
                .CheckHomePageLink()
                .CheckWikiPageLink();
        }

        [Test]
        public void PageTitleTest()
        {
            GoToDashboardPage()
                .CheckPageTitle(DataDashboardPage.Title);
        }

        [Test]
        public void HeadingTitleTest()
        {
            GoToDashboardPage()
                .CheckHeadingTitle(DataDashboardPage.HeadingTitle);
        }

        [Test]
        public void SaveDetailsTest()
        {
            GoToDashboardPage()
                .FillInFirstName(DataDashboardPage.FirstName)
                .FillInLastName(DataDashboardPage.LastName)
                .SelectGender().SelectCarCheckBox()
                .FillInBirthday(DataDashboardPage.Birthday)
                .UploadFile().Save()
                .CheckSaveDetailsMessage(DataDashboardPage.SavedDetailsMessage);
        }

        [Test]
        public void LogOutTest()
        {
            GoToDashboardPage()
                .LogOut()
                .CheckPageTitle(DataHomePage.Title);
        }
    }
}
