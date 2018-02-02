using System;
using System.Text.RegularExpressions;

namespace OvernightPrintsSpecBindings.TestBase.MessageWorker
{
	public class MessageWorker
	{
		private Client _client;

		private readonly string email = Manager.Configuration.Email;//"testda097@gmail.com";
		private readonly string pass = Manager.Configuration.Password;//"4sep98MPcalifUSA";
		private readonly string from = "service@overnightprints.com";
		private readonly string subject = "Reset password";

		public MessageWorker()
		{
			this._client = new Client();
		}

		public MessageWrapper[] GetMessages()
		{

			string[] queries = new string[]
			{
				"$ LOGIN {0} {1}  \r\n",
				"$ SELECT INBOX\r\n",
				"$ SEARCH UNSEEN FROM '{0}'\r\n",
				"$ FETCH {0} body[header]\r\n",
				"$ FETCH {0} body[text]\r\n"
			};

			Result login = _client.ExecuteQuery(string.Format(queries[0], email, pass));
			if (login.isError)
			{
				throw new Exception("Failure login attempt");
			}

			_client.ExecuteQuery(queries[1]);

			Result search = _client.ExecuteQuery(string.Format(queries[2], from, subject));
			string[] uids = new string[0];
			if (!search.isError)
			{
				uids = search.Output.Split(' ');
			}

			MessageWrapper[] messages = new MessageWrapper[uids.Length];

			for (int i = 0; i < uids.Length; i++)
			{
				Result header = _client.ExecuteQuery(string.Format(queries[3], uids[i]));
				Result text = _client.ExecuteQuery(string.Format(queries[4], uids[i]));


				messages[i] = new MessageWrapper(header.Output, text.Output);
			}

			return messages;
		}

		public string GetResetPasswordLink()
		{
			MessageWrapper[] messages = GetMessages();
			string result = "";
			foreach (var t in messages)
			{
				result = SortLinks(t.Text);
			}

			return result;
		}

		private readonly string linkRegEx = "(?=<a)(.*?)(?=\">)";

		private string SortLinks(string text)
		{
			string result = "";
			text = text.Replace("\r\n", "");

			foreach (Match match in Regex.Matches(text, linkRegEx))
			{
				string value = match.Value;
				if (value.Contains("contact"))
				{
					continue;
				}
				else
				{
					result = value;
					result = result.Replace("=", "");
					result = result.Substring(result.IndexOf("\"") + 1);
				}
			}

			return result;
		}
	}
}
