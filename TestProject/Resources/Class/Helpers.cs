using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace TestProject.Resources.Class
{
    public class Helpers : Driver
    {       
        public static string GetDirectoryPath(string key)
        {
            return GetExecutionDirectory() + GetValueFromAppConfig(key);
        }

        public static string GetFilePath(string key)
        {
            return Path.GetFullPath(GetExecutionDirectory() + GetValueFromAppConfig(key));
        }

        public static string GetBrowserType(string key)
        {
            return GetValueFromAppConfig(key);
        }

        public static string GetValueFromAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static string GetExecutionDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetCurrentTestName()
        {
            return TestContext.CurrentContext.Test.Name;
        }       

        public static string GetCurrentTestFinalStackTrace()
        {
            return string.IsNullOrEmpty(GetCurrentTestStacktrace()) ? "" : string.Format("{0}", GetCurrentTestStacktrace());
        }

        public static string GetCurrentTestStacktrace()
        {
            return TestContext.CurrentContext.Result.StackTrace;
        }

        public static TestStatus GetCurrentTestOutcome()
        {
            return TestContext.CurrentContext.Result.Outcome.Status;
        }        

        public static void SwitchToLastWindow()
        {
            DriverInstance.SwitchTo().Window(DriverInstance.WindowHandles.ElementAt(1));           
        }
    }
}