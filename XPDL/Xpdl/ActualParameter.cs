namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ActualParameter
    {

        private ExpressionType formalExpressionField;

        private string[] sourceField;

        private Assignments assignmentsField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string targetField;

        /// <uwagi/>
        public ExpressionType FormalExpression
        {
            get
            {
                return this.formalExpressionField;
            }
            set
            {
                this.formalExpressionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("Source", DataType = "NMTOKEN")]
        public string[] Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <uwagi/>
        public Assignments Assignments
        {
            get
            {
                return this.assignmentsField;
            }
            set
            {
                this.assignmentsField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
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
    }
}