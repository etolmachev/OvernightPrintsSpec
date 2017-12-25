using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.Utils
{
	public class Utils
	{
		public static object ExecuteJavaScript(IWebDriver Driver,string javaScript, params object[] args)
		{
			var javaScriptExecutor = (IJavaScriptExecutor)Driver;

			return javaScriptExecutor.ExecuteScript(javaScript, args);
		}

		public static string ParseString(string input)
		{
			return input.Trim('"');
		}
	}
}
