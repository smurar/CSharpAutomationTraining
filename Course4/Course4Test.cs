using CSharpAutoTraining;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course4
{
    public class Course4Test : BaseTest
    {
        [Test]
        [Category ("HomePage")]
        public void HomePage_HeaderImgAndLinks()
        {
            GoToHomePage()
                .HeaderItemVisibilityVerification();
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_TitleCheck()
        {
            GoToHomePage()
                .VerifyPageTitle(Constants.HomePageTitle);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_HeadingH1Test()
        {
            GoToHomePage()
                .VerifyHeadingH1(Constants.HomePageHeadingH1);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_DefaultEmailAndPassFields()
        {
            GoToHomePage()
                .DefaultEmailFieldValidation(Constants.EmailValid)
                .DefaultPasswordFieldValidation(Constants.PasswordValid);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_LoginField()
        {
            GoToHomePage()
                .PageBodyItemVisibilityVerification();
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_EmailFieldEmpty()
        {
            GoToHomePage()
                .UnsuccessfulLogin("", "")
                .EmailErrorValidation(Constants.EmailErrorNull);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_EmailInvalidFormat()
        {
            GoToHomePage()
                .UnsuccessfulLogin(Constants.EmailInvalidFormat, Constants.PasswordValid)
                .EmailErrorValidation(Constants.EmailErrorFormat);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_InvalidEmail()
        {
            GoToHomePage()
                .UnsuccessfulLogin(Constants.EmailInvalid1, Constants.PasswordValid)
                .PasswordErrorValidation(Constants.InvalidEmailOrPass);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_InvalidPassword()
        {
            GoToHomePage()
                .UnsuccessfulLogin(Constants.EmailValid, Constants.PasswordInvalid1)
                .PasswordErrorValidation(Constants.InvalidEmailOrPass);
        }

        [Test]
        [Category("HomePage")]
        [Category("DashboardPage")]
        public void HomePage_SuccessfullLogin()
        {
            GoToHomePage()
                .SuccessfulLogin(Constants.EmailValid, Constants.PasswordValid)
                .VerifyPageTitle(Constants.DashboardPageTitle);
        }

        [Test]
        [Category("HomePage")]
        [Category("WikiPage")]
        public void HomePage_NavigateToWikiPage()
        {
            GoToHomePage()
                .GoToWikiPageByClickOnLink(true)
                .VerifyPageTitle(Constants.WikiPageTitle);
        }

        [Test]
        [Category("HomePage")]
        public void HomePage_FooterLinks()
        {
            GoToHomePage()
                .FooterItemVisibilityVerification();
        }

        [Test]
        [Category("DashboardPage")]
        public void DashboardPage_HeaderImgAndLinks()
        {
            GoToDashboardPage()
                .HeaderItemVisibilityVerification();
        }

        [Test]
        [Category("DashboardPage")]
        public void DashboardPage_TitleCheck()
        {
            GoToDashboardPage()
                .VerifyPageTitle(Constants.DashboardPageTitle);
        }

        [Test]
        [Category("DashboardPage")]
        public void DashboardPage_HeadingH1Test()
        {
            GoToDashboardPage()
                .VerifyH1Title(Constants.DashboardPageHeadingH1);
        }

        [Test]
        [Category("DashboardPage")]
        public void DashboardPage_EditPersonalInformation()
        {
            GoToDashboardPage()
                .EditUserInfo("Mickey", "Mouse", "Male", "12/05/1966", true, true)
                .SavePage()
                .SaveConfirmationDisplayed();
        }

        [Test]
        [Category("HomePage")]
        [Category("DashboardPage")]
        public void DashboardPage_SuccessfullLogout()
        {
            GoToDashboardPage()
                .Logout()
                .VerifyPageTitle(Constants.HomePageTitle);
        }

        [Test]
        [Category("DashboardPage")]
        public void DashboardPage_FooterLinks()
        {
            GoToDashboardPage()
                .FooterItemVisibilityVerification();
        }
    }
}
