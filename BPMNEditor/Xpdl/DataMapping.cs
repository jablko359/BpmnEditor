namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class DataMapping
    {

        private ExpressionType actualField;

        private ExpressionType testValueField;

        private System.Xml.XmlElement[] anyField;

        private string formalField;

        private DataMappingDirection directionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public DataMapping()
        {
            this.directionField = DataMappingDirection.IN;
        }

        /// <uwagi/>
        public ExpressionType Actual
        {
            get
            {
                return this.actualField;
            }
            set
            {
                this.actualField = value;
            }
        }

        /// <uwagi/>
        public ExpressionType TestValue
        {
            get
            {
                return this.testValueField;
            }
            set
            {
                this.testValueField = value;
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
        public string Formal
        {
            get
            {
                return this.formalField;
            }
            set
            {
                this.formalField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(DataMappingDirection.IN)]
        public DataMappingDirection Direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
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