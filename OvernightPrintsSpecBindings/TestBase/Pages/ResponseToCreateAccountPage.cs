using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class ResponseToCreateAccountPage
	{
		private By _continueButtonLocator = By.CssSelector(".text-center a");
		private By _responseMessageLocator = By.CssSelector(".myonp-reg-confirmed h2");

		private HtmlElement ContinueButton;
		private HtmlElement ResponseMessage;

		public ResponseToCreateAccountPage()
		{
			ContinueButton = new HtmlElement(_continueButtonLocator);
			ResponseMessage = new HtmlElement(_responseMessageLocator);
		}

		public void ClickContinueButton()
		{
			ContinueButton.Click();
		}

		public string GetResponseMessage()
		{
			return ResponseMessage.Text;
		}
	}
}
