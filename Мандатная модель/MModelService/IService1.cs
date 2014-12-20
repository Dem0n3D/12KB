using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MModelService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        void A_Button_Click(string Category, List<string> Magaz);
        [OperationContract]
        void B_Button_Click(string Category, List<string> Magaz);
        [OperationContract]
        void C_Button_Click(string Category, List<string> Magaz);
        [OperationContract]
        void D_Button_Click(string Category, List<string> Magaz);
        [OperationContract]
        void PasIsNotCor(string Category, List<string> Magaz);

        [OperationContract]
        void SaveMagazine(List<string> Magaz);

        [OperationContract]
        void FileRead(StreamReader fs,List<string> FileName);
        [OperationContract]
        void FileReadOpen(StreamReader fs, List<string> Magaz, string text, string filename);
    }
}
