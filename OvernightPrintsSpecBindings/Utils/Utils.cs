using System;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Utils
{
	public static class Utils
	{
		//private static string vocabulary = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!$%^&?*-+={}";

		public static object ExecuteJavaScript(IWebDriver Driver,string javaScript, params object[] args)
		{
			var javaScriptExecutor = (IJavaScriptExecutor)Driver;

			return javaScriptExecutor.ExecuteScript(javaScript, args);
		}

		public static string ParseString(string input)
		{
			return input.Trim('"');
		}

		private static string vocabulary = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!$%^&?*-+={}";

		private static string regexAll = "(?={{)(.*?)(?<=}})";
		private static string regexLeft = "(?<={{)(.*?)(?=::)";
		private static string regexRight = "(?<=::)(.*?)(?=}})";

		private delegate string Function(string email);

		private static Function[] functions = { new Function(rnd), new Function(context)};

		public static string Resolve(string email)
		{
			foreach (Match match in Regex.Matches(email, regexAll))
			{
				string resultFunction = MainMethodResolve(email);
				email = resultFunction;
			}

			return email;
		}

		private static string MainMethodResolve(string email)
		{
			string key = Regex.Match(email, regexLeft).ToString();
			string result = String.Empty;

			foreach (Function func in functions)
			{
				string methodName = func.Method.Name;
				if (methodName.Equals(key))
				{
					result = func(email);
					break;
				}
			}

			return result;
		}

		private static string rnd(string placeholder)
		{
			string result = String.Empty;
			string value = Regex.Match(placeholder, regexRight).ToString();
			string temp = Regex.Match(placeholder, regexAll).ToString();
			try
			{
				int n = Int32.Parse(value);
				for (int i = 0; i < n; i++)
				{
					int tempRandom = new Random().Next(0, vocabulary.Length - 1);
					Thread.Sleep(500);
					result += vocabulary[tempRandom];
				}
			}
			catch (FormatException e)
			{ }

			string leftSide = placeholder.Substring(0, placeholder.IndexOf(temp));
			string rightSide = placeholder.Substring(placeholder.IndexOf(temp) + temp.Length);

			return leftSide + result + rightSide;
		}

		private static string context(string placeholder)
		{
			string key = Regex.Match(placeholder, regexRight).ToString();
			return ScenarioContext.Current.Get<string>(key);
		}
	}
}
