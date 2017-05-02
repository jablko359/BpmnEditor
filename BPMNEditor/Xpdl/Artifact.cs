namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Artifact
    {

        private Object objectField;

        private Group groupField;

        private DataObject dataObjectField;

        private NodeGraphicsInfos nodeGraphicsInfosField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private ArtifactArtifactType artifactTypeField;

        private string textAnnotationField;

        private string group1Field;

        private System.Xml.XmlAttribute[] anyAttrField;

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
        public Group Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }

        /// <uwagi/>
        public DataObject DataObject
        {
            get
            {
                return this.dataObjectField;
            }
            set
            {
                this.dataObjectField = value;
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
        public ArtifactArtifactType ArtifactType
        {
            get
            {
                return this.artifactTypeField;
            }
            set
            {
                this.artifactTypeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TextAnnotation
        {
            get
            {
                return this.textAnnotationField;
            }
            set
            {
                this.textAnnotationField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute("Group")]
        public string Group1
        {
            get
            {
                return this.group1Field;
            }
            set
            {
                this.group1Field = value;
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