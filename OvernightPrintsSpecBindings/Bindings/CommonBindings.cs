using System;
using System.Threading;
using OvernightPrintsSpecBindings.TestBase;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	public class CommonBindings
	{
		[Given(@"I open browser")]
		public void IOpenBrowser()
		{
			if (!Browser.IsInitialized)
			{
				Browser.BuildBrowser();
				Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
			}
		}

		[Given(@"I navigate to url ""(.*)""")]
		public void GivenNavigateToUrl(string url)
		{
			Browser.Driver.Navigate().GoToUrl(url);
		}

		[Then(@"I wait for (.*) seconds")]
		public void IWait(int seconds)
		{
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
		}
	}
}
