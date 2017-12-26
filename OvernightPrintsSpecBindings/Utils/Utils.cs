using System;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Utils
{
	public class Utils
	{
		private static string vocabulary = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!$%^&?*-+={}";

		public static object ExecuteJavaScript(IWebDriver Driver,string javaScript, params object[] args)
		{
			var javaScriptExecutor = (IJavaScriptExecutor)Driver;

			return javaScriptExecutor.ExecuteScript(javaScript, args);
		}

		public static string ParseString(string input)
		{
			return input.Trim('"');
		}

		public static string Resolve(String email)
		{
			string result = String.Empty;
			string regex = "(?<={{)(.*?)(?=}})";
			string match = Regex.Match(email, regex).ToString();

			string key = match.Split("::".ToCharArray())[0];
			string value = match.Split("::".ToCharArray())[2];

			switch (key)
			{
				case "rnd":
					result = Rnd(email, value);
					break;
				case "context":
					result = Context(value);
					break;
			}
			return  result;
		}

		private static string Rnd(string email, string placeholder)
		{
			string result = String.Empty;
			string left = email.Substring(0, email.IndexOf("{{"));
			string right = email.Substring(email.IndexOf("}}") + 2);

			int n = 0;

			try
			{
				n = Int32.Parse(placeholder);
				for (int i = 0; i < n; i++)
				{
					int tempRandom = new Random().Next(0, vocabulary.Length - 1);
					Thread.Sleep(500);
					result += vocabulary[tempRandom];
				}
			}
			catch (FormatException e)
			{
				return String.Empty;
			}

			return left + result + right;
		}

		private static string Context(string key)
		{
			return ScenarioContext.Current.Get<string>(key);
		}
	}
}
