using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace OvernightPrintsSpecBindings.TestBase.MessageWorker
{
	class Client
	{
		private TcpClient client;
		private SslStream ssl;

		private readonly string protocol = "imap.gmail.com";
		private readonly int port = 993;

		public Client()
		{
			client = new TcpClient(protocol, port);
			ssl = new SslStream(client.GetStream());
			ssl.AuthenticateAsClient(protocol);

			ExecuteQuery();
		}

		public Result ExecuteQuery(string command = "")
		{
			StringBuilder builderResponse = new StringBuilder();

			if (command != "")
			{
				if (client.Connected)
				{
					byte[] query = Encoding.UTF8.GetBytes(command);
					ssl.Write(query, 0, query.Length);
				}
			}

			ssl.Flush();


			int size = 1024;

			if (command.Contains("FETCH"))
			{
				do
				{
					builderResponse.Append(ReadBytes(size));
					Console.WriteLine(builderResponse.ToString());

				} while (
					!builderResponse.ToString().Contains("Success")
					&&
					!builderResponse.ToString().Contains("Failure")
					&&
					!builderResponse.ToString().StartsWith("$ BAD")
				);

			}
			else
			{
				builderResponse.Append(ReadBytes(size));
				Console.WriteLine(builderResponse.ToString());
			}


			return new Result(builderResponse.ToString());

		}

		private string ReadBytes(int size)
		{
			byte[] buffer = new byte[size];
			ssl.Read(buffer, 0, size);
			return Encoding.UTF8.GetString(buffer);
		}

		public void Disconnect()
		{
			try
			{
				ssl.Close();
				ssl.Dispose();

				client.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				if (ssl != null)
				{
					ssl.Close();
					ssl.Dispose();
				}

				if (client != null)
				{
					client.Close();
				}
			}
		}
	}
}
