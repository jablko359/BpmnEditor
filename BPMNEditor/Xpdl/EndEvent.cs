namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class EndEvent
    {

        private object itemField;

        private ItemChoiceType1 itemElementNameField;

        private EndEventResult resultField;

        private EndEventImplementation implementationField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public EndEvent()
        {
            this.implementationField = EndEventImplementation.WebService;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ResultError", typeof(ResultError))]
        [System.Xml.Serialization.XmlElementAttribute("ResultMultiple", typeof(ResultMultiple))]
        [System.Xml.Serialization.XmlElementAttribute("ResultTerminate", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerEscalation", typeof(TriggerEscalation))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultCancel", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultCompensation", typeof(TriggerResultCompensation))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultMessage", typeof(TriggerResultMessage))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultSignal", typeof(TriggerResultSignal))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public EndEventResult Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(EndEventImplementation.WebService)]
        public EndEventImplementation Implementation
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