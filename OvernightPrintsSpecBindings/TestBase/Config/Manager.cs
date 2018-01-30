using OvernightPrintsSpecBindings.TestBase.Config;

namespace OvernightPrintsSpecBindings.TestBase
{
	public static class Manager
	{
		public static Configuration Config
		{
			get;
			set;
		}

		public static void buildConfig()
		{
			XmlConfigReader configReader = new XmlConfigReader();
			Config = configReader.ReadConfig();
		}
	}
}
