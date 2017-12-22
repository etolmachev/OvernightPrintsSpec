using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class MainPage
	{
		private By _buttonLogInLocator = By.CssSelector("a[href='/login']");
		private By _myAccountLocator = By.CssSelector(".my-account-text");
		private By _userNameLocator = By.CssSelector(".user-name");

		private HtmlElement ButtonLogInElement;
		private HtmlElement MyAccountElement;
		private HtmlElement UserNameElement;

		public MainPage()
		{
			ButtonLogInElement = new HtmlElement(_buttonLogInLocator);
		}

		public void ClickLogIn()
		{
			ButtonLogInElement.Click();
		}

		public string GetTextMyAccount()
		{
			MyAccountElement = new HtmlElement(_myAccountLocator);
			return MyAccountElement.Text;
		}

		public string GetUserName()
		{
			string result = String.Empty;

			try
			{
				UserNameElement = new HtmlElement(_userNameLocator);
				result = UserNameElement.Text;
			}
			catch (NoSuchElementException ex)
			{}
			return result;
		}
	}
}
