﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tictactoe.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Connect", ReplyAction="http://tempuri.org/IService1/ConnectResponse")]
        int Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Connect", ReplyAction="http://tempuri.org/IService1/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLastClick", ReplyAction="http://tempuri.org/IService1/GetLastClickResponse")]
        int GetLastClick();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLastClick", ReplyAction="http://tempuri.org/IService1/GetLastClickResponse")]
        System.Threading.Tasks.Task<int> GetLastClickAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CanClick", ReplyAction="http://tempuri.org/IService1/CanClickResponse")]
        bool CanClick(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CanClick", ReplyAction="http://tempuri.org/IService1/CanClickResponse")]
        System.Threading.Tasks.Task<bool> CanClickAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TryClick", ReplyAction="http://tempuri.org/IService1/TryClickResponse")]
        int TryClick(int i, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TryClick", ReplyAction="http://tempuri.org/IService1/TryClickResponse")]
        System.Threading.Tasks.Task<int> TryClickAsync(int i, int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : tictactoe.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<tictactoe.ServiceReference1.IService1>, tictactoe.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Connect() {
            return base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public int GetLastClick() {
            return base.Channel.GetLastClick();
        }
        
        public System.Threading.Tasks.Task<int> GetLastClickAsync() {
            return base.Channel.GetLastClickAsync();
        }
        
        public bool CanClick(int id) {
            return base.Channel.CanClick(id);
        }
        
        public System.Threading.Tasks.Task<bool> CanClickAsync(int id) {
            return base.Channel.CanClickAsync(id);
        }
        
        public int TryClick(int i, int id) {
            return base.Channel.TryClick(i, id);
        }
        
        public System.Threading.Tasks.Task<int> TryClickAsync(int i, int id) {
            return base.Channel.TryClickAsync(i, id);
        }
    }
}
