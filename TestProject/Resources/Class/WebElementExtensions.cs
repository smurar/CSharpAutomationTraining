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
            bool result = false;
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
        
        //testing scope
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
