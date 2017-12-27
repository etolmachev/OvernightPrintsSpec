using System;
using NUnit.Framework;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;
using static OvernightPrintsSpecBindings.TestBase.Pages.RegisterPopUpPage;
using static OvernightPrintsSpecBindings.Utils.Utils;

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
						string value = ParseString(Resolve(row["Value"]));
						_registerPopUpPage.TypeField(Fields.Email, value);
						break;
					case "Password":
						_registerPopUpPage.TypeField(Fields.Pass, ParseString(row["Value"]));
						break;
					case "Repassword":
						_registerPopUpPage.TypeField(Fields.VerifyPass, ParseString(row["Value"]));
						break;
					case "First Name":
						_registerPopUpPage.TypeField(Fields.FirstName, ParseString(row["Value"]));
						break;
					case "Last Name":
						_registerPopUpPage.TypeField(Fields.LastName, ParseString(row["Value"]));
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
					_registerPopUpPage.ClickButton(Buttons.X);
					break;
				case "Create My Account":
					_registerPopUpPage.ClickButton(Buttons.CreateAccount);
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
				Console.WriteLine("HelpBlock" + placeElement);
				foreach (HelpBlocks helpBlock in Enum.GetValues(typeof(HelpBlocks)))
				{
					if (helpBlock.ToString().Equals(placeElement))
					{
						currentMessage = _registerPopUpPage.GetMessageHelpBlock(helpBlock);
						Console.WriteLine(helpBlock.ToString());
						Console.WriteLine(currentMessage);
						break;
					}
				}
			}
			else
			{
				foreach (Fields field in Enum.GetValues(typeof(Fields)))
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
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(Fields.Email));
						break;

					case "Password":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(Fields.Pass));
						break;

					case "Repassword":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(Fields.VerifyPass));
						break;

					case "First Name":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(Fields.FirstName));
						break;

					case "Last Name":
						Assert.AreEqual(row["Value"], _registerPopUpPage.GetField(Fields.LastName));
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}

	}
}
