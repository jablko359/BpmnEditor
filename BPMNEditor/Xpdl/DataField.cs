namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class DataField
    {

        private DataType dataTypeField;

        private string initialValueField;

        private string lengthField;

        private string descriptionField;

        private ExtendedAttribute[] extendedAttributesField;

        private string idField;

        private string nameField;

        private DataFieldIsArray isArrayField;

        public DataField()
        {
            this.isArrayField = DataFieldIsArray.FALSE;
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
        public string InitialValue
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
        public string Length
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
        [System.Xml.Serialization.XmlArrayItemAttribute("ExtendedAttribute", IsNullable = false)]
        public ExtendedAttribute[] ExtendedAttributes
        {
            get
            {
                return this.extendedAttributesField;
            }
            set
            {
                this.extendedAttributesField = value;
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
        [System.ComponentModel.DefaultValueAttribute(DataFieldIsArray.FALSE)]
        public DataFieldIsArray IsArray
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
    }
}