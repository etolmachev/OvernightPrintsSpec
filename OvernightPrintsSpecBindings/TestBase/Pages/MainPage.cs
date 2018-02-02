using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class MainPage
	{	
		private By _individualElementLocator = By.CssSelector(".rsContainer");
		private By _buttonLogInLocator = By.CssSelector("a[href='/login']");
		private By _buttonLogoutLocator = By.CssSelector("#logout-link");
		private By _buttonBusinessCardsLocator = By.CssSelector(".featured-prods-dynamic > div:nth-child(1) .block-button");
		private By _buttonPostcardsLocator = By.CssSelector(".featured-prods-dynamic > div:nth-child(2) .block-button");

		private HtmlElement IndividualElement;
		private HtmlElement ButtonLogInElement;
		private HtmlElement ButtonLogOutElement;
		private HtmlElement ButtonBusinessCards;
		private HtmlElement ButtonPostcards;


		public MainPage()
		{
			IndividualElement = new HtmlElement(_individualElementLocator);
			ButtonLogInElement = new HtmlElement(_buttonLogInLocator);

			ButtonBusinessCards = new HtmlElement(_buttonBusinessCardsLocator);
			ButtonPostcards = new HtmlElement(_buttonPostcardsLocator);
		}

		public void ClickButtonBusinessCards()
		{
			ButtonBusinessCards.Click();
		}

		public void ClickButtonPostcards()
		{
			ButtonPostcards.Click();
		}

		public void ClickLogout()
		{
			ButtonLogOutElement = new HtmlElement(_buttonLogoutLocator);
			ButtonLogOutElement.Click();
		}

		public bool IsDisplayedIndividualElement()
		{
			return IndividualElement.Displayed;
		}

		public void ClickLogIn()
		{
			ButtonLogInElement.Click();
		}
	}
}
