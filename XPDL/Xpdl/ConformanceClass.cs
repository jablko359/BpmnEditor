namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ConformanceClass
    {

        private System.Xml.XmlElement[] anyField;

        private ConformanceClassGraphConformance graphConformanceField;

        private ConformanceClassBPMNModelPortabilityConformance bPMNModelPortabilityConformanceField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public ConformanceClass()
        {
            this.graphConformanceField = ConformanceClassGraphConformance.NON_BLOCKED;
            this.bPMNModelPortabilityConformanceField = ConformanceClassBPMNModelPortabilityConformance.NONE;
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
        [System.ComponentModel.DefaultValueAttribute(ConformanceClassGraphConformance.NON_BLOCKED)]
        public ConformanceClassGraphConformance GraphConformance
        {
            get
            {
                return this.graphConformanceField;
            }
            set
            {
                this.graphConformanceField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ConformanceClassBPMNModelPortabilityConformance.NONE)]
        public ConformanceClassBPMNModelPortabilityConformance BPMNModelPortabilityConformance
        {
            get
            {
                return this.bPMNModelPortabilityConformanceField;
            }
            set
            {
                this.bPMNModelPortabilityConformanceField = value;
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