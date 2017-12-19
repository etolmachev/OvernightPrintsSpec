using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.Utils
{
	class Utils
	{
		public static object ExecuteJavaScript(IWebDriver Driver,string javaScript, params object[] args)
		{
			var javaScriptExecutor = (IJavaScriptExecutor)Driver;

			return javaScriptExecutor.ExecuteScript(javaScript, args);
		}
	}
}
