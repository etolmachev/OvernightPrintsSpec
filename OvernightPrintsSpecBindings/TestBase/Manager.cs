using System;
using System.IO;
using System.Xml.Serialization;

namespace OvernightPrintsSpecBindings.TestBase
{
	public static class Manager
	{
		public static Config Configuration
		{
			get;
			set;
		}

		public static void buildConfig()
		{

			string path = "C:\\Users\\dalekseev\\Config.xml";

			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				StreamReader streamReader = new StreamReader(path);
				Configuration = (Config)serializer.Deserialize(streamReader);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}

	}
}
