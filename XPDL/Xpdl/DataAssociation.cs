namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class DataAssociation
    {

        private Description descriptionField;

        private ExtendedAttribute[] extendedAttributesField;

        private Object objectField;

        private ConnectorGraphicsInfos connectorGraphicsInfosField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private string fromField;

        private string toField;

        private string actualParameterRefField;

        private System.Xml.XmlAttribute[] anyAttrField;

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
        public Object Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <uwagi/>
        public ConnectorGraphicsInfos ConnectorGraphicsInfos
        {
            get
            {
                return this.connectorGraphicsInfosField;
            }
            set
            {
                this.connectorGraphicsInfosField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string From
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string To
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string ActualParameterRef
        {
            get
            {
                return this.actualParameterRefField;
            }
            set
            {
                this.actualParameterRefField = value;
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