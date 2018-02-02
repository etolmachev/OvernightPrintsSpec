using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using OvernightPrintsSpecBindings.TestBase.Pages.Objects;
using OvernightPrintsSpecBindings.TestBase.Pages.Products;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	public class BasketBindings
	{
		BasketPage _basketPage = new BasketPage();

		[Then(@"I see Basket Page")]
		public void ThenISeeBasketPage()
		{
			Assert.IsTrue(_basketPage.IsBasketPage());
		}

		[Then(@"I see Basket contains ""(.*)"" elements")]
		public void ThenISeeBasketContainsElements(int countElements)
		{
			Assert.AreEqual(countElements, GetAllItemsCart().Count);
		}

		[When(@"I click (Redeem Discount|Continue Shopping|Back to shopping|Professional File Review Decline|Apply Zip Code|2 Day Shipping|BITGIT|Add Discount Anchor) button on Basket Page")]
		public void WhenIClickButtonOnLoginPopup(string buttonName)
		{
			_basketPage.Click(buttonName);
		}

		[When(@"I remove ""(.*)"" item from basket")]
		public void WhenIRemoveItemFromBasket(string productName)
		{	
			_basketPage.RemoveProduct(productName);
			RemoveItemConfirmPopup removeItemConfirmPopup = new RemoveItemConfirmPopup();
			removeItemConfirmPopup.Click("Confirm");
		}

		[When(@"I click Property dropDownMenu and choose Value for the Product on Basket Page")]
		public void WhenIClickPropertyDropDownMenuAndChooseValueForTheProductOnBasketPage(Table table)
		{
			foreach (var row in table.Rows)
			{
				string property = row["Property"];
				string value = row["Value"];
				string product = row["Product"];

				_basketPage.ClickDropDownMenu(property,value,product);
			}
		}

		[When(@"I set (Discount Code|Shipping Zip Code) ""(.*)"" on the Basket Page")]
		public void WhenISetOnTheBasketPage(string fieldName, string value)
		{
			_basketPage.SetField(fieldName,value);
		}

		[Then(@"I delete items from the basket if they exist")]
		public void ThenIPrepareTheStateOfTheBasketForTheTest()
		{
			_basketPage.PrepareBasket();
		}

		[Then(@"I see following product on the Cart")]
		public void ThenISeeFollowingProductOnTheCart(Table table)
		{
			foreach (var row in table.Rows)
			{
				Assert.IsTrue(GetAllItemsCart().Contains(new BasketItem(row)));
			}
		}

		[Then(@"I don't see following product on the Cart")]
		public void ThenIDonTSeeFollowingProductOnTheCart(Table table)
		{
			foreach (var row in table.Rows)
			{
				Assert.IsFalse(GetAllItemsCart().Contains(new BasketItem(row)));
			}
		}

		[Then(@"I see the following properties in the shopping cart")]
		public void ThenISeeTheFollowingPropertiesInTheShoppingCart(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Property"];
				string result = _basketPage.GetTextElement(key);

				Assert.AreEqual(row["Value"],result);
			}
		}

		private static readonly By _itemActuallyEntityLocator = By.ClassName("printeditem");
		public static List<BasketItem> GetAllItemsCart()
		{
			List<BasketItem> items = new List<BasketItem>();

			ReadOnlyCollection<IWebElement> entities = Browser.Driver.FindElements(_itemActuallyEntityLocator);
			foreach (var entity in entities)
			{
				items.Add(new BasketItem(new HtmlElement(entity)));
			}

			return items;
		}
	}
}
