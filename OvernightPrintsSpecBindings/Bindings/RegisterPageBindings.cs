using System;
using NUnit.Framework;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	class RegisterPageBindings
	{
		RegisterPopUpPage _registerPopUpPage = new RegisterPopUpPage();

		[Then(@"I see Register popup")]
		public void ThenISeeRegisterPopup()
		{
			Assert.AreEqual("Create An Account".ToLower(),_registerPopUpPage.GetLabelPage().ToLower());
		}

		[When(@"I set following parameters on Register popup")]
		public void WhenISetFollowingParametersOnRegisterPopup(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];

				switch (key)
				{
					case "Email Address":
						_registerPopUpPage.TypeField(RegisterPopUpPage.Fields.Email, Utils.ParseString(Utils.Resolve(row["Value"])));
						break;
					case "Password":
						_registerPopUpPage.TypeField(RegisterPopUpPage.Fields.Pass, Utils.ParseString(row["Value"]));
						break;
					case "Repassword":
						_registerPopUpPage.TypeField(RegisterPopUpPage.Fields.VerifyPass, Utils.ParseString(row["Value"]));
						break;
					case "First Name":
						_registerPopUpPage.TypeField(RegisterPopUpPage.Fields.FirstName, Utils.ParseString(row["Value"]));
						break;
					case "Last Name":
						_registerPopUpPage.TypeField(RegisterPopUpPage.Fields.LastName, Utils.ParseString(row["Value"]));
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}

		[When(@"I click (X|Create My Account) button on Register popup")]
		public void WhenIClickCreateMyAccountButtonOnRegisterPopup(String buttonName)
		{
			switch (buttonName)
			{
				case "X":
					_registerPopUpPage.ClickButton(RegisterPopUpPage.Buttons.X);
					break;
				case "Create My Account":
					_registerPopUpPage.ClickButton(RegisterPopUpPage.Buttons.CreateAccount);
					break;
				default:
					throw new NotImplementedException();
			}
		}

		[Then(@"I see notification message ""(.*)"" on the Register popup on the element ""(.*)""")]
		public void ThenISeeNotificationMessageOnTheRegisterPopupOnTheElement(string expectedMessage, string placeElement)
		{
			string currentMessage = String.Empty;
			if (placeElement.Contains("HelpBlock"))
			{
				foreach (RegisterPopUpPage.HelpBlocks helpBlock in Enum.GetValues(typeof(RegisterPopUpPage.HelpBlocks)))
				{
					if (helpBlock.ToString().Equals(placeElement))
					{
						currentMessage = _registerPopUpPage.GetMessageHelpBlock(helpBlock);
						break;
					}
				}
			}
			else
			{
				foreach (RegisterPopUpPage.Fields field in Enum.GetValues(typeof(RegisterPopUpPage.Fields)))
				{
					if (field.ToString().Equals(placeElement))
					{
						currentMessage = _registerPopUpPage.GetMessageField(field);
						break;
					}
				}
			}
			Assert.AreEqual(expectedMessage,currentMessage);
		}

		[Then(@"I see following information on Register popup")]
		public void ThenISeeFollowingInformationOnRegisterPopup(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];

				switch (key)
				{
					case "Email Address":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(RegisterPopUpPage.Fields.Email));
						break;

					case "Password":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(RegisterPopUpPage.Fields.Pass));
						break;

					case "Repassword":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(RegisterPopUpPage.Fields.VerifyPass));
						break;

					case "First Name":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(RegisterPopUpPage.Fields.FirstName));
						break;

					case "Last Name":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(RegisterPopUpPage.Fields.LastName));
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}

	}
}
