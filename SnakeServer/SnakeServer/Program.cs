using System;
using System.ServiceModel;

namespace SnakeServer {
	internal class Program {
		private static void Main() {
			ServiceHost serviceHost = new ServiceHost(typeof(SnakeServer));
			//serviceHost.AddServiceEndpoint(typeof(ISnakeServer), new NetTcpBinding(), "net.tcp://localhast:8875/");
			serviceHost.Open();
			Console.ReadKey();
			serviceHost.Close();
		}
	}
}