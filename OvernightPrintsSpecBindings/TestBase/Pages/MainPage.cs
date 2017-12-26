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
		private By _individualElementLocator = By.CssSelector(".rsContainer");

		private By _buttonLogInLocator = By.CssSelector("a[href='/login']");
		private By _myAccountLocator = By.CssSelector(".my-account-text");
		private By _userNameLocator = By.CssSelector(".user-name");
		private By _buttonLogoutLocator = By.CssSelector("#logout-link");

		private HtmlElement IndividualElement;

		private HtmlElement ButtonLogInElement;
		private HtmlElement MyAccountElement;
		private HtmlElement UserNameElement;
		private HtmlElement ButtonLogOutElement;

		public MainPage()
		{
			IndividualElement = new HtmlElement(_individualElementLocator);
			ButtonLogInElement = new HtmlElement(_buttonLogInLocator);
		}

		public void ClickLogout()
		{
			ButtonLogOutElement = new HtmlElement(_buttonLogoutLocator);
			ButtonLogOutElement.Click();
		}

		public bool IsDisplayedIndividualElement()
		{
			return IndividualElement.Displayed;
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
				string temp = result.Substring(result.IndexOf(",") + 2);
				result = temp;
			}
			catch (NoSuchElementException ex)
			{}
			return result;
		}
	}
}
