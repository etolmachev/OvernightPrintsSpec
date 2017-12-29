using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OvernightPrintsSpecBindings.TestBase
{
	public static class Browser
	{
		public static bool IsInitialized = false;
		public static IWebDriver Driver;

		public static bool isInitialized()
		{
			return IsInitialized;
		}

		public static void BuildBrowser()
		{
			Driver = new ChromeDriver();
			Driver.Manage().Window.Maximize();
			IsInitialized = true;
		}

		public static void Quit()
		{
			IsInitialized = false;
			Driver.Quit();
		}

		public static void WaitReadyState(int timeout = 50)
		{
			int t = timeout;
			while (!IsReadyState() || t == 0)
			{
				t--;
				Thread.Sleep(TimeSpan.FromSeconds(1));
			}
			Assert.AreNotEqual(0, t, "Browser is not ready after {0} seconds", timeout);
		}

		public static bool IsReadyState()
		{
			try
			{
				return (bool)Utils.Utils.ExecuteJavaScript(Driver,"return document.readyState == 'complete'");
			}
			catch (InvalidOperationException)
			{
				return false;
			}
		}
	}
}