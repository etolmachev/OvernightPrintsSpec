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

		[When(@"I click (Log in|Log out|Create Business Cards|Create Postcards) button on Main Page")]
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
				case "Create Business Cards":
					_mainPage.ClickButtonBusinessCards();
					break;
				case "Create Postcards":
					_mainPage.ClickButtonPostcards();
					break;
				default:
					throw new NotImplementedException();
			}
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
