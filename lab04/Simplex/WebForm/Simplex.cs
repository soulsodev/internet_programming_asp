﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=4.8.3928.0.
// 
namespace Simplex {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Web.Services.WebServiceAttribute(Namespace="http://TVI/")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SimplexSoap", Namespace="http://TVI/")]
    public partial class Simplex : System.Web.Services.WebService {
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://TVI/Add", RequestNamespace="http://TVI/", ResponseNamespace="http://TVI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Add(int x, int y)
        {
            return x + y;
        }
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://TVI/Concat", RequestNamespace="http://TVI/", ResponseNamespace="http://TVI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Concat(string s, double d)
        {
            return String.Concat(s, d);
        }
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://TVI/Sum", RequestNamespace="http://TVI/", ResponseNamespace="http://TVI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public A Sum(A a1, A a2)
        {
            return new A () {
                s = String.Concat(a1.s + a2.s),
                k = a1.k + a2.k,
                f = a1.f + a2.f };
        }
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://TVI/Adds", RequestNamespace="http://TVI/", ResponseNamespace="http://TVI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://TVI/")]
    public partial class A {
        
        private string sField;
        
        private int kField;
        
        private float fField;
        
        /// <remarks/>
        public string s {
            get {
                return this.sField;
            }
            set {
                this.sField = value;
            }
        }
        
        /// <remarks/>
        public int k {
            get {
                return this.kField;
            }
            set {
                this.kField = value;
            }
        }
        
        /// <remarks/>
        public float f {
            get {
                return this.fField;
            }
            set {
                this.fField = value;
            }
        }
    }
}