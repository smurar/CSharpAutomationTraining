using NUnit.Framework;
using TechTalk.SpecFlow;
using TestProject.Course2.POM;
using TestProject.Course2.Reports;
using TestProject.Course2.Resources.Resx;

namespace TestProject.Course3.Steps
{
    [Binding]
    public class WikiPageSteps : WebDriverBDD
    {
        private WikiPagePOM wikipage;

        [Then(@"The user lands succesfully on WikiPage")]
        public void ThenTheUserLandsSuccesfullyOnWikiPage()
        {
            StringAssert.AreEqualIgnoringCase(WikiPageResx.PageTitle, Driver.Title, AssertMessages.WrongPageTitle);
            wikipage = new WikiPagePOM(Driver);
        }
    }
}
