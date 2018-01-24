
using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Products
{
	public class BuilderPage
	{
		private By  _nextButtonLocator = By.CssSelector("button[data-name='next']");
		private By _approveButtonLocator = By.CssSelector("button[data-name='approve']");

		public void Click(String buttonName)
		{
			HtmlElement button;

			switch (buttonName)
			{
				case "Next":
					button = new HtmlElement(_nextButtonLocator);
					break;
				case "Approve":
					button = new HtmlElement(_approveButtonLocator);
					break;
				default:
					throw new NotImplementedException();
			}

			button.WaitElementAppears(50);
			button.Click();
		}
	}
}
