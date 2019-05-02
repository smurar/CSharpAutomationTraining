using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using TestProject.Course2.Resources.Class;
using TestProject.Course2.Resources.Resx;

namespace TestProject.Course2.Reports
{
    public static class ImageHelper 
    {        
        public static int screenshotNumber = 0;
        static string imagePath = string.Empty;

        public static string GetScreenshotPath(IWebDriver driver)
        {            
            SaveScreenshot(driver);

            return imagePath;
        }

        public static void SaveScreenshot(IWebDriver driver)
        {
            IncrementScreenshotNumber();
            SetImagePath();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(imagePath);
        }

        public static void SetImagePath()
        {
            string imageName = TestContext.CurrentContext.Test.Name + "_" + Templates.fileName + "_" + screenshotNumber + FileTypeResx.JPEG;
            imagePath = Path.Combine(Paths.Screenshots, imageName);            
        }

        public static void ResetScreenShotNumber()
        {
            screenshotNumber = 0;
        }

        public static string IncrementScreenshotNumber()
        {
            screenshotNumber += 1;

            return screenshotNumber.ToString();
        }
    }
}
