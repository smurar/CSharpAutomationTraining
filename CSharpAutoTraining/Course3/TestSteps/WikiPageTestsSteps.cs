using CSharpAutoTraining.Course3;
using CSharpAutoTraining.Course3.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutoTraining
{
    [Binding]
    public class WikiPageTestsSteps
    {
        private WikiPage wikiPage;

        [Then(@"I am redirected to the Wiki page")]
        public void ThenIAmRedirectedToTheWikiPage()
        {
            wikiPage = new WikiPage(WebDriverClass.WebDriver);
            wikiPage.CheckWikiPageTitle(TestData.ExpectedWikiPageTitle);
        }
    }
}
