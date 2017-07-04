namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ConnectorGraphicsInfo
    {

        private Coordinates[] coordinatesField;

        private System.Xml.XmlElement[] anyField;

        private string toolIdField;

        private bool isVisibleField;

        private string pageField;

        private string pageIdField;

        private string styleField;

        private string borderColorField;

        private string fillColorField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public ConnectorGraphicsInfo()
        {
            this.isVisibleField = true;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("Coordinates")]
        public Coordinates[] Coordinates
        {
            get
            {
                return this.coordinatesField;
            }
            set
            {
                this.coordinatesField = value;
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
        public string ToolId
        {
            get
            {
                return this.toolIdField;
            }
            set
            {
                this.toolIdField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool IsVisible
        {
            get
            {
                return this.isVisibleField;
            }
            set
            {
                this.isVisibleField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string Page
        {
            get
            {
                return this.pageField;
            }
            set
            {
                this.pageField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string PageId
        {
            get
            {
                return this.pageIdField;
            }
            set
            {
                this.pageIdField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Style
        {
            get
            {
                return this.styleField;
            }
            set
            {
                this.styleField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BorderColor
        {
            get
            {
                return this.borderColorField;
            }
            set
            {
                this.borderColorField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FillColor
        {
            get
            {
                return this.fillColorField;
            }
            set
            {
                this.fillColorField = value;
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