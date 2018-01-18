
using OvernightPrintsSpecBindings.TestBase.Pages.Products;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	public class MailingListPageBindings
	{
		MailingListPage _mailingListPage = new MailingListPage();

		[When(@"I click Skip button on ""(.*)"" Mailing List Page")]
		public void WhenIClickSkipButtonOnMailingListPage(string productName)
		{
			_mailingListPage.ClickSkipButton();
		}

	}
}
