using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course2
{
    class ImageHelper
    {
        public static string CaptureScreen(IWebDriver driver)
        {
            Screenshot sshot = ((ITakesScreenshot)driver).GetScreenshot();
            string imageName = DateTime.Now.ToString("yyyyMMdd-hhmmss");
            string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\images\\";
            System.IO.Directory.CreateDirectory(directoryPath);
            string imagePath = directoryPath + imageName + ".jpeg";
            sshot.SaveAsFile(imagePath, ScreenshotImageFormat.Jpeg);
            return imagePath;
        }
    }
}
