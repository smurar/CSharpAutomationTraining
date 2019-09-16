using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAutoTraining.Course3.Helpers;

namespace CSharpAutoTraining.Course3.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            Reporter reporter = new Reporter();
        }

        public string GetUrl()
        {
            return this.driver.Url;
        }
    }
}
