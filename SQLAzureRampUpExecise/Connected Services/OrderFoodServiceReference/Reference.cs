﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLAzureRampUpExecise.OrderFoodServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderFoodServiceReference.IOrderFoodServiceApi")]
    public interface IOrderFoodServiceApi {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderFoodServiceApi/Order", ReplyAction="http://tempuri.org/IOrderFoodServiceApi/OrderResponse")]
        int Order(string userName, string companyName, string restaurantName, string description, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderFoodServiceApi/Order", ReplyAction="http://tempuri.org/IOrderFoodServiceApi/OrderResponse")]
        System.Threading.Tasks.Task<int> OrderAsync(string userName, string companyName, string restaurantName, string description, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderFoodServiceApi/GetOrdersByCompanyAndDay", ReplyAction="http://tempuri.org/IOrderFoodServiceApi/GetOrdersByCompanyAndDayResponse")]
        string[] GetOrdersByCompanyAndDay(string companyName, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderFoodServiceApi/GetOrdersByCompanyAndDay", ReplyAction="http://tempuri.org/IOrderFoodServiceApi/GetOrdersByCompanyAndDayResponse")]
        System.Threading.Tasks.Task<string[]> GetOrdersByCompanyAndDayAsync(string companyName, System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderFoodServiceApiChannel : SQLAzureRampUpExecise.OrderFoodServiceReference.IOrderFoodServiceApi, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderFoodServiceApiClient : System.ServiceModel.ClientBase<SQLAzureRampUpExecise.OrderFoodServiceReference.IOrderFoodServiceApi>, SQLAzureRampUpExecise.OrderFoodServiceReference.IOrderFoodServiceApi {
        
        public OrderFoodServiceApiClient() {
        }
        
        public OrderFoodServiceApiClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderFoodServiceApiClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderFoodServiceApiClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderFoodServiceApiClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Order(string userName, string companyName, string restaurantName, string description, System.DateTime date) {
            return base.Channel.Order(userName, companyName, restaurantName, description, date);
        }
        
        public System.Threading.Tasks.Task<int> OrderAsync(string userName, string companyName, string restaurantName, string description, System.DateTime date) {
            return base.Channel.OrderAsync(userName, companyName, restaurantName, description, date);
        }
        
        public string[] GetOrdersByCompanyAndDay(string companyName, System.DateTime date) {
            return base.Channel.GetOrdersByCompanyAndDay(companyName, date);
        }
        
        public System.Threading.Tasks.Task<string[]> GetOrdersByCompanyAndDayAsync(string companyName, System.DateTime date) {
            return base.Channel.GetOrdersByCompanyAndDayAsync(companyName, date);
        }
    }
}