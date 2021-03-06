﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pctesting.DBService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DBService.IDataService")]
    public interface IDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/saveFileDataToDB", ReplyAction="http://tempuri.org/IDataService/saveFileDataToDBResponse")]
        void saveFileDataToDB(string name, string path, int time, string type, int compID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/saveFileDataToDB", ReplyAction="http://tempuri.org/IDataService/saveFileDataToDBResponse")]
        System.Threading.Tasks.Task saveFileDataToDBAsync(string name, string path, int time, string type, int compID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/saveTrafficDataToDB", ReplyAction="http://tempuri.org/IDataService/saveTrafficDataToDBResponse")]
        void saveTrafficDataToDB(string URL, int time, int compID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/saveTrafficDataToDB", ReplyAction="http://tempuri.org/IDataService/saveTrafficDataToDBResponse")]
        System.Threading.Tasks.Task saveTrafficDataToDBAsync(string URL, int time, int compID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/login", ReplyAction="http://tempuri.org/IDataService/loginResponse")]
        string login(string name, string password, string compName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/login", ReplyAction="http://tempuri.org/IDataService/loginResponse")]
        System.Threading.Tasks.Task<string> loginAsync(string name, string password, string compName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceChannel : pctesting.DBService.IDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceClient : System.ServiceModel.ClientBase<pctesting.DBService.IDataService>, pctesting.DBService.IDataService {
        
        public DataServiceClient() {
        }
        
        public DataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void saveFileDataToDB(string name, string path, int time, string type, int compID, int userID) {
            base.Channel.saveFileDataToDB(name, path, time, type, compID, userID);
        }
        
        public System.Threading.Tasks.Task saveFileDataToDBAsync(string name, string path, int time, string type, int compID, int userID) {
            return base.Channel.saveFileDataToDBAsync(name, path, time, type, compID, userID);
        }
        
        public void saveTrafficDataToDB(string URL, int time, int compID, int userID) {
            base.Channel.saveTrafficDataToDB(URL, time, compID, userID);
        }
        
        public System.Threading.Tasks.Task saveTrafficDataToDBAsync(string URL, int time, int compID, int userID) {
            return base.Channel.saveTrafficDataToDBAsync(URL, time, compID, userID);
        }
        
        public string login(string name, string password, string compName) {
            return base.Channel.login(name, password, compName);
        }
        
        public System.Threading.Tasks.Task<string> loginAsync(string name, string password, string compName) {
            return base.Channel.loginAsync(name, password, compName);
        }
    }
}
