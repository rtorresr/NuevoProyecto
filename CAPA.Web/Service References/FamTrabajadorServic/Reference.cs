﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAPA.Web.FamTrabajadorServic {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="_listarxfiltroFamiliaTrabajadorReq", Namespace="http://schemas.datacontract.org/2004/07/SEL_Entidades.RRHH_E.filtros")]
    [System.SerializableAttribute()]
    public partial class _listarxfiltroFamiliaTrabajadorReq : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombCompTrabField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nroDniTrabField;
        
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
        public string nombCompTrab {
            get {
                return this.nombCompTrabField;
            }
            set {
                if ((object.ReferenceEquals(this.nombCompTrabField, value) != true)) {
                    this.nombCompTrabField = value;
                    this.RaisePropertyChanged("nombCompTrab");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nroDniTrab {
            get {
                return this.nroDniTrabField;
            }
            set {
                if ((object.ReferenceEquals(this.nroDniTrabField, value) != true)) {
                    this.nroDniTrabField = value;
                    this.RaisePropertyChanged("nroDniTrab");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="_listarxfiltroFamiliaTrabajadorResp", Namespace="http://schemas.datacontract.org/2004/07/SEL_Entidades.RRHH_E.filtros")]
    [System.SerializableAttribute()]
    public partial class _listarxfiltroFamiliaTrabajadorResp : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<CAPA.Web.FamTrabajadorServic.FamTrabajador_E> lstFamTrabajador_EField;
        
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
        public System.Collections.Generic.List<CAPA.Web.FamTrabajadorServic.FamTrabajador_E> lstFamTrabajador_E {
            get {
                return this.lstFamTrabajador_EField;
            }
            set {
                if ((object.ReferenceEquals(this.lstFamTrabajador_EField, value) != true)) {
                    this.lstFamTrabajador_EField = value;
                    this.RaisePropertyChanged("lstFamTrabajador_E");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FamTrabajador_E", Namespace="http://schemas.datacontract.org/2004/07/SEL_Entidades.RRHH_E")]
    [System.SerializableAttribute()]
    public partial class FamTrabajador_E : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoPaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CelularField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorreoElectronicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoCivilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FechaNacimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fechaRegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdFamTrabajadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdSexoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTipoDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTipoLazoFamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTrabajadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioRegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NroDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UbigeoRefField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descSexoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string familiarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombTrabajadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombUsuarioModField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombUsuarioRegField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tipoDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tipoLazoFamField;
        
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
        public bool Activo {
            get {
                return this.ActivoField;
            }
            set {
                if ((this.ActivoField.Equals(value) != true)) {
                    this.ActivoField = value;
                    this.RaisePropertyChanged("Activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoMaterno {
            get {
                return this.ApellidoMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoMaternoField, value) != true)) {
                    this.ApellidoMaternoField = value;
                    this.RaisePropertyChanged("ApellidoMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoPaterno {
            get {
                return this.ApellidoPaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoPaternoField, value) != true)) {
                    this.ApellidoPaternoField = value;
                    this.RaisePropertyChanged("ApellidoPaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Celular {
            get {
                return this.CelularField;
            }
            set {
                if ((object.ReferenceEquals(this.CelularField, value) != true)) {
                    this.CelularField = value;
                    this.RaisePropertyChanged("Celular");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorreoElectronico {
            get {
                return this.CorreoElectronicoField;
            }
            set {
                if ((object.ReferenceEquals(this.CorreoElectronicoField, value) != true)) {
                    this.CorreoElectronicoField = value;
                    this.RaisePropertyChanged("CorreoElectronico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EstadoCivil {
            get {
                return this.EstadoCivilField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoCivilField, value) != true)) {
                    this.EstadoCivilField = value;
                    this.RaisePropertyChanged("EstadoCivil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FechaModificacion {
            get {
                return this.FechaModificacionField;
            }
            set {
                if ((object.ReferenceEquals(this.FechaModificacionField, value) != true)) {
                    this.FechaModificacionField = value;
                    this.RaisePropertyChanged("FechaModificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FechaNacimiento {
            get {
                return this.FechaNacimientoField;
            }
            set {
                if ((object.ReferenceEquals(this.FechaNacimientoField, value) != true)) {
                    this.FechaNacimientoField = value;
                    this.RaisePropertyChanged("FechaNacimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fechaRegistro {
            get {
                return this.fechaRegistroField;
            }
            set {
                if ((object.ReferenceEquals(this.fechaRegistroField, value) != true)) {
                    this.fechaRegistroField = value;
                    this.RaisePropertyChanged("Fecharegistró");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Foto {
            get {
                return this.FotoField;
            }
            set {
                if ((object.ReferenceEquals(this.FotoField, value) != true)) {
                    this.FotoField = value;
                    this.RaisePropertyChanged("Foto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdFamTrabajador {
            get {
                return this.IdFamTrabajadorField;
            }
            set {
                if ((this.IdFamTrabajadorField.Equals(value) != true)) {
                    this.IdFamTrabajadorField = value;
                    this.RaisePropertyChanged("IdFamTrabajador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdSexo {
            get {
                return this.IdSexoField;
            }
            set {
                if ((this.IdSexoField.Equals(value) != true)) {
                    this.IdSexoField = value;
                    this.RaisePropertyChanged("IdSexo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTipoDocumento {
            get {
                return this.IdTipoDocumentoField;
            }
            set {
                if ((this.IdTipoDocumentoField.Equals(value) != true)) {
                    this.IdTipoDocumentoField = value;
                    this.RaisePropertyChanged("IdTipoDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTipoLazoFam {
            get {
                return this.IdTipoLazoFamField;
            }
            set {
                if ((this.IdTipoLazoFamField.Equals(value) != true)) {
                    this.IdTipoLazoFamField = value;
                    this.RaisePropertyChanged("IdTipoLazoFam");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTrabajador {
            get {
                return this.IdTrabajadorField;
            }
            set {
                if ((this.IdTrabajadorField.Equals(value) != true)) {
                    this.IdTrabajadorField = value;
                    this.RaisePropertyChanged("IdTrabajador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuarioModificacion {
            get {
                return this.IdUsuarioModificacionField;
            }
            set {
                if ((this.IdUsuarioModificacionField.Equals(value) != true)) {
                    this.IdUsuarioModificacionField = value;
                    this.RaisePropertyChanged("IdUsuarioModificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuarioRegistro {
            get {
                return this.IdUsuarioRegistroField;
            }
            set {
                if ((this.IdUsuarioRegistroField.Equals(value) != true)) {
                    this.IdUsuarioRegistroField = value;
                    this.RaisePropertyChanged("IDUSUARIOregistró");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombres {
            get {
                return this.NombresField;
            }
            set {
                if ((object.ReferenceEquals(this.NombresField, value) != true)) {
                    this.NombresField = value;
                    this.RaisePropertyChanged("Nombres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NroDocumento {
            get {
                return this.NroDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.NroDocumentoField, value) != true)) {
                    this.NroDocumentoField = value;
                    this.RaisePropertyChanged("NroDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UbigeoRef {
            get {
                return this.UbigeoRefField;
            }
            set {
                if ((object.ReferenceEquals(this.UbigeoRefField, value) != true)) {
                    this.UbigeoRefField = value;
                    this.RaisePropertyChanged("UbigeoRef");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string descSexo {
            get {
                return this.descSexoField;
            }
            set {
                if ((object.ReferenceEquals(this.descSexoField, value) != true)) {
                    this.descSexoField = value;
                    this.RaisePropertyChanged("descSexo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string familiar {
            get {
                return this.familiarField;
            }
            set {
                if ((object.ReferenceEquals(this.familiarField, value) != true)) {
                    this.familiarField = value;
                    this.RaisePropertyChanged("familiar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombTrabajador {
            get {
                return this.nombTrabajadorField;
            }
            set {
                if ((object.ReferenceEquals(this.nombTrabajadorField, value) != true)) {
                    this.nombTrabajadorField = value;
                    this.RaisePropertyChanged("nombTrabajador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombUsuarioMod {
            get {
                return this.nombUsuarioModField;
            }
            set {
                if ((object.ReferenceEquals(this.nombUsuarioModField, value) != true)) {
                    this.nombUsuarioModField = value;
                    this.RaisePropertyChanged("nombUsuarioMod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombUsuarioReg {
            get {
                return this.nombUsuarioRegField;
            }
            set {
                if ((object.ReferenceEquals(this.nombUsuarioRegField, value) != true)) {
                    this.nombUsuarioRegField = value;
                    this.RaisePropertyChanged("nombUsuarioReg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipoDocumento {
            get {
                return this.tipoDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.tipoDocumentoField, value) != true)) {
                    this.tipoDocumentoField = value;
                    this.RaisePropertyChanged("tipoDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipoLazoFam {
            get {
                return this.tipoLazoFamField;
            }
            set {
                if ((object.ReferenceEquals(this.tipoLazoFamField, value) != true)) {
                    this.tipoLazoFamField = value;
                    this.RaisePropertyChanged("tipoLazoFam");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="_buscarFamilaTrabxIDReq", Namespace="http://schemas.datacontract.org/2004/07/SEL_Entidades.RRHH_E.filtros")]
    [System.SerializableAttribute()]
    public partial class _buscarFamilaTrabxIDReq : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
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
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="_buscarFamilaTrabxIDResp", Namespace="http://schemas.datacontract.org/2004/07/SEL_Entidades.RRHH_E.filtros")]
    [System.SerializableAttribute()]
    public partial class _buscarFamilaTrabxIDResp : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CAPA.Web.FamTrabajadorServic.FamTrabajador_E famTrabajador_EField;
        
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
        public CAPA.Web.FamTrabajadorServic.FamTrabajador_E famTrabajador_E {
            get {
                return this.famTrabajador_EField;
            }
            set {
                if ((object.ReferenceEquals(this.famTrabajador_EField, value) != true)) {
                    this.famTrabajador_EField = value;
                    this.RaisePropertyChanged("famTrabajador_E");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FamTrabajadorServic.IFamTrabajadorServ")]
    public interface IFamTrabajadorServ {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFamTrabajadorServ/listarxfiltro", ReplyAction="http://tempuri.org/IFamTrabajadorServ/listarxfiltroResponse")]
        CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorResp listarxfiltro(CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorReq objRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFamTrabajadorServ/listarxfiltro", ReplyAction="http://tempuri.org/IFamTrabajadorServ/listarxfiltroResponse")]
        System.Threading.Tasks.Task<CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorResp> listarxfiltroAsync(CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorReq objRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFamTrabajadorServ/buscarFamiliar", ReplyAction="http://tempuri.org/IFamTrabajadorServ/buscarFamiliarResponse")]
        CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDResp buscarFamiliar(CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDReq objRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFamTrabajadorServ/buscarFamiliar", ReplyAction="http://tempuri.org/IFamTrabajadorServ/buscarFamiliarResponse")]
        System.Threading.Tasks.Task<CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDResp> buscarFamiliarAsync(CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDReq objRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFamTrabajadorServChannel : CAPA.Web.FamTrabajadorServic.IFamTrabajadorServ, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FamTrabajadorServClient : System.ServiceModel.ClientBase<CAPA.Web.FamTrabajadorServic.IFamTrabajadorServ>, CAPA.Web.FamTrabajadorServic.IFamTrabajadorServ {
        
        public FamTrabajadorServClient() {
        }
        
        public FamTrabajadorServClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FamTrabajadorServClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FamTrabajadorServClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FamTrabajadorServClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorResp listarxfiltro(CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorReq objRequest) {
            return base.Channel.listarxfiltro(objRequest);
        }
        
        public System.Threading.Tasks.Task<CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorResp> listarxfiltroAsync(CAPA.Web.FamTrabajadorServic._listarxfiltroFamiliaTrabajadorReq objRequest) {
            return base.Channel.listarxfiltroAsync(objRequest);
        }
        
        public CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDResp buscarFamiliar(CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDReq objRequest) {
            return base.Channel.buscarFamiliar(objRequest);
        }
        
        public System.Threading.Tasks.Task<CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDResp> buscarFamiliarAsync(CAPA.Web.FamTrabajadorServic._buscarFamilaTrabxIDReq objRequest) {
            return base.Channel.buscarFamiliarAsync(objRequest);
        }
    }
}
