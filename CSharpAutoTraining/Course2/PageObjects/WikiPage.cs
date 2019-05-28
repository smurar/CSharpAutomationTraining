using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course2.PageObjects
{
    public class WikiPage
    {
        private IWebDriver driver;

        public WikiPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public WikiPage CheckWikiPageTitle(string expectedTitle)
        {
            Reporter.LogInfo("Check Wikipage title after redirect");

            Assert.AreEqual(expectedTitle, driver.Title);

            return this;
        }
    }
}
