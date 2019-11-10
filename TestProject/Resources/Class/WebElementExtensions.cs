using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestProject.Resources.Reports;

namespace TestProject.Resources.Class
{
    public static class WebElementExtensions
    {
        public static bool IsDisplayed(this IWebElement element, string elementName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Reporter.LogPass("Element '" + elementName + "' is displayed");
            }
            catch (Exception)
            {
                result = false;
                Reporter.LogFail("Element '" + elementName + "' is not displayed");
            }
            return result;
        }

        public static void ClickElement(this IWebElement element, string elementName)
        {
            element.Click();
            Reporter.LogInfo("Click element '" + elementName + "'");
        }

        public static void SendText(this IWebElement element, string text, string elementName)
        {
            element.Clear();
            Reporter.LogInfo("Clear element '" + elementName + "'");
            element.SendKeys(text);
            Reporter.LogInfo("Write text '" + text + "' inside element: '" + elementName + "'");
        }

        public static void WaitForSpinner(this IWebDriver Driver, IWebElement spinner , int seconds = 60)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(x => spinner.Displayed);
        }
    }
}
