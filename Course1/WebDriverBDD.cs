using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Course1
{
    [Binding]
    public class WebDriverBDD
    {
        public static IWebDriver WebDriver { get; set; }
    }
}