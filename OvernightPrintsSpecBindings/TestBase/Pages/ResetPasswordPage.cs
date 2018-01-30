using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class ResetPasswordPage
	{
		private By headerLocator = By.CssSelector(".myonp-container .header-align");
		private By passwordLocator = By.Id("password-first");
		private By validationLocator = By.Id("password-second");
		private By changePasswordButtonLocator = By.CssSelector(".controls > input[type='submit']");

		private HtmlElement Header;
		private HtmlElement Password;
		private HtmlElement Validation;
		private HtmlElement ChangePasswordButton;


		public ResetPasswordPage()
		{
			Header = new HtmlElement(headerLocator);
			Password = new HtmlElement(passwordLocator);
			Validation = new HtmlElement(validationLocator);
			ChangePasswordButton = new HtmlElement(changePasswordButtonLocator);
		}

		public bool IsResetPasswordPage(string header)
		{
			return header.ToLower().Equals(Header.Text.ToLower());
		}

		public void SetField(string fieldName,string value)
		{
			switch (fieldName)
			{
				case "Password":
					Password.SendKeys(value);
					break;
				case "Validation":
					Validation.SendKeys(value);
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public void ClickChangePasswordButton()
		{
			ChangePasswordButton.Click();
		}

	}
}
