using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class RegisterPopUpPage
	{
		private By _labelLocator = By.CssSelector("#registration-form h1");

		private By _emailLocator = By.Id("email");
		private By _passLocator = By.Id("password");
		private By _verifyLocator = By.Id("password-confirm");
		private By _firstNameLocator = By.Id("firstname");
		private By _lastNameLocator = By.Id("lastname");

		private By _createAccountButtonLocator = By.Id("button");
		private By _xButtonLocator = By.CssSelector("[title=\"close-login\"]");

		private By _emailHelpBlockLocator = By.CssSelector(".controls > #email + .help-block");
		private By _passHelpBlockLocator = By.CssSelector(".controls > #password + .help-block");
		private By _firstNameHelpBlockLocator = By.CssSelector(".controls > #firstname + .help-block");
		private By _lastNameHelpBlockLocator = By.CssSelector(".controls > #lastname + .help-block");

		private HtmlElement LabelElement;

		private HtmlElement EmailElement;
		private HtmlElement PassElement;
		private HtmlElement VerifyPassElement;
		private HtmlElement FirstNameElement;
		private HtmlElement LastNameElement;

		private HtmlElement CreateAccountButton;
		private HtmlElement XButton;

		private HtmlElement EmailHelpBlock;
		private HtmlElement PassHelpBlock;
		private HtmlElement FirstNameHelpBlock;
		private HtmlElement LastNameHelpBlock;

		public RegisterPopUpPage()
		{
			LabelElement = new HtmlElement(_labelLocator);

			EmailElement = new HtmlElement(_emailLocator);
			PassElement = new HtmlElement(_passLocator);
			VerifyPassElement = new HtmlElement(_verifyLocator);
			FirstNameElement = new HtmlElement(_firstNameLocator);
			LastNameElement = new HtmlElement(_lastNameLocator);

			CreateAccountButton = new HtmlElement(_createAccountButtonLocator);
			XButton = new HtmlElement(_xButtonLocator);
		}

		public string GetLabelPage()
		{
			return LabelElement.Text;
		}

		public enum Fields
		{
			Email, Pass,
			VerifyPass, 
			FirstName,
			LastName
		}

		public void TypeField(Fields field, String value)
		{
			HtmlElement currentField = null;
			switch (field)
			{
				case Fields.Email:
					currentField = EmailElement;
					break;
				case Fields.Pass:
					currentField = PassElement;
					break;
				case Fields.VerifyPass:
					currentField = VerifyPassElement;
					break;
				case Fields.FirstName:
					currentField = FirstNameElement;
					break;
				case Fields.LastName:
					currentField = LastNameElement;
					break;
			}
			currentField.SendKeys(value);
		}

		public string GetField(Fields field)
		{
			string result = String.Empty;
			switch (field)
			{
				case Fields.Email:
					result = EmailElement.Text;
					break;
				case Fields.Pass:
					result =PassElement.Text;
					break;
				case Fields.VerifyPass:
					result = VerifyPassElement.Text;
					break;
				case Fields.FirstName:
					result = FirstNameElement.Text;
					break;
				case Fields.LastName:
					result = LastNameElement.Text;
					break;
			}
			return result;
		}

		public enum Buttons
		{
			CreateAccount, X
		}

		public void ClickButton(Buttons button)
		{
			switch (button)
			{
				case Buttons.CreateAccount:
					CreateAccountButton.Click();
					break;
				case Buttons.X:
					XButton.Click();
					break;
			}
		}

		public enum HelpBlocks
		{
			EmailHelpBlock,
			PassHelpBlock,
			FirstNameHelpBlock,
			LastNameHelpBlock
		}

		public string GetMessageHelpBlock(HelpBlocks block)
		{
			string result = String.Empty;
			switch (block)
			{
				case HelpBlocks.EmailHelpBlock:
					EmailHelpBlock = new HtmlElement(_emailHelpBlockLocator);
					result = EmailHelpBlock.Text;
					break;
				case HelpBlocks.PassHelpBlock:
					PassHelpBlock = new HtmlElement(_passHelpBlockLocator);
					result = PassHelpBlock.Text;
					break;
				case HelpBlocks.FirstNameHelpBlock:
					FirstNameHelpBlock = new HtmlElement(_firstNameHelpBlockLocator);
					result = FirstNameHelpBlock.Text;
					break;
				case HelpBlocks.LastNameHelpBlock:
					LastNameHelpBlock = new HtmlElement(_lastNameHelpBlockLocator);
					result = LastNameHelpBlock.Text;
					break;
			}
			return result;
		}

		public string GetMessageField(Fields field)
		{
			string javascript = "return document.getElementById(";
			switch (field)
			{
				case Fields.Email:
					javascript += "\"email\"";
					break;
				case Fields.Pass:
					javascript += "\"password\"";
					break;
				case Fields.VerifyPass:
					javascript += "\"password-confirm\"";
					break;
				case Fields.FirstName:
					javascript += "\"firstname\"";
					break;
				case Fields.LastName:
					javascript += "\"lastname\"";
					break;
			}
			javascript += ").attributes[0].ownerElement.validationMessage";
			string valueMessage = (string)Utils.Utils.ExecuteJavaScript(Browser.Driver, javascript);
			return valueMessage;
		}

	}
}
