using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	class LoginPageBindings
	{
		LoginPopUpPage _popUpPage = new LoginPopUpPage();

		[When(@"I click Log in button on Login popup")]
		public void WhenIClickLogInButton()
		{
			_popUpPage.ClickLogIn();
		}

		[Then(@"I see displayed link MY ACCOUNT")]
		public void WhenISeeDisplayedLinkMyAccount()
		{
			HtmlElement linkElement = new HtmlElement(By.CssSelector("#my-account > span"));
			linkElement.WaitElementAppears(5);
			String textLink = linkElement.Text;
			Assert.AreEqual(textLink, "MY ACCOUNT");
		}

		[When(@"I set following parameters on Login popup")]
		public void WhenISetFollowingParametersOnLoginPopUpPage(Table table)
        {
            foreach (var row in table.Rows)
            {
                string key = row["Field"];

                switch (key)
                {
                    case "Email Address":
                        _popUpPage.TypeEmail(row["Value"]);
                        break;

                    case "Password":
                        _popUpPage.TypePass(row["Value"]);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

		[Then(@"I see an error message on the Login popup with")]
		public void ThenISeeAnErrorMessageWith(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];

				switch (key)
				{
					case "Message":
						Assert.AreEqual(row["Value"], _popUpPage.GetTextMessageError());
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}

		[When(@"I click Return button on Login popup")]
		public void WhenIClickReturnButtonOnLoginPopup()
		{
			_popUpPage.ClickButtonReturn();
		}

		[When(@"I set email ""(.*)"" on Login popup")]
		public void WhenISetEmailOnLoginPopup(string email)
		{
			_popUpPage.TypeEmail(email);
		}

		[When(@"I set password ""(.*)"" on Login popup")]
		public void WhenISetPasswordOnLoginPopup(string password)
		{
			_popUpPage.TypePass(password);
		}

		[When(@"I click Forgot you password on Login popup")]
		public void WhenIClickForgotYouPasswordOnLoginPopup()
		{
			_popUpPage.ClickForgotYourPassword();
		}

		[Then(@"I see following information on Login popup")]
		public void ThenISeeFollowingInformationOnLoginPopup(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];

				switch (key)
				{
					case "Email Address":
						Assert.AreEqual("",_popUpPage.GetEmail());
						break;

					case "Password":
						Assert.AreEqual("", _popUpPage.GetPass());
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}

		[Then(@"I see Login popup")]
		public void ThenISeeLoginPopup()
		{
			Assert.AreEqual("LOG IN",_popUpPage.GetTextLabel());
		}
	}
}
