using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Products
{
	public class ProductPage
	{

		private By _getStartedButtonBussinessCardsLocator = By.CssSelector(".bnr > a");
		private By _getStartedPostcardsLocator = By.CssSelector(".banner-headers > a");

		private HtmlElement GetStartedButton;


		public void ClickGetStarted(String productName)
		{

			switch (productName)
			{
				case "Business Cards":
					GetStartedButton = new HtmlElement(_getStartedButtonBussinessCardsLocator);
					break;
				case "Postcards":
					GetStartedButton = new HtmlElement(_getStartedPostcardsLocator);
					break;
				default:
					throw new NotImplementedException();
			}
			GetStartedButton.Click();
		}
	}
}
