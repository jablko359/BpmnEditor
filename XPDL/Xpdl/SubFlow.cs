namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class SubFlow
    {

        private object itemField;

        private EndPoint endPointField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private SubFlowExecution executionField;

        private SubFlowView viewField;

        private string packageRefField;

        private string instanceDataFieldField;

        private string startActivitySetIdField;

        private string startActivityIdField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public SubFlow()
        {
            this.executionField = SubFlowExecution.SYNCHR;
            this.viewField = SubFlowView.COLLAPSED;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ActualParameters", typeof(ActualParameters))]
        [System.Xml.Serialization.XmlElementAttribute("DataMappings", typeof(DataMappings))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <uwagi/>
        public EndPoint EndPoint
        {
            get
            {
                return this.endPointField;
            }
            set
            {
                this.endPointField = value;
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
        [System.ComponentModel.DefaultValueAttribute(SubFlowExecution.SYNCHR)]
        public SubFlowExecution Execution
        {
            get
            {
                return this.executionField;
            }
            set
            {
                this.executionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(SubFlowView.COLLAPSED)]
        public SubFlowView View
        {
            get
            {
                return this.viewField;
            }
            set
            {
                this.viewField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string PackageRef
        {
            get
            {
                return this.packageRefField;
            }
            set
            {
                this.packageRefField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InstanceDataField
        {
            get
            {
                return this.instanceDataFieldField;
            }
            set
            {
                this.instanceDataFieldField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string StartActivitySetId
        {
            get
            {
                return this.startActivitySetIdField;
            }
            set
            {
                this.startActivitySetIdField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string StartActivityId
        {
            get
            {
                return this.startActivityIdField;
            }
            set
            {
                this.startActivityIdField = value;
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