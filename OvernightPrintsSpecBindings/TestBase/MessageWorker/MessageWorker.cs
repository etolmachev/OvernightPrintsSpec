using System.Text.RegularExpressions;

namespace OvernightPrintsSpecBindings.TestBase.MessageWorker
{
	public class MessageWrapper
	{

		private readonly string headerRegEx = "(?<=Subject: )(.*?)(?=\r\n)";
		private readonly string linkRegEx = "(?<=<a href=3D\">)(.*?)(?=\")";

		public string Header { get; set; }
		public string Text { get; set; }

		public MessageWrapper(string header, string text)
		{
			this.Header = GetHeader(header);
			this.Text = GetText(text);
		}

		private string GetHeader(string header)
		{
			Regex regex = new Regex(headerRegEx);
			Match match = regex.Match(header);

			return (match.Success) ? match.Value : header;
		}
		private string GetText(string text)
		{

			int startIndex = text.IndexOf("<");
			int endIndex = text.LastIndexOf(">");

			if (startIndex < 0 || endIndex < 0)
			{
				return text;
			}

			text = text.Substring(startIndex, endIndex - startIndex + 1);

			return text;
		}
	}
}
