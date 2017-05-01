namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class SubFlow
    {

        private string[] actualParametersField;

        private string idField;

        private SubFlowExecution executionField;

        private bool executionFieldSpecified;

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ActualParameter", IsNullable = false)]
        public string[] ActualParameters
        {
            get
            {
                return this.actualParametersField;
            }
            set
            {
                this.actualParametersField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SubFlowExecution Execution
        {
            get
            {
                return this.executionField;
            }
            set
            {
                this.executionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExecutionSpecified
        {
            get
            {
                return this.executionFieldSpecified;
            }
            set
            {
                this.executionFieldSpecified = value;
            }
        }
    }
}