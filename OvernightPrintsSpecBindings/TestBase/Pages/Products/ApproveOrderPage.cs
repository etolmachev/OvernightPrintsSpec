using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Products
{
	public class ApproveOrderPage
	{
		private By _continueButtonLocator = By.CssSelector(".opt-right > button");
		private By _progressBarLocator = By.CssSelector("#approval-previews-preloader > img");

		private HtmlElement ContinueButton;
		private HtmlElement ProgressBar;

		public void WaitPageLoad(int timeout)
		{
			new HtmlElement(_progressBarLocator).WaitElementDisappear(timeout);
		}

		public void ClickContinueButton()
		{
			ContinueButton = new HtmlElement(_continueButtonLocator);
			ContinueButton.WaitElementAppears(30);
			ContinueButton.Click();
		}

	}
}
