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
        private IWebDriver WebDriver;

       


        public WikiPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }
        
        public WikiPage VerifyPageTitle(string expected)
        {
            Assert.IsTrue(condition: object.Equals(WebDriver.Title, expected));
            return this;
        }

      
    }
}
