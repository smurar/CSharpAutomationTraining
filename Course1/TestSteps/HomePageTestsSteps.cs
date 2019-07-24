using System;
using TechTalk.SpecFlow;

namespace Course1.TestSteps
{
    public class HomePageTestsSteps
    {
        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have typed in email")]
        public void GivenIHaveTypedInEmail(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should remain on homepage '(.*)'")]
        public void ThenIShouldRemainOnHomepage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
