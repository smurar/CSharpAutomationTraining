using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Resources.Resx;
using TestProject.Resources.Class;
using TestProject.Resources.Reports;
using System.Threading;

namespace TestProject.Resources.POM
{
    public class DashboardPagePOM 
    {
        IWebDriver driver;

        public DashboardPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Webelements
        #region Header Elements
        public IWebElement HeaderPhoto { get { return driver.FindElement(By.XPath("//img")); } }
        public IWebElement HeaderHomeLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'homepage.html']")); } }
        public IWebElement HeaderWikiPageLink { get { return driver.FindElement(By.XPath("//ul/a[@href = 'wikipage.html']")); } }
        #endregion
        #region Body Elements      
        public IWebElement Spinner { get { return driver.FindElement(By.Id("loader")); } } //testing scope
        public IWebElement HeadlingTitle { get { return driver.FindElement(By.XPath("//h1")); } }
        public IWebElement FirstnameField { get { return driver.FindElement(By.Id("firstname")); } }
        public IWebElement LastnameField { get { return driver.FindElement(By.XPath("//input[@value='David']")); } }
        public IWebElement VehicleOneCheckBox { get { return driver.FindElement(By.Name("vehicle2")); } }
        public IWebElement BirthdayField { get { return driver.FindElement(By.Name("bday")); } }
        public IWebElement UploadPictureButton { get { return driver.FindElement(By.Name("picture")); } }
        public IWebElement SaveButton { get { return driver.FindElement(By.Id("SaveDetails")); } }
        public IWebElement DetailsSavedMessage { get { return driver.FindElement(By.Id("detailsSavedMessage")); } }
        public IWebElement LogOutButton { get { return driver.FindElement(By.Id("Logout") , 60); } } //testing scope
        #endregion
        #region Footer Elements
        public IWebElement FooterHomeLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'homepage.html']")); } }
        public IWebElement FooterWikiLink { get { return driver.FindElement(By.XPath("//li/a[@href = 'wikipage.html']")); } }
        public IWebElement FooterContactLink { get { return driver.FindElement(By.LinkText("Contact (NA)")); } }
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
            Assert.IsTrue(HeaderPhoto.IsDisplayed("Header photo"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderHomeLink.IsDisplayed("Header Home link"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(HeaderWikiPageLink.IsDisplayed("Header WikiPage link"), AssertMessages.ElementNotDisplayed);
            Reporter.LogScreenshot(ImageHelper.GetScreenshotPath(driver));

            return this;
        }

        public DashboardPagePOM CheckFooterElements()
        {
            Assert.IsTrue(FooterHomeLink.IsDisplayed("Footer Home link"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterWikiLink.IsDisplayed("Footer WikiPage link"), AssertMessages.ElementNotDisplayed);
            Assert.IsTrue(FooterContactLink.IsDisplayed("Footer Contact link"), AssertMessages.ElementNotDisplayed);
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
            FirstnameField.SendText(firstname , "First Name field");

            return this;
        }

        public DashboardPagePOM EnterLastname(string lastname)
        {            
            FirstnameField.SendText(lastname , "Last Name field");

            return this;
        }

        public DashboardPagePOM CompleteAllFields()
        {           
            EnterFirsname(DashboardPageResx.FirstName);
            EnterLastname(DashboardPageResx.LastName);            
            VehicleOneCheckBox.ClickElement("Vehicle one check box");
            BirthdayField.SendText(DashboardPageResx.BirthDay , "Birthday field");
            UploadPictureButton.SendText(Paths.CarPhoto , "Upload picture");                     

            return this;
        }

        public DashboardPagePOM ClickSaveButton()
        {
            SaveButton.ClickElement("Save Button");

            return this;
        }
        #endregion
        #region Navigation Methods
        public HomePagePOM GoToHomePage()
        {           
            LogOutButton.ClickElement("LogOut button");            

            return new HomePagePOM(driver);
        }

        public void ClickLogOutButton()
        {
            LogOutButton.ClickElement("LogOut button");
        }

        //testing scope
        public void WaitForSpinnerToLoad()
        {
            while (Spinner.Displayed)
            {
                Thread.Sleep(50);
            }
        }
        #endregion
    }
}
