using CSharpAutoTraining.Course3.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.PageObjects
{
    /// <summary>
    /// WikiPage page object
    /// </summary>
    public class WikiPage
    {
        private IWebDriver driver;
        private IWebElement Loader => driver.FindElement(By.Id("loader"));

        public WikiPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToBeDisplayed(Loader, "wikipage loader", false, 15);
        }

        /// <summary>
        /// Check expected title for WikiPage
        /// </summary>
        /// <param name="expectedTitle">Expected page title to be checked against</param>
        /// <returns></returns>
        public WikiPage CheckWikiPageTitle(string expectedTitle)
        {
            ReporterBDD.LogInfo("Check Wikipage title after redirect");

            Assert.AreEqual(expectedTitle, driver.Title);

            return this;
        }
    }
}
