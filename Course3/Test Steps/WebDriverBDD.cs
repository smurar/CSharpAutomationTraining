using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Course3.Test_Steps
{
    [Binding]
    public class WebDriverBDD
    {
        public static IWebDriver WebDriver { get; set; }
    }
}
