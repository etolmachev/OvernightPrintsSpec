using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.TestBase
{
	[Binding]
	public class Cleanup
	{
		[AfterScenario]
		public void closeBrowser()
		{
			Browser.Quit();
		}
	}
}
