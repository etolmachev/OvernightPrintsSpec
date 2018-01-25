using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
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
			{ "config", (length, key) =>  config(key)}
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
		private static string config(string key)
		{
			switch (key)
			{
				case "email":
					return Manager.Configuration.Email;

				case "password":
					return Manager.Configuration.Password;

				case "username":
					return Manager.Configuration.Username;

				default:
					throw new NotImplementedException();
			}
		}

		public static string Resolve(string input)
		{
			foreach (Match match in Regex.Matches(input, regexAll))
			{
				string resultFunction = MainMethodResolve(input);
				input = resultFunction;
			}

			return input;
		}

		private static string MainMethodResolve(string input)
		{
			string key = Regex.Match(input, regexLeft).ToString();
			string value = Regex.Match(input, regexRight).ToString();

			int length = 0;
			try
			{
				length = Int32.Parse(value);

			}
			catch (FormatException ex) { }

			string leftSide = input.Substring(0, input.IndexOf(key) - 2);

			string midSide = string.Empty;
			try
			{
				midSide = methods[key](length, value);

			}
			catch (KeyNotFoundException ex) { }

			string rightSide = input.Substring(input.IndexOf(value) + value.Length + 2);

			return leftSide + midSide + rightSide;
		}


		private static string dir = Directory.GetCurrentDirectory() + "\\ScreenShots";
		private static void CreateTempDirectory()
		{
			if (!System.IO.Directory.Exists(dir))
			{
				System.IO.Directory.CreateDirectory(dir);
			}
		}
		private static string CreateFileName()
		{
			StringBuilder fileNameBuilder = new StringBuilder();

			string fileName = TestContext.CurrentContext.Test.FullName;
			fileName = fileName.Remove(fileName.IndexOf("("));
			fileNameBuilder.Append(fileName).Append("_");
			fileNameBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
			fileNameBuilder.Append(".png");

			return dir + "\\" + fileNameBuilder.ToString();
		}

		public static void CaptureScreenShot()
		{
			Screenshot screenshot = ((ITakesScreenshot) Browser.Driver).GetScreenshot();
			CreateTempDirectory();
			string fileName = CreateFileName();
			screenshot.SaveAsFile(fileName);
		}
	}
}
