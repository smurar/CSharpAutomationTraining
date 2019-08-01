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
            GoToDashboardPage()              
                .CheckDashboardTitle(MyResource.DashboardTitle);
        }

        [Test]
        public void DashboardHeadingTitleTest()
        {
            GoToDashboardPage()
                .CheckHeadingTitle(MyResource.DashboardHeading);
        }

        [Test]
        public void DashboardEditPersonalInfoTest()
        {
            GoToDashboardPage()
                .Wait()
                .FillInName(MyResource.FirstName, "First name", MyResource.LastName, "Last name")
                .SelectGender(MyResource.Gender)
                .SelectVehicle(MyResource.Vehicle)
                .SelectBirthDate(MyResource.Birthday, "Birthday")
                .ClickSave();
        }

        [Test]
        public void Logout()
        {
            GoToDashboardPage()
                .Wait()
                .Logout()
                .CheckLoginFields();
        }
    }
}
