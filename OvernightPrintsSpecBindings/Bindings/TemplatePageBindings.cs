using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{
	[Binding]
	public class TemplatePageBindings
	{
		TemplatePage _templatePage = new TemplatePage();

		[When(@"I click Customize button on ""(.*)"" Template page")]
		public void WhenIClickCustomizeButtonOnTemplatePage(string productName)
		{
			_templatePage.ClickCustomize();
		}
	}
}
