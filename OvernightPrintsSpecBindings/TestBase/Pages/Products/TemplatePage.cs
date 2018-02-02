using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class TemplatePage
	{
		private By _customizeButtonLocator = By.CssSelector("#gallery-templates > div:nth-child(4) > div.gallery-template-title > a");

		private HtmlElement CustomizeButton;

		public TemplatePage()
		{
			CustomizeButton = new HtmlElement(_customizeButtonLocator);
		}

		public void ClickCustomize()
		{
			CustomizeButton.Click();
		}

	}
}
