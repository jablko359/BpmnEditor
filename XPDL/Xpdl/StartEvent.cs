namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class StartEvent
    {

        private object itemField;

        private StartEventTrigger triggerField;

        private StartEventImplementation implementationField;

        private bool interruptingField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public StartEvent()
        {
            this.implementationField = StartEventImplementation.WebService;
            this.interruptingField = true;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ResultError", typeof(ResultError))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerConditional", typeof(TriggerConditional))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerEscalation", typeof(TriggerEscalation))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerMultiple", typeof(TriggerMultiple))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultCompensation", typeof(TriggerResultCompensation))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultMessage", typeof(TriggerResultMessage))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultSignal", typeof(TriggerResultSignal))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerTimer", typeof(TriggerTimer))]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public StartEventTrigger Trigger
        {
            get
            {
                return this.triggerField;
            }
            set
            {
                this.triggerField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(StartEventImplementation.WebService)]
        public StartEventImplementation Implementation
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool Interrupting
        {
            get
            {
                return this.interruptingField;
            }
            set
            {
                this.interruptingField = value;
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