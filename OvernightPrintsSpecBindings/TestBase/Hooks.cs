
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.TestBase
{
	[Binding]
	public class Hooks
	{
		[BeforeFeature]
		public static void BeforeFeauture()
		{
			Manager.buildConfig();
		}

		[AfterScenario]
		public void CloseBrowser()
		{
			Browser.Quit();
		}
	}
}
