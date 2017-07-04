namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ProcessHeader
    {

        private Created createdField;

        private Description descriptionField;

        private Priority priorityField;

        private Limit limitField;

        private ValidFrom validFromField;

        private ValidTo validToField;

        private TimeEstimation timeEstimationField;

        private System.Xml.XmlElement[] anyField;

        private ProcessHeaderDurationUnit durationUnitField;

        private bool durationUnitFieldSpecified;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public Created Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <uwagi/>
        public Description Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <uwagi/>
        public Priority Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <uwagi/>
        public Limit Limit
        {
            get
            {
                return this.limitField;
            }
            set
            {
                this.limitField = value;
            }
        }

        /// <uwagi/>
        public ValidFrom ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <uwagi/>
        public ValidTo ValidTo
        {
            get
            {
                return this.validToField;
            }
            set
            {
                this.validToField = value;
            }
        }

        /// <uwagi/>
        public TimeEstimation TimeEstimation
        {
            get
            {
                return this.timeEstimationField;
            }
            set
            {
                this.timeEstimationField = value;
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
        public ProcessHeaderDurationUnit DurationUnit
        {
            get
            {
                return this.durationUnitField;
            }
            set
            {
                this.durationUnitField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DurationUnitSpecified
        {
            get
            {
                return this.durationUnitFieldSpecified;
            }
            set
            {
                this.durationUnitFieldSpecified = value;
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