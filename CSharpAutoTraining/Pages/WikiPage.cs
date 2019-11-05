using CSharpAutoTraining.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining
{
    public class WikiPage
    {
        private IWebDriver Driver;
        private IWebElement Loader => Driver.FindElement(By.Id("loader"));

        public WikiPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            Driver.WaitElementToBeDisplayed(Loader, false, "loader");
        }
        
        public WikiPage VerifyPageTitle(string expected)
        {
            Assert.IsTrue(condition: object.Equals(Driver.Title, expected));
            return this;
        }

      
    }
}
