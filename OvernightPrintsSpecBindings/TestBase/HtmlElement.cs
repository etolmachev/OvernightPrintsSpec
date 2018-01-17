using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OvernightPrintsSpecBindings.TestBase
{
	public class HtmlElement : IWebElement
	{
		private readonly How _locatorHow;
		private readonly string _locatorString;

		private By _elementLocator;
		private IWebElement _wrappedElement;

		public IWebElement WrappedElement
		{
			get { return GetWebElement(); }
			private set { _wrappedElement = value; }
		}

		public HtmlElement(By thisElementLocator)
		{
			_elementLocator = thisElementLocator;
		}

		public HtmlElement(IWebElement element)
		{
			_wrappedElement = element;
		}

		private IWebElement GetWebElement()
		{
			if (_elementLocator != null && _wrappedElement == null)
			{
				GetThisElement();
			}

			try
			{
				// Get element property to define if is still valid
				var t = _wrappedElement.Enabled;
			}
			catch (StaleElementReferenceException)
			{
				GetThisElement();
			}

			return _wrappedElement;
		}

		private void GetThisElement()
		{
			IWebElement element;

			if (null == _elementLocator)
			{
				throw new ArgumentException(string.Format("Unable to locate element. Locator is not provided."));
			}

			try
			{
				element = Browser.Driver.FindElement(_elementLocator);
			}
			catch (NoSuchElementException)
			{
				element = null;
			}

			if (element == null)
			{
				throw new NoSuchElementException(string.Format("Locator {0} does not match any element",
					string.Join(", ", _elementLocator)));
			}
			WrappedElement = element;
		}

		public void WaitElementAppears(int timeout = 30)
		{
			int t = timeout;
			while (t > 0 && !WrappedElement.Displayed)
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
				t--;
			}
			if (!WrappedElement.Displayed)
			{
				throw new Exception(string.Format("Element isn't displayed after {0} seconds", timeout));
			}
		}
		public void WaitElementDisappear(int timeout = 30)
		{
			int t = timeout;
			while (t > 0 && WrappedElement.Displayed)
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
				t--;
			}
			if (WrappedElement.Displayed)
			{
				throw new Exception(string.Format("Element isn't disappear after {0} seconds", timeout));
			}
		}

		//Implement Interface properties and methods
		#region
		public void Click()
		{
			WrappedElement.Click();
		}

		public void Submit()
		{
			WrappedElement.Submit();
		}

		public void SendKeys(string keys)
		{
			WrappedElement.SendKeys(keys);
		}

		public void Clear()
		{
			WrappedElement.Clear();
		}

		public string GetCssValue(string name)
		{
			return WrappedElement.GetCssValue(name);
		}

		public string GetAttribute(string name)
		{
			return WrappedElement.GetAttribute(name);
		}

		public string TagName
		{
			get { return WrappedElement.TagName; }
		}

		public string Text
		{
			get { return WrappedElement.Text; }
		}

		public bool Enabled
		{
			get { return WrappedElement.Enabled; }
		}

		public bool Selected
		{
			get { return WrappedElement.Selected; }
		}

		public Point Location
		{
			get { return WrappedElement.Location; }
		}

		public Size Size
		{
			get { return WrappedElement.Size; }
		}

		public bool Displayed
		{
			get { return WrappedElement.Displayed; }
		}

		public IWebElement FindElement(By by)
		{
			return WrappedElement.FindElement(by);
		}

		public ReadOnlyCollection<IWebElement> FindElements(By by)
		{
			return WrappedElement.FindElements(by);
		}

		public string GetProperty(string propertyName)
		{
			return WrappedElement.GetProperty(propertyName);
		}
		#endregion
	}
}
