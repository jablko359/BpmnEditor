namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    public partial class ApplicationTypeWebService
    {

        private WebServiceOperation webServiceOperationField;

        private WebServiceFaultCatch[] webServiceFaultCatchField;

        private System.Xml.XmlElement[] anyField;

        private string inputMsgNameField;

        private string outputMsgNameField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public WebServiceOperation WebServiceOperation
        {
            get
            {
                return this.webServiceOperationField;
            }
            set
            {
                this.webServiceOperationField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("WebServiceFaultCatch")]
        public WebServiceFaultCatch[] WebServiceFaultCatch
        {
            get
            {
                return this.webServiceFaultCatchField;
            }
            set
            {
                this.webServiceFaultCatchField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InputMsgName
        {
            get
            {
                return this.inputMsgNameField;
            }
            set
            {
                this.inputMsgNameField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OutputMsgName
        {
            get
            {
                return this.outputMsgNameField;
            }
            set
            {
                this.outputMsgNameField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
}