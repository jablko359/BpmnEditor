namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ResultMultiple
    {

        private TriggerResultMessage triggerResultMessageField;

        private TriggerEscalation triggerEscalationField;

        private object triggerResultCancelField;

        private TriggerResultCompensation triggerResultCompensationField;

        private TriggerResultSignal triggerResultSignalField;

        private object resultTerminateField;

        private ResultError resultErrorField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public TriggerResultMessage TriggerResultMessage
        {
            get
            {
                return this.triggerResultMessageField;
            }
            set
            {
                this.triggerResultMessageField = value;
            }
        }

        /// <uwagi/>
        public TriggerEscalation TriggerEscalation
        {
            get
            {
                return this.triggerEscalationField;
            }
            set
            {
                this.triggerEscalationField = value;
            }
        }

        /// <uwagi/>
        public object TriggerResultCancel
        {
            get
            {
                return this.triggerResultCancelField;
            }
            set
            {
                this.triggerResultCancelField = value;
            }
        }

        /// <uwagi/>
        public TriggerResultCompensation TriggerResultCompensation
        {
            get
            {
                return this.triggerResultCompensationField;
            }
            set
            {
                this.triggerResultCompensationField = value;
            }
        }

        /// <uwagi/>
        public TriggerResultSignal TriggerResultSignal
        {
            get
            {
                return this.triggerResultSignalField;
            }
            set
            {
                this.triggerResultSignalField = value;
            }
        }

        /// <uwagi/>
        public object ResultTerminate
        {
            get
            {
                return this.resultTerminateField;
            }
            set
            {
                this.resultTerminateField = value;
            }
        }

        /// <uwagi/>
        public ResultError ResultError
        {
            get
            {
                return this.resultErrorField;
            }
            set
            {
                this.resultErrorField = value;
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