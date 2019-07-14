using Course2.Data;
using Course2.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Course2.Tests
{
    public class DashboardPageTest : BaseTest
    {     
        [Test]
        public void DashBoardPage_HeaderLinkAndImg()
        {
            GoToDashboardPage();

            Assert.IsTrue(_dashboardPage.HeaderItemVisibilityVerification());
        }

        [Test]
        public void DashBoardPage_FooterLinks()
        {
            GoToDashboardPage();

            Assert.IsTrue(_dashboardPage.FooterItemVisibilityVerification());
        }

        [Test]
        public void DashBoardPageTitle()
        {
            GoToDashboardPage();

            _dashboardPage.VerifyPageTitle(MyResources.DashboardPageTitle);
        }

        [Test]
        public void DashboardPageHeading()
        {
            GoToDashboardPage();
            _dashboardPage.VerifyH1Title(MyResources.DashboardPageTitle);            
        }

        [Test]
        public void EditpersonalInformation()
        {
            GoToDashboardPage();
            Thread.Sleep(3000);
            _dashboardPage.EditUserInfo("Lola", "Bunny", isMale: false, "12 Dec 1933", bike: true)
                .SavePage();

            Assert.IsTrue(_dashboardPage.SaveConfirmationDisplayed());
        }

        [Test]
        public void LogoutDashboardPage()
        {
            GoToDashboardPage();
            Thread.Sleep(3000);
            _homePage = _dashboardPage.Logout();
            Thread.Sleep(3000);
            _homePage.VerifyPageTitle(Constants.HomePageTitle);
        }
    }
}
