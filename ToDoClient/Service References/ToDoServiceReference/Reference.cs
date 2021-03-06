﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoClient.ToDoServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ToDoMessage", Namespace="http://schemas.datacontract.org/2004/07/WcfToDoService")]
    [System.SerializableAttribute()]
    public partial class ToDoMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsCompletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ToDoIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsCompleted {
            get {
                return this.IsCompletedField;
            }
            set {
                if ((this.IsCompletedField.Equals(value) != true)) {
                    this.IsCompletedField = value;
                    this.RaisePropertyChanged("IsCompleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToDoId {
            get {
                return this.ToDoIdField;
            }
            set {
                if ((this.ToDoIdField.Equals(value) != true)) {
                    this.ToDoIdField = value;
                    this.RaisePropertyChanged("ToDoId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ToDoServiceReference.IWcfProxyService")]
    public interface IWcfProxyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/GetOrCreateUser", ReplyAction="http://tempuri.org/IWcfProxyService/GetOrCreateUserResponse")]
        int GetOrCreateUser(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/GetOrCreateUser", ReplyAction="http://tempuri.org/IWcfProxyService/GetOrCreateUserResponse")]
        System.Threading.Tasks.Task<int> GetOrCreateUserAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/InitTodos", ReplyAction="http://tempuri.org/IWcfProxyService/InitTodosResponse")]
        System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage> InitTodos(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/InitTodos", ReplyAction="http://tempuri.org/IWcfProxyService/InitTodosResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage>> InitTodosAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/GetTodos", ReplyAction="http://tempuri.org/IWcfProxyService/GetTodosResponse")]
        System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage> GetTodos(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/GetTodos", ReplyAction="http://tempuri.org/IWcfProxyService/GetTodosResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage>> GetTodosAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/CreateTodo", ReplyAction="http://tempuri.org/IWcfProxyService/CreateTodoResponse")]
        void CreateTodo(ToDoClient.ToDoServiceReference.ToDoMessage todo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/CreateTodo", ReplyAction="http://tempuri.org/IWcfProxyService/CreateTodoResponse")]
        System.Threading.Tasks.Task CreateTodoAsync(ToDoClient.ToDoServiceReference.ToDoMessage todo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/UpdateTodo", ReplyAction="http://tempuri.org/IWcfProxyService/UpdateTodoResponse")]
        void UpdateTodo(ToDoClient.ToDoServiceReference.ToDoMessage todo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/UpdateTodo", ReplyAction="http://tempuri.org/IWcfProxyService/UpdateTodoResponse")]
        System.Threading.Tasks.Task UpdateTodoAsync(ToDoClient.ToDoServiceReference.ToDoMessage todo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/DeleteTodo", ReplyAction="http://tempuri.org/IWcfProxyService/DeleteTodoResponse")]
        void DeleteTodo(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfProxyService/DeleteTodo", ReplyAction="http://tempuri.org/IWcfProxyService/DeleteTodoResponse")]
        System.Threading.Tasks.Task DeleteTodoAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfProxyServiceChannel : ToDoClient.ToDoServiceReference.IWcfProxyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfProxyServiceClient : System.ServiceModel.ClientBase<ToDoClient.ToDoServiceReference.IWcfProxyService>, ToDoClient.ToDoServiceReference.IWcfProxyService {
        
        public WcfProxyServiceClient() {
        }
        
        public WcfProxyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfProxyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfProxyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfProxyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetOrCreateUser(string id) {
            return base.Channel.GetOrCreateUser(id);
        }
        
        public System.Threading.Tasks.Task<int> GetOrCreateUserAsync(string id) {
            return base.Channel.GetOrCreateUserAsync(id);
        }
        
        public System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage> InitTodos(int userId) {
            return base.Channel.InitTodos(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage>> InitTodosAsync(int userId) {
            return base.Channel.InitTodosAsync(userId);
        }
        
        public System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage> GetTodos(int userId) {
            return base.Channel.GetTodos(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ToDoClient.ToDoServiceReference.ToDoMessage>> GetTodosAsync(int userId) {
            return base.Channel.GetTodosAsync(userId);
        }
        
        public void CreateTodo(ToDoClient.ToDoServiceReference.ToDoMessage todo) {
            base.Channel.CreateTodo(todo);
        }
        
        public System.Threading.Tasks.Task CreateTodoAsync(ToDoClient.ToDoServiceReference.ToDoMessage todo) {
            return base.Channel.CreateTodoAsync(todo);
        }
        
        public void UpdateTodo(ToDoClient.ToDoServiceReference.ToDoMessage todo) {
            base.Channel.UpdateTodo(todo);
        }
        
        public System.Threading.Tasks.Task UpdateTodoAsync(ToDoClient.ToDoServiceReference.ToDoMessage todo) {
            return base.Channel.UpdateTodoAsync(todo);
        }
        
        public void DeleteTodo(int id) {
            base.Channel.DeleteTodo(id);
        }
        
        public System.Threading.Tasks.Task DeleteTodoAsync(int id) {
            return base.Channel.DeleteTodoAsync(id);
        }
    }
}
