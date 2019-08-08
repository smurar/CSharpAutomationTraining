using CSharpAutoTraining.Course2.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2.Tests
{  
    public class DashboardPageTest : BaseTest
    {
        [Test, Order(1)]
        public void TestHeaderLinksAndImageAreDisplayed()
        {
            HomePage page = GoToHomePage();

            Assert.True(page.HeaderImageIsDisplayed());
            Assert.True(page.HeaderLinksAreAllDisplayed());
        }

        [Test, Order(2)]
        public void TestDashboardTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardTitle, GoToDashboardPage().GetPageTitle());
        }

        [Test, Order(3)]
        public void TestPageHeadingTitleIsCorrect()
        {
            Assert.AreEqual(DataDashboardPage.DashboardPageHeadingTitle, GoToDashboardPage().GetPageHeadingTitle());
        }

        [Test, Order(4)]
        public void TestNameCanBeFilledIn()
        {

        }
    }
}
