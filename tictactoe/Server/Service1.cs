using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public int Connect()
        {
            //_id = Program.GetId();
            return Program.GetId();
        }

        public int GetLastClick()
        {
            return Program.GetLastClick();
        }

        public bool CanClick(int id)
        {
            return Program.CanClick(id);
        }

        public int TryClick(int i, int id)
        {
            return Program.TryClick(i, id);
        }
    }
}
