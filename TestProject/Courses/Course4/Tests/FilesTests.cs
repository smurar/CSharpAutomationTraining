using NUnit.Framework;
using TestProject.Resources.Class;

namespace TestProject.Courses.Course4.Tests
{
    class FilesTests
    {
        [Category("Course4")]
        [Test]
        public void FileHandling()
        {
            FileHandler.GenerateTestFoldersAndFiles();
            FileHandler.DeleteTestFoldersAndFiles();
        }
    }
}
