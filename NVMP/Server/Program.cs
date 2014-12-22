using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
  class Program
  {
    static void Main(string[] args)
    {
      ServiceHost serviceHost = new ServiceHost(typeof(Server));
      serviceHost.Open();
      Console.WriteLine("Service is running...");
      Console.ReadKey();
      serviceHost.Close();
    }
  }
}
