namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class ProcessHeader
    {

        private string createdField;

        private string descriptionField;

        private string priorityField;

        private string limitField;

        private string validFromField;

        private string validToField;

        private TimeEstimation timeEstimationField;

        private ProcessHeaderDurationUnit durationUnitField;

        private bool durationUnitFieldSpecified;

        /// <uwagi/>
        public string Created
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
        public string Description
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
        public string Priority
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
        public string Limit
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
        public string ValidFrom
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
        public string ValidTo
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
    }
}