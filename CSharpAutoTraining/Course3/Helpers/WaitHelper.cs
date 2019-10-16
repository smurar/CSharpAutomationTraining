using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Helpers
{
    public static class WaitHelper
    {
        

        public static void WaitForElementToBeDisplayed(this IWebDriver driver, IWebElement element, string elementName, bool isDisplayed, int timeoutSeconds)
        {
            ReporterBDD.LogInfo("Wait for element" + elementName + " to be displayed");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            if (isDisplayed)
            {
                wait.Until(x => element.Displayed);
            }
            else
            {
                wait.Until(x => !element.Displayed);
            }
        }

    }
}
