using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Course2.Base;
using TestProject.Course2.Resources.Resx;
using TestProject.Course2.Resources.Class;
using TestProject.Course2.Reports;

namespace TestProject.Course2.POM
{
    public class DashboardPagePOM : BasePage
    {
        IWebDriver driver;

        public DashboardPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Webelements
        #region Header Elements
        private IWebElement HeaderPhoto { get { return driver.FindElement(By.XPath("//img")); } }
        private IWebElement HeaderHomeLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'homepage.html']")); } }
        private IWebElement HeaderWikiPageLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")); } }
        #endregion
        #region Body Elements
        private IWebElement Spinner { get { return driver.FindElement(By.Id("loader")); } }
        private IWebElement HeadlingTitle { get { return driver.FindElement(By.XPath("//h1")); } }
        private IWebElement FirstnameField { get { return driver.FindElement(By.Id("firstname")); } }
        private IWebElement LastnameField { get { return driver.FindElement(By.XPath("//input[@value='David']")); } }
        private IWebElement VehicleOneCheckBox { get { return driver.FindElement(By.Name("vehicle2")); } }
        private IWebElement BirthdayField { get { return driver.FindElement(By.Name("bday")); } }
        private IWebElement UploadPictureButton { get { return driver.FindElement(By.Name("picture")); } }
        private IWebElement SaveButton { get { return driver.FindElement(By.Id("SaveDetails")); } }
        private IWebElement DetailsSavedMessage { get { return driver.FindElement(By.Id("detailsSavedMessage")); } }
        private IWebElement LogOutButton { get { return driver.FindElement(By.Id("Logout")); } }
        #endregion
        #region Footer Elements
        private IWebElement FooterHomeLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'homepage.html']")); } }
        private IWebElement FooterWikiLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'wikipage.html']")); } }
        private IWebElement FooterContactLink { get { return driver.FindElement(By.LinkText("Contact (NA)")); } }
        #endregion
        #endregion

        #region Validation Methods
        public DashboardPagePOM CheckPageTitle()
        {
            StringAssert.AreEqualIgnoringCase(DashboardPageResx.PageTitle, driver.Title, AssertMessages.WrongPageTitle);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }       

        public DashboardPagePOM CheckPageHeaderElements()
        {
            Assert.IsTrue(HeaderPhoto.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderHomeLink.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderWikiPageLink.Displayed, AssertMessages.ElementNotDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public DashboardPagePOM CheckFooterElements()
        {
            Assert.IsTrue(FooterHomeLink.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterWikiLink.Displayed, AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterContactLink.Displayed, AssertMessages.ElementNotDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public DashboardPagePOM CheckHeadlingTitle()
        {
            StringAssert.AreEqualIgnoringCase(DashboardPageResx.HeadlingTitle, HeadlingTitle.Text, AssertMessages.WrongHeadlingTitle);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public DashboardPagePOM CheckMessageAfterSave()
        {
            StringAssert.AreEqualIgnoringCase(DashboardPageResx.DetailsSaved, DetailsSavedMessage.Text);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }
        #endregion

        #region Action Methods
        public DashboardPagePOM EnterFirsname(string firstname)
        {
            FirstnameField.Clear();
            FirstnameField.SendKeys(firstname);

            return this;
        }

        public DashboardPagePOM EnterLastname(string lastname)
        {
            FirstnameField.Clear();
            FirstnameField.SendKeys(lastname);

            return this;
        }

        public DashboardPagePOM CompleteAllFields()
        {           
            EnterFirsname(DashboardPageResx.FirstName);
            EnterLastname(DashboardPageResx.LastName);            
            VehicleOneCheckBox.Click();
            BirthdayField.SendKeys(DashboardPageResx.BirthDay);
            UploadPictureButton.SendKeys(Paths.CarPhoto);                     

            return this;
        }

        public DashboardPagePOM ClickSaveButton()
        {
            SaveButton.Click();

            return this;
        }
        #endregion

        #region Navigation Methods
        public HomePagePOM GoToHomePage()
        {            
            LogOutButton.Click();            

            return new HomePagePOM(driver);
        }
        #endregion
    }
}
