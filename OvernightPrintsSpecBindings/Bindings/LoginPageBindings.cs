using System;
using NUnit.Framework;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;
using static OvernightPrintsSpecBindings.Utils.Utils;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	class LoginPageBindings
	{
		LoginPopUpPage _popUpPage = new LoginPopUpPage();

		[When(@"I click (Forgot you password|Log in|X|Create My Account) button on Login popup")]
		public void WhenIClickButtonOnLoginPopup(string buttonName)
		{
			switch (buttonName)
			{
				case "Forgot you password":
					_popUpPage.ClickForgotYourPassword();
					break;
				case "Log in":
					_popUpPage.ClickLogIn();
					break;
				case "X":
					_popUpPage.ClickButtonReturn();
					break;

				case "Create My Account":
					_popUpPage.ClickCreateMyAccount();
					break;

				default:
					throw new NotImplementedException();
			}
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
                        _popUpPage.TypeEmail(ParseString(row["Value"]));
                        break;

                    case "Password":
                        _popUpPage.TypePass(row["Value"]);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
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
						Assert.AreEqual(row["Value"],_popUpPage.GetEmail());
						break;

					case "Password":
						Assert.AreEqual(row["Value"], _popUpPage.GetPass());
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}

		[Then(@"I see Login popup")]
		public void ThenISeeLoginPopup()
		{
			Assert.AreEqual("Log In".ToLower(), _popUpPage.GetTextLabel().ToLower());
		}
	}
}
