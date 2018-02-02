
using OvernightPrintsSpecBindings.TestBase.Pages.Products;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	public class ApproveOrderPageBindings
	{
		ApproveOrderPage _approveOrderPage = new ApproveOrderPage();

		[When(@"I click Continue Order button on ""(.*)"" Approve Order Page")]
		public void WhenIClickContinueOrderButtonOnApproveOrderPage(string productName)
		{
			_approveOrderPage.ClickContinueButton();
		}

	}
}
