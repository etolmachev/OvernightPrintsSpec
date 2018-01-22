
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Objects
{
	public class SearchItemBasket
	{

		private string productName;
		private string quantityPrice;
		private string materialPrice;
		private string itemSubtotal;

		private readonly string _itemExpectedEntityLocator = "//div[div/div/h2/span[contains(text(), '%s')]]";
		private static readonly By _itemActuallyEntityLocator = By.ClassName("printeditem");
		private static readonly By _headerItemLocator = By.ClassName("item-title");
		private static readonly By _quantityPriceItemLocator = By.ClassName("item-sku-price");
		private static readonly By _materialPriceItemLocator = By.CssSelector("ul > li > div > div.product-choice-price");
		private static readonly By _itemSubtotalItemLocator = By.ClassName("sale-price");

		public SearchItemBasket(TableRow row)
		{

			this.productName = GetValue(row,"Name");
			this.quantityPrice = GetValue(row,"Quantity Price");
			this.materialPrice = GetValue(row,"Material Price");
			this.itemSubtotal = GetValue(row,"Item Subtotal");
		}

		private string GetValue(TableRow row, string key)
		{
			string result = "*";
			try
			{
				result = row[key];
			}
			catch (IndexOutOfRangeException ex) { }
			return result;
		}

		public SearchItemBasket(HtmlElement entity)
		{
			this.productName = entity.FindElement(_headerItemLocator).Text;
			this.quantityPrice = entity.FindElement(_quantityPriceItemLocator).Text;
			this.materialPrice = entity.FindElement(_materialPriceItemLocator).Text;
			this.itemSubtotal = entity.FindElement(_itemSubtotalItemLocator).Text;
		}

		public SearchItemBasket()
		{
		}

		public static List<SearchItemBasket> GetAllItemsCart()
		{
			List<SearchItemBasket> items = new List<SearchItemBasket>();

			ReadOnlyCollection<IWebElement> entities = Browser.Driver.FindElements(_itemActuallyEntityLocator);
			foreach (var entity in entities)
			{
				SearchItemBasket item = new SearchItemBasket();
				item.productName = entity.FindElement(_headerItemLocator).Text;
				item.quantityPrice = entity.FindElement(_quantityPriceItemLocator).Text;
				item.materialPrice = entity.FindElement(_materialPriceItemLocator).Text;
				item.itemSubtotal = entity.FindElement(_itemSubtotalItemLocator).Text;

				items.Add(item);
			}

			return items;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			SearchItemBasket item = (SearchItemBasket) obj;

			if (this.productName.Equals("*") || item.productName.Equals("*") || this.productName.Contains(item.productName))
			{
				if (this.quantityPrice.Equals("*") || item.quantityPrice.Equals("*") || this.quantityPrice.Equals(item.quantityPrice))
				{
					if (this.materialPrice.Equals("*") || item.materialPrice.Equals("*") || this.materialPrice.Equals(item.materialPrice))
					{
						if (this.itemSubtotal.Equals("*") || item.itemSubtotal.Equals("*") || this.itemSubtotal.Equals(item.itemSubtotal))
						{
							return true;
						}
					}
				}
			}

			return false;
		}
	}
}
