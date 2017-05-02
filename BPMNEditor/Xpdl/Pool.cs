namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Pool
    {

        private Lanes lanesField;

        private Object objectField;

        private NodeGraphicsInfos nodeGraphicsInfosField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private PoolOrientation orientationField;

        private string processField;

        private string participantField;

        private bool boundaryVisibleField;

        private bool mainPoolField;

        private bool multiInstanceField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public Pool()
        {
            this.orientationField = PoolOrientation.HORIZONTAL;
            this.mainPoolField = false;
            this.multiInstanceField = false;
        }

        /// <uwagi/>
        public Lanes Lanes
        {
            get
            {
                return this.lanesField;
            }
            set
            {
                this.lanesField = value;
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
        [System.ComponentModel.DefaultValueAttribute(PoolOrientation.HORIZONTAL)]
        public PoolOrientation Orientation
        {
            get
            {
                return this.orientationField;
            }
            set
            {
                this.orientationField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string Process
        {
            get
            {
                return this.processField;
            }
            set
            {
                this.processField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string Participant
        {
            get
            {
                return this.participantField;
            }
            set
            {
                this.participantField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool BoundaryVisible
        {
            get
            {
                return this.boundaryVisibleField;
            }
            set
            {
                this.boundaryVisibleField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool MainPool
        {
            get
            {
                return this.mainPoolField;
            }
            set
            {
                this.mainPoolField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool MultiInstance
        {
            get
            {
                return this.multiInstanceField;
            }
            set
            {
                this.multiInstanceField = value;
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