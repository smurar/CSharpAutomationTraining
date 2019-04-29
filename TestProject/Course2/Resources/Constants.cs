using System.IO;
using System.Reflection;

namespace TestProject.Course2.Resources
{
    public static class Constants
    {
        public static string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Driver";
        public static string PhotoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Photos\car.jpeg";
    }
}
