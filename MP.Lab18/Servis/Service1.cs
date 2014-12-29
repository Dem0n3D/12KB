using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Servis
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public void DoWork()
        {
        }

        private string name, mainDir = @"C:\";
        private int lvlOfSec;
        List<string> paths = new List<string>();
        private SortedDictionary<string, int> levels = new SortedDictionary<string, int>();

        public bool stProg(string log, string pass, out int sec)
        {
            SortedDictionary<string, string> logins = new SortedDictionary<string, string>();
            SortedDictionary<string, int> secur = new SortedDictionary<string, int>();

            using (StreamReader sr = new StreamReader("logins.txt"))
            {
                string tmp = sr.ReadLine();
                while (tmp != null)
                {
                    string[] a = tmp.Split(new char[] {' '});
                    logins[a[0]] = a[1];
                    secur[a[0]] = int.Parse(a[2]);
                    tmp = sr.ReadLine();
                }
                sec = 0;
            }

            if (logins.ContainsKey(log) == false || logins[log] != pass)
            {
                return false;
                
            }
            else
            {
                sec = secur[log];
                return true;
            }
        }

        public void begWork()
        {
            using (StreamReader srlvl = new StreamReader("temp.txt", Encoding.UTF8))
            {
                string tmp = srlvl.ReadLine();
                while (tmp != null)
                {
                    levels[tmp.Substring(0, tmp.Count() - 2)] = int.Parse(tmp.Last().ToString());
                    tmp = srlvl.ReadLine();
                }

                paths.Add(mainDir);
            }

        }

        public List<string> getFilesAndDir(string path)
        {
            List<string> re = new List<string>();
            DirectoryInfo[] di = new DirectoryInfo(path).GetDirectories();
            FileInfo[] fi = new DirectoryInfo(path).GetFiles();
            foreach (var info in di)
            {
                re.Add(info.ToString());
            }
            foreach (var info in fi)
            {
                re.Add(info.ToString());
            }

           return re;
        }
    }
}
