namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class IntermediateEvent
    {

        private object itemField;

        private IntermediateEventTrigger triggerField;

        private IntermediateEventImplementation implementationField;

        private string targetField;

        private bool interruptingField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public IntermediateEvent()
        {
            this.implementationField = IntermediateEventImplementation.WebService;
            this.interruptingField = true;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ResultError", typeof(ResultError))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerConditional", typeof(TriggerConditional))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerEscalation", typeof(TriggerEscalation))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerIntermediateMultiple", typeof(TriggerIntermediateMultiple))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultCancel", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultCompensation", typeof(TriggerResultCompensation))]
        [System.Xml.Serialization.XmlElementAttribute("TriggerResultLink", typeof(TriggerResultLink))]
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
        public IntermediateEventTrigger Trigger
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
        [System.ComponentModel.DefaultValueAttribute(IntermediateEventImplementation.WebService)]
        public IntermediateEventImplementation Implementation
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string Target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
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