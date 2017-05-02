namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class DataObject
    {

        private DataObjectDataFieldRef[] dataFieldRefField;

        private Object objectField;

        private NodeGraphicsInfos nodeGraphicsInfosField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private string stateField;

        private bool requiredForStartField;

        private bool requiredForStartFieldSpecified;

        private bool producedAtCompletionField;

        private bool producedAtCompletionFieldSpecified;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("DataFieldRef")]
        public DataObjectDataFieldRef[] DataFieldRef
        {
            get
            {
                return this.dataFieldRefField;
            }
            set
            {
                this.dataFieldRefField = value;
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
        public NodeGraphicsInfos NodeGraphicsInfos
        {
            get
            {
                return this.nodeGraphicsInfosField;
            }
            set
            {
                this.nodeGraphicsInfosField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RequiredForStart
        {
            get
            {
                return this.requiredForStartField;
            }
            set
            {
                this.requiredForStartField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequiredForStartSpecified
        {
            get
            {
                return this.requiredForStartFieldSpecified;
            }
            set
            {
                this.requiredForStartFieldSpecified = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ProducedAtCompletion
        {
            get
            {
                return this.producedAtCompletionField;
            }
            set
            {
                this.producedAtCompletionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProducedAtCompletionSpecified
        {
            get
            {
                return this.producedAtCompletionFieldSpecified;
            }
            set
            {
                this.producedAtCompletionFieldSpecified = value;
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