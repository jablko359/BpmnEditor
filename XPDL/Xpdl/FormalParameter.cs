namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class FormalParameter
    {

        private DataType dataTypeField;

        private ExpressionType initialValueField;

        private Description descriptionField;

        private Length lengthField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private FormalParameterMode modeField;

        private string nameField;

        private bool readOnlyField;

        private bool requiredField;

        private bool isArrayField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public FormalParameter()
        {
            this.modeField = FormalParameterMode.IN;
            this.readOnlyField = false;
            this.requiredField = false;
            this.isArrayField = false;
        }

        /// <uwagi/>
        public DataType DataType
        {
            get
            {
                return this.dataTypeField;
            }
            set
            {
                this.dataTypeField = value;
            }
        }

        /// <uwagi/>
        public ExpressionType InitialValue
        {
            get
            {
                return this.initialValueField;
            }
            set
            {
                this.initialValueField = value;
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
        public Length Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(FormalParameterMode.IN)]
        public FormalParameterMode Mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ReadOnly
        {
            get
            {
                return this.readOnlyField;
            }
            set
            {
                this.readOnlyField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Required
        {
            get
            {
                return this.requiredField;
            }
            set
            {
                this.requiredField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsArray
        {
            get
            {
                return this.isArrayField;
            }
            set
            {
                this.isArrayField = value;
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