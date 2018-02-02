using OvernightPrintsSpecBindings.TestBase.Pages.Products;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	public class BuilderPageBindings
	{

		BuilderPage _builderPage = new BuilderPage();

		[When(@"I click (Next|Approve) button on ""(.*)"" Builder page")]
		public void WhenIClickNextButtonOnBuilderPage(string buttonName, string productName)
		{
			_builderPage.Click(buttonName);
		}

	}
}
