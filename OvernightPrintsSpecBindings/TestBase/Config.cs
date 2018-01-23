using System;
using System.Xml.Serialization;

namespace OvernightPrintsSpecBindings.TestBase
{
	[XmlRoot("Config")]
	[Serializable]
	public class Config
	{
		[XmlElement("email")]
		public string Email
		{
			get;
			set;
		}

		[XmlElement("password")]
		public string Password
		{
			get;
			set;
		}

		[XmlElement("username")]
		public string Username
		{
			get;
			set;
		}
	}
}
