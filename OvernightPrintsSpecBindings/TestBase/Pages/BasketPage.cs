using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase.Pages.Products;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
	public class BasketPage
	{
		private readonly By _itemLocator = By.ClassName("cart-thumb");
		private readonly By _continueShoppingLinkLocator = By.CssSelector("#cart-empty > p > a");
		private readonly By _baskToShoppingButtonLocator = By.CssSelector("#cont-shop > a");
		private readonly By _individualElementInEmptyBasketLocator = By.CssSelector("#cart-empty h2");
		private readonly By _individualElementInNotEmptyBasketLocator = By.Id("order-num");
		private readonly By _professionalFileReviewDeclineLocator = By.CssSelector("#dsn-check > li:nth-child(3) > label");
		private readonly By _professionalFileReviewPrice = By.CssSelector("#dsn-check > li:nth-child(2) > label > span");
		private readonly By _totalOrderLocator = By.Id("order-total");
		private readonly By _quantityDropDownMenuLocator = By.CssSelector("#printeditem_1 .product-sku-choices .selectboxit-text");
		private readonly By _materialDropDownMenuLocator = By.CssSelector("#printeditem_1 .product-option-choices .selectboxit-btn");
		private readonly By _concreteQuantityItemLocator = By.CssSelector("#printeditem_1 li[data-price='$7.15']");
		private readonly By _concreteMaterialItemLocator = By.CssSelector("#printeditem_1 .product-option-choices .selectboxit-list > li[data-id='2']");
		private readonly By _quantityPriceLocator = By.CssSelector("#printeditem_1 .item-sku-price");
		private readonly By _materialPriceLocator = By.CssSelector("#printeditem_1 li[data-option-name='substrate']");
		private readonly By _inputFieldZipCodeLocator = By.Id("zipcode");
		private readonly By _applyZipCodeButtonLocator = By.Id("zip-btn");
		private readonly By _option2DayShippingLocator = By.CssSelector("#delivery > li:nth-child(3) .cart-shipping-name");
		private readonly By _optionBitGitLocator = By.CssSelector("#delivery > li:nth-child(1) .cart-shipping-name");
		private readonly By _option2DayShippingPriceLocator = By.CssSelector("#delivery > li:nth-child(3) .shipping-price");
		private readonly By _optionBitGitPriceLocator = By.CssSelector("#delivery > li:nth-child(1) .shipping-price");
		private readonly By _discountAddAnchorLocator = By.Id("add-coupon");
		private readonly By _inputFieldDiscountLocator = By.CssSelector("#discount-add input");
		private readonly By _redeemDiscountButtonLocator = By.Id("cpn-redeem");
		private readonly By _orderSubtotalLocator = By.Id("order-subtotal");
		private readonly By _progressBarLocator = By.CssSelector("div.action-in-progress-overlay");
		private readonly By _removeItemWindowLocator = By.CssSelector("div[aria-describedby='remove-item-confirm']");
		private readonly string _itemEntity = "//div[div/div/h2/span[contains(text(), '%s')]]";

		private HtmlElement ProgressBarOrderSummaryBlock;
		private HtmlElement RemoveItemWindow;

		public void Click(string buttonName)
		{
			HtmlElement htmlElement = null;

			switch (buttonName)
			{
				case "Continue Shopping":
					htmlElement = new HtmlElement(_continueShoppingLinkLocator);
					break;
				case "Back to shopping":
					htmlElement = new HtmlElement(_baskToShoppingButtonLocator);
					break;
				case "Professional File Review Decline":
					htmlElement = new HtmlElement(_professionalFileReviewDeclineLocator);
					break;
				case "Apply Zip Code":
					htmlElement = new HtmlElement(_applyZipCodeButtonLocator);
					break;
				case "2 Day Shipping":
					htmlElement = new HtmlElement(_option2DayShippingLocator);
					break;
				case "BITGIT":
					htmlElement = new HtmlElement(_optionBitGitLocator);
					break;
				case "Add Discount Anchor":
					htmlElement = new HtmlElement(_discountAddAnchorLocator);
					break;
				case "Redeem Discount":
					htmlElement = new HtmlElement(_redeemDiscountButtonLocator);
					break;
				default:
					throw new NotImplementedException();
			}
			htmlElement.WaitElementAppears(50);
			htmlElement.Click();
		}
		public void ClickDropDownMenu(string dropDownName, string value)
		{
			HtmlElement dropDownMenu = null;
			HtmlElement innerItem = null;
			switch (dropDownName)
			{
				case "Quantity":
					dropDownMenu = new HtmlElement(_quantityDropDownMenuLocator);
					innerItem = new HtmlElement(_concreteQuantityItemLocator);
					break;
				case "Material":
					dropDownMenu = new HtmlElement(_materialDropDownMenuLocator);
					innerItem = new HtmlElement(_concreteMaterialItemLocator);
					break;
				default:
					throw new NotImplementedException();
			}
			dropDownMenu.WaitElementAppears();
			dropDownMenu.Click();
			innerItem.WaitElementAppears();
			innerItem.Click();
		}
		public void RemoveProduct(string productName)
		{
			HtmlElement entity = new HtmlElement(By.XPath(_itemEntity.Replace("%s", productName)));
			HtmlElement removeButton = new HtmlElement(entity.FindElement(By.ClassName("js-remove")));
			removeButton.WaitElementAppears(50);
			removeButton.Click();
		}
		public bool IsBasketPage()
		{
			HtmlElement individualElement = null;
			try
			{
				individualElement = new HtmlElement(_individualElementInEmptyBasketLocator);
			}
			catch (NoSuchElementException e1)
			{
				try
				{
					individualElement = new HtmlElement(_individualElementInNotEmptyBasketLocator);
				}
				catch (NoSuchElementException e2) { }
			}

			

			if (individualElement != null)
			{
				return true;
			}

			return false;
		}
		public string GetTextElement(string elementName)
		{
			HtmlElement htmlElement = null;

			switch (elementName)
			{
				case "Total price":
					htmlElement = new HtmlElement(_totalOrderLocator);
					break;
				case "Professional File Review":
					htmlElement = new HtmlElement(_professionalFileReviewPrice);
					break;
				case "Quantity price":
					htmlElement = new HtmlElement(_quantityPriceLocator);
					break;
				case "Material price":
					htmlElement = new HtmlElement(_materialPriceLocator);
					break;
				case "2 Day Shipping price":
					htmlElement = new HtmlElement(_option2DayShippingPriceLocator);
					break;
				case "Bit Git price":
					htmlElement = new HtmlElement(_optionBitGitPriceLocator);
					break;
				case "Basket Is Empty":
					htmlElement = new HtmlElement(_individualElementInEmptyBasketLocator);
					break;
				case "Order SubTotal price":
					htmlElement = new HtmlElement(_orderSubtotalLocator);
					break;
				default:
					throw new NotImplementedException();
			}
			return htmlElement.Text;
		}
		public void SetField(String fieldName, String value)
		{
			HtmlElement htmlElement = null;

			switch (fieldName)
			{
				case "Discount Code":
					htmlElement = new HtmlElement(_inputFieldDiscountLocator);
					break;
				case "Shipping Zip Code":
					htmlElement = new HtmlElement(_inputFieldZipCodeLocator);
					break;
				default:
					throw new NotImplementedException();
			}

			htmlElement.WaitElementAppears(50);
			htmlElement.SendKeys(value);
		}
		public void PrepareBasket()
		{
			int n = Browser.Driver.FindElements(_itemLocator).Count;
			if (n != 0)
			{
				for (int i = 0; i < n; i++)
				{
					BasketPage page = new BasketPage();
					page.Click("Remove");
					Thread.Sleep(5);
					RemoveItemConfirmPopup removeItemConfirmPopup = new RemoveItemConfirmPopup();
					removeItemConfirmPopup.Click("Confirm");
				}
			}
		}
		public void WaitItemLoad(string productName, int timeout)
		{

			HtmlElement entity = new HtmlElement(By.XPath(_itemEntity.Replace("%s", productName)));
			HtmlElement htmlElement = new HtmlElement(entity.FindElement(By.ClassName("product-sku-choices")));

			int t = timeout;

			while (t > 0 && htmlElement.GetAttribute("class").Contains("loading"))
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
				t--;
			}
			if (htmlElement.GetAttribute("class").Contains("loading"))
			{
				throw new Exception(string.Format("Element isn't load after {0} seconds", timeout));
			}
		}
		public void WaitOrderSummaryBlockLoad(int timeout)
		{
			ProgressBarOrderSummaryBlock = new HtmlElement(_progressBarLocator);

			int t = timeout;

			while (t > 0 && ProgressBarOrderSummaryBlock.GetAttribute("class").Contains("is-active"))
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
				t--;
			}
			if (ProgressBarOrderSummaryBlock.GetAttribute("class").Contains("is-active"))
			{
				throw new Exception(string.Format("Element isn't load after {0} seconds", timeout));
			}
		}
		public void WaitBasketPageLoadAfterRemoveItem(int timeout)
		{
			RemoveItemWindow = new HtmlElement(_removeItemWindowLocator);

			int t = timeout;
			bool isExit = false;

			while (t > 0 && !isExit)
			{
				try
				{
					IWebElement webElement = RemoveItemWindow.WrappedElement;
					t--;
				}
				catch (NoSuchElementException ex)
				{
					isExit = true;
				}
			}

			if (!isExit)
			{
				throw new Exception(string.Format("Element isn't disappear after {0} seconds", timeout));
			}
			Browser.WaitReadyState(timeout);
		}
	}
}
