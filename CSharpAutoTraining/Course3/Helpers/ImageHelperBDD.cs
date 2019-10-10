using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course3.Helpers
{   /// <summary>
    /// Image Heper class
    /// </summary>
    class ImageHelperBDD
    {
        /// <summary>
        /// Make Screenshot method
        /// </summary>
        /// <param name="driver">passed webdriver</param>
        /// <returns></returns>
        public static string CaputeScreen(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string imageName = DateTime.Now.ToString("yyyMMdd-hhmmss");

            string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\images\\";

            System.IO.Directory.CreateDirectory(directoryPath);

            string imagePath = directoryPath + imageName + ".jpeg";

            ss.SaveAsFile(imagePath, ScreenshotImageFormat.Jpeg);

            return imagePath;
        }
    }
}
