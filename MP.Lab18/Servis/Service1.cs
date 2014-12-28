using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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

        public bool stProg(string log, string pass, out int sec)
        {
            SortedDictionary<string, string> logins = new SortedDictionary<string, string>();
            SortedDictionary<string, int> secur = new SortedDictionary<string, int>();

            StreamReader sr = new StreamReader("logins.txt");
            string tmp = sr.ReadLine();
            while (tmp != null)
            {
                string[] a = tmp.Split(new char[] { ' ' });
                logins[a[0]] = a[1];
                secur[a[0]] = int.Parse(a[2]);
                tmp = sr.ReadLine();
            }
            sr.Close();
            sec = 0;

            if (logins.ContainsKey(log) == false || logins[log] != pass)
            {
                //MessageBox.Show("Вы ввели неправильный логин или пароль", "Ошибка", MessageBoxButton.OK);
                return false;
                
            }
            else
            {
                //MessageBox.Show(String.Format("{0}, добро пожаловать!", log), "Вход в систему", MessageBoxButton.OK);
                //var temp = new secWindow(log, secur[log]);
                //temp.Show();
                //this.Close();
                sec = secur[log];
                return false;
            }
        }
    }
}
