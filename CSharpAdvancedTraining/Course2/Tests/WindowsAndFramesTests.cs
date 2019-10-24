using NUnit.Framework;

namespace CSharpAdvancedTraining.Course2.Tests
{
	public class WindowsAndFramesTests : BaseTest
	{

		[Test]
		public void OpenAndCloseNewWindow()
		{
			var homePage = GoToHomepageWithFrames().CheckHomePageLinkIsDisplayed();
			var initialWindow = homePage.GetParentWindow();
			homePage.ClickWindowAndFrameLink()
					.CheckFrameParentURL(MyResource.ParentFramePartialURLText)
					.CloseFramePageAndSwitchToParentWindow(initialWindow)
					.LoadHomePage()
					.CheckHomePageLinkIsDisplayed();
		}

		[Test]
		public void WriteInFrameArea()
		{
			var homePage = GoToHomepageWithFrames().CheckHomePageLinkIsDisplayed();
			var initialWindow = homePage.GetParentWindow();
			homePage.ClickWindowAndFrameLink()
					.CheckFrameParentURL(MyResource.ParentFramePartialURLText)
					.SwitchToFrameA()
					.FillInFrameTextArea(MyResource.TextFrameA)
					.SwitchToFrameB()
					.FillInFrameTextArea(MyResource.TextFrameB)
					.CloseFramePageAndSwitchToParentWindow(initialWindow)
					.LoadHomePage()
					.CheckPageHeadingTitle(MyResource.HomePageHeadingTitle);

		}
	}
}
