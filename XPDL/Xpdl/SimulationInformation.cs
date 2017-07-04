namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class SimulationInformation
    {

        private object itemField;

        private TimeEstimation timeEstimationField;

        private System.Xml.XmlElement[] anyField;

        private SimulationInformationInstantiation instantiationField;

        private bool instantiationFieldSpecified;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("Cost", typeof(Cost))]
        [System.Xml.Serialization.XmlElementAttribute("CostStructure", typeof(CostStructure))]
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