using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Shapes;

namespace Servis
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int Add(int a, int b);

        [OperationContract]
        int Mult(int a, int b);

        [OperationContract]
        int Sub(SubData data);

        [OperationContract]
        DivOutputMessage Div(DivInputMessage meassage);
    }
}
