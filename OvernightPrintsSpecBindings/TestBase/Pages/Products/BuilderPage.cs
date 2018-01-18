
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
			HtmlElement htmlElement;

			switch (buttonName)
			{
				case "Next":
					htmlElement = new HtmlElement(_nextButtonLocator);
					break;
				case "Approve":
					htmlElement = new HtmlElement(_approveButtonLocator);
					break;
				default:
					throw new NotImplementedException();
			}

			htmlElement.WaitElementAppears(50);
			htmlElement.Click();
		}
	}
}
