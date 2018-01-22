using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Products
{
	public class RemoveItemConfirmPopup
	{
		private readonly By _headerPageLocator = By.CssSelector("#remove-item-confirm > div > h3");
		private readonly By _confirmButtonLocator = By.Id("remove-yes");
		private readonly By _declineButtonLocator = By.Id("remove-no");

		private HtmlElement HeaderPageElement;
		private HtmlElement ConfirmButton;
		private HtmlElement DeclineButton;

		public RemoveItemConfirmPopup()
		{
			HeaderPageElement = new HtmlElement(_headerPageLocator);
			ConfirmButton = new HtmlElement(_confirmButtonLocator);
			ConfirmButton.WaitElementAppears();
			DeclineButton = new HtmlElement(_declineButtonLocator);
			DeclineButton.WaitElementAppears();
		}

		public void Click(String buttonName)
		{
			switch (buttonName)
			{
				case "Confirm":
					ConfirmButton.Click();
					break;
				case "Decline":
					DeclineButton.Click();
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public string GetHeader()
		{
			return HeaderPageElement.Text;
		}
	}
}
