using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace NewApp
{
	class Program
	{
		public static void Main (string[] args)
		{
			var port = "8085";
			var config = new HttpSelfHostConfiguration($"http://localhost:{port}");
			config.MapHttpAttributeRoutes();

			using (HttpSelfHostServer server = new HttpSelfHostServer(config))
			{
				server.OpenAsync().Wait();
				Console.WriteLine($"Started host server in {port}.");
				while (true) {
					Thread.Sleep(1000);
				}
			}
		}
	}
}
