using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.PageObjects
{
    public class FrameParentPage
    {
        private IWebDriver driver;

        public FrameParentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //String InitialWindow = driver.CurrentWindowHandle;

        //IReadOnlyCollection<string> Windows = driver.WindowHandles;

        ////web elements
        //public IWebElement Frame1 => ((RemoteWebDriver)driver).FindElement(By.XPath("/html/frameset/frame[1]"));
        //public IWebElement Frame2 => ((RemoteWebDriver)driver).FindElement(By.XPath("/html/frameset/frame[2]"));


        //public void SwitchToFrame1()
        //{
        //    driver.SwitchTo().Window(Windows.ElementAt(1));            
        //}

        //public void SwitchToInitialWindow()
        //{
        //    driver.SwitchTo().Window(InitialWindow);
        //}

        //public FrameParentPage CloseWindow()
        //{
        //    driver.Close();
        //    return this;
        //}
    }
}
