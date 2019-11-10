using TechTalk.SpecFlow;
using TestProject.Resources.Class;
using TestProject.Resources.POM;
using TestProject.Resources.Resx;

namespace TestProject.Courses.Course3.Steps
{
    [Binding]
    public class FramesPageSteps
    {        
        private FramesPagePOM framesPage;

        [When(@"The user land succesfully on FramesPage")]
        public void WhenTheUserLandSuccesfullyOnFramesPage()
        {
            framesPage = new FramesPagePOM(Driver.DriverInstance);
        }

        [When(@"The user is focusing on the first frame")]
        public void GivenTheUserIsFocusingOnTheFirstFrame()
        {
            framesPage.SwitchFrame(framesPage.Frame1);
        }

        [When(@"The user is focusing on the second frame")]
        public void WhenTheUserIsFocusingOnTheSecondFrame()
        {
            framesPage.SwitchFrame(framesPage.Frame2);
        }

        [Then(@"The user types inside the textbox")]
        public void WhenTheUserTypesInsideTheTextbox()
        {
            framesPage.WriteInsideTextArea(FramesPageResx.TextAreaString);
        }


    }
}
