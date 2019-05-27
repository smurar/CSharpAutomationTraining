using Course2.Reports;
using Course2.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace Course2.PageObjects
{
    public class DashboardPage
    {
        private IWebDriver WebDriver;
        private IWebElement HeaderImage => WebDriver.FindElement(By.XPath("//div[@id='header']//img"));
        private IWebElement HomeLink => WebDriver.FindElement(By.XPath("//ul[@id='navHeader']//a[1]"));
        private IWebElement WikiPageLink => WebDriver.FindElement(By.XPath("//ul[@id='navHeader']//a[2]"));
        private IWebElement HeadingTitle => WebDriver.FindElement(By.XPath("//h1"));
        private IWebElement FirstName => WebDriver.FindElement(By.Id("firstname"));
        private IWebElement LastName => WebDriver.FindElement(By.XPath("//label[contains(text(),'Last Name:')]/following-sibling::input[1]"));
        private IWebElement Gender => WebDriver.FindElement(By.XPath("//input[@value='male']"));
        private IWebElement CarCheckBox => WebDriver.FindElement(By.XPath("//input[@value='Car']"));
        private IWebElement Birthday => WebDriver.FindElement(By.XPath("//input[@type='date']"));
        private IWebElement File => WebDriver.FindElement(By.XPath("//input[@type='file']"));
        private IWebElement SaveButton => WebDriver.FindElement(By.Id("SaveDetails"));
        private IWebElement SavedDetailsMessage => WebDriver.FindElement(By.Id("detailsSavedMessage"));
        private IWebElement LogOutButton => WebDriver.FindElement(By.Id("Logout"));




        public DashboardPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        public DashboardPage CheckPageTitle(string title)
        {
            Reporter.LogInfo("Check that the page title is: " + title);
            Assert.AreEqual(title, WebDriver.Title, "You are not on the DashboardPage");
            return this;
        }

        public DashboardPage CheckHeaderImage()
        {
            Reporter.LogInfo("Check that the header image is displayed");
            Assert.IsTrue(HeaderImage.Displayed, "The header image is not displayed");
            return this;
        }

        public DashboardPage CheckHomePageLink()
        {
            Reporter.LogInfo("Check that Home Page link is displayed");
            Assert.IsTrue(HomeLink.Displayed, "The Home Page link is not displayed");

            return this;
        }

        public DashboardPage CheckWikiPageLink()
        {
            Reporter.LogInfo("Check that Wiki Page link is displayed");
            Assert.IsTrue(WikiPageLink.Displayed, "The Wiki Page link is not displayed");
            return this;
        }

        public DashboardPage CheckHeadingTitle(string expectedHeadingTitle)
        {
            Reporter.LogInfo("Check that the Heading Title is: " + expectedHeadingTitle);
            Assert.AreEqual(expectedHeadingTitle, HeadingTitle.Text, "The heading title is not correct");
            return this;
        }

        public DashboardPage FillInFirstName(string firstName)
        {
            Extensions.WaitForCompleteLoading(WebDriver);
            FirstName.SendKeys(firstName, "First Name");
            return this;
        }

        public DashboardPage FillInLastName(string lastName)
        {
            LastName.SendKeys(lastName, "Last Name");
            return this;
        }

        public DashboardPage SelectGender()
        {
            Gender.Click("Male Gender");
            return this;
        }

        public DashboardPage SelectCarCheckBox()
        {
            Extensions.SelectCheckBox(CarCheckBox, "Car");
            return this;
        }

        public DashboardPage FillInBirthday(string birthday)
        {
            Birthday.SendKeys(birthday, "Birthday");
            return this;
        }

        public DashboardPage UploadFile()
        {
            File.SendKeys(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Image\Car.jpg", "Upload Field");
            return this;
        }

        public DashboardPage Save()
        {
            SaveButton.Click("Save Button");
            return this;
        }

        public DashboardPage CheckSaveDetailsMessage(string savedDetailsMessage)
        {
            Reporter.LogInfo("Check that the message details after save is: " + savedDetailsMessage);
            Assert.AreEqual(savedDetailsMessage, SavedDetailsMessage.Text , "The message displayed after save is not correct");
            return this;
        }

        public HomePage LogOut()
        {
            Extensions.WaitForCompleteLoading(WebDriver);
            LogOutButton.Click("Logout button");
            return new HomePage(WebDriver);
        }
    }
}