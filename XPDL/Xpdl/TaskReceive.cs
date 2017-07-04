namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class TaskReceive
    {

        private MessageType messageField;

        private WebServiceOperation webServiceOperationField;

        private System.Xml.XmlElement[] anyField;

        private bool instantiateField;

        private TaskReceiveImplementation implementationField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public TaskReceive()
        {
            this.implementationField = TaskReceiveImplementation.WebService;
        }

        /// <uwagi/>
        public MessageType Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

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
        public bool Instantiate
        {
            get
            {
                return this.instantiateField;
            }
            set
            {
                this.instantiateField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(TaskReceiveImplementation.WebService)]
        public TaskReceiveImplementation Implementation
        {
            get
            {
                return this.implementationField;
            }
            set
            {
                this.implementationField = value;
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