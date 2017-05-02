namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class TypeDeclaration
    {

        private BasicType basicTypeField;

        private DeclaredType declaredTypeField;

        private SchemaType schemaTypeField;

        private ExternalReference externalReferenceField;

        private RecordType recordTypeField;

        private UnionType unionTypeField;

        private EnumerationType enumerationTypeField;

        private ArrayType arrayTypeField;

        private ListType listTypeField;

        private Description descriptionField;

        private ExtendedAttribute[] extendedAttributesField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public BasicType BasicType
        {
            get
            {
                return this.basicTypeField;
            }
            set
            {
                this.basicTypeField = value;
            }
        }

        /// <uwagi/>
        public DeclaredType DeclaredType
        {
            get
            {
                return this.declaredTypeField;
            }
            set
            {
                this.declaredTypeField = value;
            }
        }

        /// <uwagi/>
        public SchemaType SchemaType
        {
            get
            {
                return this.schemaTypeField;
            }
            set
            {
                this.schemaTypeField = value;
            }
        }

        /// <uwagi/>
        public ExternalReference ExternalReference
        {
            get
            {
                return this.externalReferenceField;
            }
            set
            {
                this.externalReferenceField = value;
            }
        }

        /// <uwagi/>
        public RecordType RecordType
        {
            get
            {
                return this.recordTypeField;
            }
            set
            {
                this.recordTypeField = value;
            }
        }

        /// <uwagi/>
        public UnionType UnionType
        {
            get
            {
                return this.unionTypeField;
            }
            set
            {
                this.unionTypeField = value;
            }
        }

        /// <uwagi/>
        public EnumerationType EnumerationType
        {
            get
            {
                return this.enumerationTypeField;
            }
            set
            {
                this.enumerationTypeField = value;
            }
        }

        /// <uwagi/>
        public ArrayType ArrayType
        {
            get
            {
                return this.arrayTypeField;
            }
            set
            {
                this.arrayTypeField = value;
            }
        }

        /// <uwagi/>
        public ListType ListType
        {
            get
            {
                return this.listTypeField;
            }
            set
            {
                this.listTypeField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
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