using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    public class WindowsHandlingExercise
    {
       public IWebDriver Driver;

       [Test]
       public void WindowsAndFrames()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Drivers");
            String InitialWindow = Driver.CurrentWindowHandle.ToString();
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles.ElementAt(1));
            Driver.Url = "http://google.com";                        
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles.ElementAt(2));
            Driver.Url = "http://www.globalsqa.com/demo-site/frames-and-windows/#iFrame";
            Driver.SwitchTo().Window(InitialWindow);
            Driver.SwitchTo().Window(Driver.WindowHandles.ElementAt(2));
            IReadOnlyCollection<string> Windows = Driver.WindowHandles;
            Console.WriteLine("Number of windows: " + Windows.Count);

            int frames = Driver.FindElements(By.TagName("iframe")).Count;
            Console.WriteLine("Number of frames: " + frames);
            IWebElement myFrame = Driver.FindElement(By.CssSelector("iframe[src='http://www.globalsqa.com/trainings/']"));
            Driver.SwitchTo().Frame(myFrame);
            IWebElement menuInFrame = Driver.FindElement(By.Id("mobile_menu_toggler"));
            menuInFrame.Click();
            Driver.SwitchTo().DefaultContent();
            IWebElement sideMenuItem = Driver.FindElement(By.XPath("//ul[@id='menu-interaction']/li/a"));
            sideMenuItem.Click();
        }
    }


}
