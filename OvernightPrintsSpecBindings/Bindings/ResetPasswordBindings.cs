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

		[When(@"I click Reset Password Button on Reset Password popup")]
		public void WhenIClickResetPasswordButtonOnResetPasswordPopup()
		{
			_resetPasswordPopUp.ClickResetPassword();
		}

		[Then(@"I see notification message about successful reset password")]
		public void ThenISeeNotificationMessageAboutSuccessfulResetPassword()
		{
			HtmlElement labelElement = new HtmlElement(By.CssSelector("#body-main > div > div > div.myonp.myonp-container.myonp-container-reset.header-align > h4"));
			Assert.AreEqual("An email has been sent. It contains a link you must click to reset your password.", labelElement.Text);
		}

		[When(@"I click Cancel Button on Reset Password popup")]
		public void WhenIClickCancelButtonOnResetPasswordPopup()
		{
			_resetPasswordPopUp.ClickCancel();
		}

		[Then(@"I see  status fill field")]
		public void ThenICheckStatusFillField()
		{
			Console.WriteLine(_resetPasswordPopUp.GetStatusField());
		}

		[Then(@"I see an error message on Reset Password popup with")]
		public void ThenISeeAnErrorMessageOnResetPasswordPopupWith(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];

				switch (key)
				{
					case "Message":
						Assert.That(_resetPasswordPopUp.GetStatusField().Contains(row["Value"]), Is.True);
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}
	}
}
