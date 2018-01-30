using System;
using NUnit.Framework;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	class MainPageBindings
	{
		MainPage _mainPage = new MainPage();

		[When(@"I click (Log in|Log out) button on Main Page")]
		public void WhenIClickLogInButton(string buttonName)
		{
			switch (buttonName)
			{
				case "Log in":
					_mainPage.ClickLogIn();
					break;
				case "Log out":
					_mainPage.ClickLogout();
					break;
				default:
					throw new NotImplementedException();
			}
		}

		[Then(@"I see element My Account on the Main page")]
		public void ThenISeeElementOnTheMainPage()
		{
			Assert.AreEqual("My Account", _mainPage.GetTextMyAccount());
		}

		[Then(@"I see that user is not logged in")]
		public void ThenISeeThatUserIsNotLoggedIn()
		{
			Assert.AreEqual(string.Empty,_mainPage.GetUserName());
		}

		[Then(@"I see that user ""(.*)"" is logged in")]
		public void ThenISeeThatUserIsLoggedIn(string expectedUserName)
		{
			Assert.AreEqual(Utils.Resolve(expectedUserName),_mainPage.GetUserName());
		}

		[Then(@"I see Main page")]
		public void ThenISeeMainPage()
		{
			if (_mainPage.IsDisplayedIndividualElement())
			{
				string url = Browser.Driver.Url;
				Assert.AreEqual("https://www.overnightprints.com/", url);
			}
			else
			{
				Assert.Fail();
			}
		}
	}
}
