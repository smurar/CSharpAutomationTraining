using Course2.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Course2.Course3
{
    [Binding]
    public class WikiPageTestsSteps

    {
        private WikiPage wikiPage;
        [Then(@"I should be redirected to WikiPage'(.*)'")]
        public void ThenIShouldBeRedirectedToWikiPage(string p0)
        {
            wikiPage = new WikiPage(WebDriverBDD.WebDriver);
            wikiPage.CheckPageTitle(p0);
        }
    }
}
