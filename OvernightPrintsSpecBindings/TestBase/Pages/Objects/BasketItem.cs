
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.TestBase.Pages.Objects
{
	public class BasketItem
	{

		private string productName;
		private string quantityPrice;
		private string materialPrice;
		private string itemSubtotal;

		private static readonly By _headerItemLocator = By.ClassName("item-title");
		private static readonly By _quantityPriceItemLocator = By.ClassName("item-sku-price");
		private static readonly By _materialPriceItemLocator = By.CssSelector("ul > li > div > div.product-choice-price");
		private static readonly By _itemSubtotalItemLocator = By.ClassName("sale-price");

		public BasketItem(TableRow row)
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

		public BasketItem(HtmlElement entity)
		{
			this.productName = entity.FindElement(_headerItemLocator).Text;
			this.quantityPrice = entity.FindElement(_quantityPriceItemLocator).Text;
			this.materialPrice = entity.FindElement(_materialPriceItemLocator).Text;
			this.itemSubtotal = entity.FindElement(_itemSubtotalItemLocator).Text;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			BasketItem item = (BasketItem) obj;

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
