
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Products
{
	public class MailingListPage
	{
		private By _skipButtonLocator = By.CssSelector("a[data-action='skip']");

		private HtmlElement SkipButton;

		public void ClickSkipButton()
		{
			new HtmlElement(_skipButtonLocator).Click();
		}
	}
}
