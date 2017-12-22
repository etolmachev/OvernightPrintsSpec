using System;
using OpenQA.Selenium;
using static OvernightPrintsSpecBindings.Utils.Utils;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class ResetPasswordPopUpPage
	{
		private By _emailLocator = By.Id("username");
		private By _buttonResetPasswordLocator = By.CssSelector("[value=\"Reset Password\"]");
		private By _linkCancelLocator = By.CssSelector(".embedded-content-link, .cancel");
		private By _labelLocator = By.CssSelector(".myonp-container-reset .header-align");

		private HtmlElement EmailElement;
		private HtmlElement ButtonResetPasswordElement;
		private HtmlElement LinkCancelElement;
		private HtmlElement LabelElement;

		public ResetPasswordPopUpPage()
		{
			EmailElement = new HtmlElement(_emailLocator);
			ButtonResetPasswordElement = new HtmlElement(_buttonResetPasswordLocator);
			LinkCancelElement = new HtmlElement(_linkCancelLocator);
			LabelElement = new HtmlElement(_labelLocator);
		}

		public void TypeEmail(String email)
		{
			EmailElement.SendKeys(email);
		}

		public void ClickResetPassword()
		{
			ButtonResetPasswordElement.Click();
		}

		public void ClickCancel()
		{
			LinkCancelElement.Click();
		}

		public string GetLabelText()
		{
			LabelElement.WaitElementAppears(40);
			return LabelElement.Text;
		}

		public string GetStatusField()
		{

			string textValueMessage = "return document.getElementById(\"username\").attributes[0].ownerElement.validationMessage";
			string valueMessage = (string)ExecuteJavaScript(Browser.Driver, textValueMessage);

			return valueMessage;
		}
	}
}
