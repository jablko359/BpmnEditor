namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class TaskService
    {

        private MessageType messageInField;

        private MessageType messageOutField;

        private WebServiceOperation webServiceOperationField;

        private WebServiceFaultCatch[] webServiceFaultCatchField;

        private System.Xml.XmlElement[] anyField;

        private TaskServiceImplementation implementationField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public TaskService()
        {
            this.implementationField = TaskServiceImplementation.WebService;
        }

        /// <uwagi/>
        public MessageType MessageIn
        {
            get
            {
                return this.messageInField;
            }
            set
            {
                this.messageInField = value;
            }
        }

        /// <uwagi/>
        public MessageType MessageOut
        {
            get
            {
                return this.messageOutField;
            }
            set
            {
                this.messageOutField = value;
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
        [System.ComponentModel.DefaultValueAttribute(TaskServiceImplementation.WebService)]
        public TaskServiceImplementation Implementation
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