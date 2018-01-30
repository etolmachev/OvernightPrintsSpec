using System.Collections.Generic;

namespace OvernightPrintsSpecBindings.TestBase.Config
{
	public class Configuration
	{
		private Dictionary<string,string> parameters = new Dictionary<string, string>();

		public string GetParameter(string key)
		{
			return parameters[key];
		}

		public void AddParameter(string key, string value)
		{
			parameters.Add(key,value);
		}

	}
}
