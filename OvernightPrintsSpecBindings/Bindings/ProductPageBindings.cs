using OvernightPrintsSpecBindings.TestBase.Pages.Products;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	public class ProductPageBindigns
	{

		ProductPage _productPage = new ProductPage();

		[When(@"I click Get Started button on ""(.*)"" Product page")]
		public void WhenIClickGetStartedButtonOnProductPage(string productName)
		{
			_productPage.ClickGetStarted(productName);
		}
	}
}
