using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using OvernightPrintsSpecBindings.TestBase.Pages.Products;
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

				case "Basket Page":
					currentMessage = new BasketPage().GetTextElement("Basket Is Empty");
					break;

				default:
					throw new NotImplementedException();
			}
			Assert.AreEqual(expectedMessage.ToLower(), currentMessage.ToLower());
		}

		[When(@"I remember ""(.*)"" as ""(.*)""")]
		public void WhenIRememberAs(string value, string key)
		{
			string result = Utils.Resolve(value);
			ScenarioContext.Current.Set(result,key);
		}

		[When(@"I click (Log out|Log in|CART) button on the Header Page")]
		public void WhenIClickLogOutButtonInTheHeaderPage(string buttonName)
		{

			HtmlElement htmlElement = null;

			switch (buttonName)
			{
				case "Log out":
					htmlElement = new HtmlElement(By.Id("logout-link"));
					break;
				case "Log in":
					htmlElement = new HtmlElement(By.CssSelector("a[href='/login']"));
					break;
				case "CART":
					htmlElement = new HtmlElement(By.CssSelector(".account-and-cart a[href='/cart']"));
					break;
				default:
					throw new NotImplementedException();
			}

			try
			{
				htmlElement.Click();
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.Message);
				Utils.ExecuteJavaScript(Browser.Driver, "arguments[0].click();", htmlElement.WrappedElement);
			}
			
		}

		[Then(@"I wait for (.*) seconds for ""(.*)"" is load")]
		public void ThenIWaitForSecondsForIsLoad(int timeout, string elementName)
		{
			switch (elementName)
			{
				case "Approve Order Page":
					new ApproveOrderPage().WaitPageLoad(timeout);
					break;
				case "500 Double Sided Business Cards":
				case "1000 Double Sided":
					new BasketPage().WaitItemLoad(elementName, timeout);
					break;

				case "Basket page":
					new BasketPage().WaitBasketPageLoadAfterRemoveItem(timeout);
					break;
				case "Order Summery Block":
					new BasketPage().WaitOrderSummaryBlockLoad(timeout);
					break;
				default:
					throw new NotImplementedException();
			}
		}

		[Then(@"I see element My Account on the Header Page")]
		public void ThenISeeElementOnTheMainPage()
		{
			HtmlElement MyAccountElement = new HtmlElement(By.ClassName("my-account-text"));
			Assert.AreEqual("My Account", MyAccountElement.Text);
		}

		[Then(@"I see that user is not logged in")]
		public void ThenISeeThatUserIsNotLoggedIn()
		{
			HtmlElement MyAccountLink = new HtmlElement(By.CssSelector("span.my-account-text"));
			Assert.Throws<NoSuchElementException>(delegate() { IWebElement element = MyAccountLink.WrappedElement;});
		}

		[Then(@"I see that user ""(.*)"" is logged in")]
		public void ThenISeeThatUserIsLoggedIn(string expectedUserName)
		{
			HtmlElement Username = new HtmlElement(By.ClassName("user-name"));
			Assert.IsTrue(Username.Text.Contains(expectedUserName));
		}
	}
}
