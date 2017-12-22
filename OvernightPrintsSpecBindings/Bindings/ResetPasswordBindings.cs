using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	class ResetPasswordBindings
	{
		ResetPasswordPopUpPage _resetPasswordPopUp = new ResetPasswordPopUpPage();

		[Then(@"I see Reset Password popup")]
		public void ThenISeeResetPasswordPopup()
		{
			Assert.AreEqual("RESET PASSWORD", _resetPasswordPopUp.GetLabelText());
			
		}

		[When(@"I set following parameters on Reset Password popup")]
		public void WhenISetFollowingParametersOnResetPasswordPopup(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];

				switch (key)
				{
					case "Email Address":
						_resetPasswordPopUp.TypeEmail(row["Value"]);
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}

		[When(@"I click (Reset Password|Replace password) button on Reset Password popup")]
		public void WhenIClickButtonOnResetPasswordPopup(string buttonName)
		{
			switch (buttonName)
			{
				case "Reset Password":
					_resetPasswordPopUp.ClickResetPassword();
					break;

				case "Replace password":
					_resetPasswordPopUp.ClickCancel();
					break;

				default:
					throw new NotImplementedException();
			}
		}


	}
}
