using NUnit.Framework;
using TechTalk.SpecFlow;
using TestProject.Resources.Class;
using TestProject.Resources.POM;
using TestProject.Resources.Resx;

namespace TestProject.Courses.Course3.Steps
{
    [Binding]
    public class WikiPageSteps 
    {
        private WikiPagePOM wikipage;

        [Then(@"The user lands succesfully on WikiPage")]
        public void ThenTheUserLandsSuccesfullyOnWikiPage()
        {
            StringAssert.AreEqualIgnoringCase(WikiPageResx.PageTitle, Driver.DriverInstance.Title, AssertMessages.WrongPageTitle);
            wikipage = new WikiPagePOM(Driver.DriverInstance);
        }
    }
}
