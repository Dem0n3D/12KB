using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Security.Principal;
using WcfChat;
using System.Windows.Forms;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program temp = new Program();

            if (temp.IsCurrentlyRunningAsAdmin())
                temp.RunServer();
            else
                MessageBox.Show("Did you run it as administrator?", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RunServer()
        {
            using (ServiceHost host = new ServiceHost(typeof(ChatService)))
            {
                host.Open();
                Console.WriteLine("Server started");
                Console.WriteLine("\n");

                Console.ReadLine();
                host.Close();
            }
        }
        private bool IsCurrentlyRunningAsAdmin()
        {
            bool isAdmin = false;
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            if (currentIdentity != null)
            {
                WindowsPrincipal pricipal = new WindowsPrincipal(currentIdentity);
                isAdmin = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
                pricipal = null;
            }
            return isAdmin;
        }
    }
}
