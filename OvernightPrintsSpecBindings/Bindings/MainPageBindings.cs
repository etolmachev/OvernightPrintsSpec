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

		[When(@"I click Log in button on Main Page")]
		public void WhenIClickLogInButton()
		{
			_mainPage.ClickLogIn();
		}

		[Then(@"I see element My Account on the Main page")]
		public void ThenISeeElementOnTheMainPage()
		{
			Assert.AreEqual("My Account", _mainPage.GetTextMyAccount());
		}


		[Then(@"I see that user is not logged in")]
		public void ThenISeeThatUserIsNotLoggedIn()
		{
			Assert.AreEqual(false,_mainPage.IsExistUserName());
		}

		[Then(@"I see that user is logged in")]
		public void ThenISeeThatUserIsLoggedIn()
		{
			Assert.AreEqual(true, _mainPage.IsExistUserName());
		}

		[Then(@"I see Main page")]
		public void ThenISeeMainPage()
		{
			string url = Browser.Driver.Url;
			Assert.AreEqual("https://www.overnightprints.com/",url);
		}
	}
}
