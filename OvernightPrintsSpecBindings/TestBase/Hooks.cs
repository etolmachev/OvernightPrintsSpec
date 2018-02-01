using System;
using NUnit.Framework;
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
			try
			{
				if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
				{
					Utils.CaptureScreenShot();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			
			Browser.Quit();
		}
	}
}
