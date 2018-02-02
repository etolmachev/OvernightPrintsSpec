using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvernightPrintsSpecBindings.TestBase.MessageWorker
{
	class Result
	{
		public string Source { get; set; }
		public bool isError { get; set; }
		public string Output { get; set; }

		public Result(string source)
		{
			this.Source = source;
			this.isError = !source.Contains("OK");
			this.Output = CleanedOutput(source);
		}

		public string CleanedOutput(string source)
		{
			source = source.Replace("\0", "");

			if (source.Contains("SEARCH"))
			{
				source = source.Replace("* SEARCH", "");
				source = source.Replace(source.Substring(source.IndexOf("\r\n")), "");
				source = source.Trim();
				isError = (source == "") && (source.StartsWith("$ BAD"));
			}

			return source;
		}

	}
}
