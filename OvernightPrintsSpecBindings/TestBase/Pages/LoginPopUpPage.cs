using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class LoginPopUpPage
	{
		private By _emailLocator = By.Id("username");
		private By _passLocator = By.Id("password");
		private By _linkForgotYourPasswordLocator = By.CssSelector("a[href=\"/resetting/request\"]"); 
		private By _buttonLogInSubmitLocator = By.CssSelector(".controls button");
		private By _buttonCreateMyAccountLocator = By.CssSelector("a[href=\"/register/\"]");
		private By _buttonCloseLocator = By.CssSelector("[title=\"close-login\"]");
		private By _messageErrorLocator = By.CssSelector(".text-error");
		private By _labelLocator = By.CssSelector(".myonp-login-pane.log-in > h1");


		private HtmlElement EmailElement;
		private HtmlElement PassElement;
		private HtmlElement LinkForgotYourPasswordElement;
		private HtmlElement ButtonLogInSubmitElement;
		private HtmlElement ButtonCreateMyAccount;
		private HtmlElement ButtonReturnElement;
		private HtmlElement MessageErrorElement;
		private HtmlElement LabelElement;

		public LoginPopUpPage()
		{
			EmailElement = new HtmlElement(_emailLocator);
			PassElement = new HtmlElement(_passLocator);
			LinkForgotYourPasswordElement = new HtmlElement(_linkForgotYourPasswordLocator);
			ButtonLogInSubmitElement = new HtmlElement(_buttonLogInSubmitLocator);
			ButtonCreateMyAccount = new HtmlElement(_buttonCreateMyAccountLocator);
			//ButtonReturnElement = new HtmlElement(_buttonCloseLocator);
			LabelElement = new HtmlElement(_labelLocator);
		}

		public void TypeEmail(String email)
		{
			EmailElement.SendKeys(email);
		}

		public string GetEmail()
		{
			return EmailElement.Text;
		}
		public void TypePass(String pass)
		{
			PassElement.SendKeys(pass);
		}

		public string GetPass()
		{
			return PassElement.Text;
		}

		public void ClickLogIn()
		{
			ButtonLogInSubmitElement.Click();
		}

		public void ClickCreateMyAccount()
		{
			ButtonCreateMyAccount.Click();
		}

		public void ClickForgotYourPassword()
		{
			LinkForgotYourPasswordElement.Click();
		}

		public void ClickButtonReturn()
		{
			try
			{
				ButtonReturnElement = new HtmlElement(_buttonCloseLocator);
				ButtonReturnElement.Click();
			}
			catch (NoSuchElementException ex)
			{
				new HtmlElement(By.CssSelector("div .logo a[href='/']")).Click();
			}
		}

		public string GetTextMessageError()
		{
			MessageErrorElement = new HtmlElement(_messageErrorLocator);
			return MessageErrorElement.Text;
		}

		public string GetTextLabel()
		{
			return LabelElement.Text;
		}
	}
}
