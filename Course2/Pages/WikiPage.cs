using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
    /// <summary>
    /// WikiPage page object
    /// </summary>
    public class WikiPage
    {
        public IWebDriver Driver;

        private IWebElement WikiPageTitle => Driver.FindElement(By.TagName("title"));
        private IWebElement TextArea => Driver.FindElement(By.Id("htmlVersion"));


        public WikiPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        /// <summary>
        /// Check the page title
        /// </summary>
        /// <param name="ExpectedTitle"></param>
        /// <returns>WikiPage object</returns>
        public WikiPage CheckWikiTitle(string ExpectedTitle)
        {
            Reporter.LogInfo("Checking page title");
            Assert.True(Driver.Title.Equals(ExpectedTitle));
            return this;
        }

        /// <summary>
        /// Write text to text area field
        /// </summary>
        /// <param name="Text"></param>
        /// <returns>WikiPage object</returns>
        public WikiPage AddTextToTextArea(string Text)
        {
            TextArea.SendText(Text, "text area");
            return this;
        }
    }
}

       