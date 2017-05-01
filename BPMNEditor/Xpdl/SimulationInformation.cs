namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class SimulationInformation
    {

        private string costField;

        private TimeEstimation timeEstimationField;

        private SimulationInformationInstantiation instantiationField;

        private bool instantiationFieldSpecified;

        /// <uwagi/>
        public string Cost
        {
            get
            {
                return this.costField;
            }
            set
            {
                this.costField = value;
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
        public SimulationInformationInstantiation Instantiation
        {
            get
            {
                return this.instantiationField;
            }
            set
            {
                this.instantiationField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstantiationSpecified
        {
            get
            {
                return this.instantiationFieldSpecified;
            }
            set
            {
                this.instantiationFieldSpecified = value;
            }
        }
    }
}