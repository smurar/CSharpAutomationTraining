using System;
using TechTalk.SpecFlow;

namespace CSharpAutoTraining.Course3.TestSteps
{
    [Binding]
    public class DashboardTestsSteps
    {
        [Given(@"I am on dashboard page")]
        public void GivenIAmOnDashboardPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
