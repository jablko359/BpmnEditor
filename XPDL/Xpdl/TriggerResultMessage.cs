namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class TriggerResultMessage
    {

        private MessageType messageField;

        private WebServiceOperation webServiceOperationField;

        private System.Xml.XmlElement[] anyField;

        private TriggerResultMessageCatchThrow catchThrowField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public TriggerResultMessage()
        {
            this.catchThrowField = TriggerResultMessageCatchThrow.CATCH;
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
        [System.ComponentModel.DefaultValueAttribute(TriggerResultMessageCatchThrow.CATCH)]
        public TriggerResultMessageCatchThrow CatchThrow
        {
            get
            {
                return this.catchThrowField;
            }
            set
            {
                this.catchThrowField = value;
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