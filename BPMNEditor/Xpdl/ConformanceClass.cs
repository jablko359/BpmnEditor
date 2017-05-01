namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class ConformanceClass
    {

        private ConformanceClassGraphConformance graphConformanceField;

        private bool graphConformanceFieldSpecified;

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GraphConformanceSpecified
        {
            get
            {
                return this.graphConformanceFieldSpecified;
            }
            set
            {
                this.graphConformanceFieldSpecified = value;
            }
        }
    }
}