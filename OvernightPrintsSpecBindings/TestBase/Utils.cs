﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.TestBase
{
	public static class Utils
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

		private static string vocabulary = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!$%^&?*-+={}";

		private static string regexAll = "(?={{)(.*?)(?<=}})";
		private static string regexLeft = "(?<={{)(.*?)(?=::)";
		private static string regexRight = "(?<=::)(.*?)(?=}})";

		private static Dictionary<string, Func<int, string, string>> methods = new Dictionary<string, Func<int, string, string>>()
		{
			{ "rnd", (length, key) => rnd(length) },
			{ "context", (length, key) => context(key) },
		};

		private static string context(string key)
		{
			return ScenarioContext.Current.Get<string>(key);
		}
		private static string rnd(int length)
		{
			string result = String.Empty;

			for (int i = 0; i < length; i++)
			{
				int tempRandom = new Random().Next(0, vocabulary.Length - 1);
				Thread.Sleep(500);
				result += vocabulary[tempRandom];
			}
			return result;
		}

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
			string value = Regex.Match(email, regexRight).ToString();

			int length = 0;
			try
			{
				length = Int32.Parse(value);

			}
			catch (FormatException ex) { }

			string leftSide = email.Substring(0, email.IndexOf(key) - 2);

			string midSide = string.Empty;
			try
			{
				midSide = methods[key](length, value);

			}
			catch (KeyNotFoundException ex) { }

			string rightSide = email.Substring(email.IndexOf(value) + value.Length + 2);

			return leftSide + midSide + rightSide;
		}
	}
}
