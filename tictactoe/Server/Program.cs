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
        public static int[] Flags;
        private static int _ids;
        private static int _curid;
        private static int _last_i;

        public static int GetId()
        {
            if (_ids == 2)
            {
                return -1;
            }
            _ids++;
            return _ids - 1;
        }

        public static bool CanClick(int id)
        {
            return _curid == id;
        }

        public static int TryClick(int i, int id)
        {
            //Console.WriteLine(i + " " + id);
            if (_curid == id)
            {
                _last_i = i;
                Flags[i] = _curid;
                _curid = (_curid+1) % 2;
            }
            return Flags[i];
        }

        public static int GetLastClick()
        {
            return _last_i;
        }

        static void Main(string[] args)
        {
            _curid = 0;
            Flags = new int[9];
            _ids = 0;
            _last_i = -1;
            ServiceHost host = new ServiceHost(typeof(Service1));
            host.Open();
            Console.ReadKey(false);
            host.Close();
        }
    }
}
