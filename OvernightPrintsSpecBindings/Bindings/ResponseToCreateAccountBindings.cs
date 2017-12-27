using System;
using NUnit.Framework;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	class ResponseToCreateAccountBindings
	{
		ResponseToCreateAccountPage _page = new ResponseToCreateAccountPage(); 
		[Then(@"I see Response to Create Account Page")]
		public void ThenISeeResponseToCreateAccountPage()
		{
			Assert.That(_page.GetResponseMessage().ToLower().Contains("Thank you".ToLower()), Is.True);
		}

		[When(@"I click Continue button on the Response to Create Account Page")]
		public void WhenIClickContinueButtonOnTheResponseToCreateAccountPage()
		{
			_page.ClickContinueButton();
		}

	}
}
