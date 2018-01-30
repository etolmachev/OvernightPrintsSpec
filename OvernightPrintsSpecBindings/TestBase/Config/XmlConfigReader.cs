using System;
using System.Xml;

namespace OvernightPrintsSpecBindings.TestBase.Config
{
	class XmlConfigReader
	{
		private readonly string path = "C:\\Users\\dalekseev\\Config.xml";
		private Configuration configuration;

		public Configuration ReadConfig()
		{
			configuration = new Configuration();

			XmlDocument document = new XmlDocument();
			document.Load(path);

			XmlNode root = document.DocumentElement;
			if (root.HasChildNodes)
			{
				foreach (XmlNode parents in root.ChildNodes)
				{
					XmlNode first = parents.FirstChild;

					if (first.NodeType == XmlNodeType.Text)
					{
						configuration.AddParameter(parents.Name, first.Value);
					}
					else
					{
						if (parents.HasChildNodes)
						{
							foreach (XmlNode child in parents.ChildNodes)
							{
								DescentByNesting(child);
							}
						}
					}
				}
			}

			return configuration;
		}

		private void DescentByNesting(XmlNode node)
		{
			string[] pair = new string[0];

			if (node.HasChildNodes)
			{
				pair = new string[2];
				int i = 0;

				foreach (XmlNode parents in node.ChildNodes)
				{
					XmlNode first = parents.FirstChild;
					if (first.NodeType == XmlNodeType.Text)
					{
						pair[i] = first.Value;
					}
					else
					{
						throw new Exception("This degree of nesting is not supported");
					}

					i++;
				}
			}

			if (pair.Length != 2)
			{
				throw new Exception("Invalid count parameters");
			}
			configuration.AddParameter(pair[0], pair[1]);
		}
	}
}
