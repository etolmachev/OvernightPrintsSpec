using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	public class CommonBindings
	{
		[When(@"I open browser")]
		public void IOpenBrowser()
		{
			if (!Browser.IsInitialized)
			{
				Browser.BuildBrowser();
				Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
			}
		}

		[When(@"I navigate to url ""(.*)""")]
		public void GivenNavigateToUrl(string url)
		{
			Browser.Driver.Navigate().GoToUrl(url);
		}

		[Then(@"I wait for (.*) seconds")]
		public void IWait(int seconds)
		{
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
		}

		[Then(@"I see notification message ""(.*)"" on the ""(.*)""")]
		public void ThenISeeNotificationMessageOnThe(string expectedMessage, string page)
		{

			string currentMessage = string.Empty;

			switch (page)
			{
				case "Login popup":
					currentMessage = new LoginPopUpPage().GetTextMessageError();
					break;

				case "Reset Password":
					currentMessage = new HtmlElement(By.CssSelector("h4")).Text;
					break;

				case "Reset Password popup":
					currentMessage = new ResetPasswordPopUpPage().GetStatusField();
					break;

				default:
					throw new NotImplementedException();
			}
			Assert.AreEqual(expectedMessage, currentMessage);
		}

		[When(@"I remember ""(.*)"" as ""(.*)""")]
		public void WhenIRememberAs(string value, string key)
		{
			string result = Utils.Utils.Resolve(value);
			ScenarioContext.Current.Set(result,key);
			Console.WriteLine(result);
		}

	}
}
