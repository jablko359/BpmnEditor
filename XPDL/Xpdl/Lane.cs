namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Lane
    {

        private Object objectField;

        private NodeGraphicsInfos nodeGraphicsInfosField;

        private Performers performersField;

        private LaneNestedLane[] nestedLaneField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private string parentLaneField;

        private string parentPoolField;

        private LaneOrientation orientationField;

        private bool orientationFieldSpecified;

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
        public Performers Performers
        {
            get
            {
                return this.performersField;
            }
            set
            {
                this.performersField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("NestedLane")]
        public LaneNestedLane[] NestedLane
        {
            get
            {
                return this.nestedLaneField;
            }
            set
            {
                this.nestedLaneField = value;
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
        public string ParentLane
        {
            get
            {
                return this.parentLaneField;
            }
            set
            {
                this.parentLaneField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string ParentPool
        {
            get
            {
                return this.parentPoolField;
            }
            set
            {
                this.parentPoolField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public LaneOrientation Orientation
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OrientationSpecified
        {
            get
            {
                return this.orientationFieldSpecified;
            }
            set
            {
                this.orientationFieldSpecified = value;
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