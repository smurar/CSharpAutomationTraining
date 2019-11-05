using System;
using TechTalk.SpecFlow;

namespace Course3.Test_Steps
{
    [Binding]
    public class HomePageTestsSteps
    {
        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have typed in emaail")]
        public void GivenIHaveTypedInEmaail(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should reamin on homepage '(.*)'")]
        public void ThenIShouldReaminOnHomepage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
