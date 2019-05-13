using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    public class DashboardPageTests : BaseTest
    {
        [Test]
        public void DashboardPageTitleTest()
        {
            GoToHomePage()
                .Login(MyResource.Email, MyResource.Password)
                .CheckDashboardTitle(MyResource.DashboardTitle);
        }

        [Test]
        public void DashboardHeadingTitleTest()
        {
            GoToHomePage()
                .Login(MyResource.Email, MyResource.Password)
                .CheckHeadingTitle(MyResource.DashboardHeading);
        }

        [Test]
        public void EditPersonalInfoTest()
        {
            GoToHomePage()
                .Login(MyResource.Email, MyResource.Password)
                .Wait()
                .FillInName(MyResource.FirstName, MyResource.LastName)
                .SelectGender(MyResource.Gender)
                .SelectVehicle(MyResource.Vehicle)
                .ClickSave();
        }
    }
}
