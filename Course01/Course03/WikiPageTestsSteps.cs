using Course01.Course03;
using Course01.Screens;
using System;
using TechTalk.SpecFlow;

namespace Course01
{
    [Binding]
    public class WikiPageTestsSteps
    {
        private WikiPage wikiPage;


        [Then(@"I should be redirected to WikiPage '(.*)'")]
        public void ThenIShouldBeRedirectedToWikiPage(string title)
        {
            wikiPage = new WikiPage(WebDriverBDD.WebDriver);

            wikiPage.CheckPageTitle(title);
        }
    }
}
