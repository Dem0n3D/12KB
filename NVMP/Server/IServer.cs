using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace Server {
  [ServiceContract]
  public interface IServer {
    [OperationContract]
    Int16 GetCard();
  }
}