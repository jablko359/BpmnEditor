namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Coordinates
    {

        private System.Xml.XmlElement[] anyField;

        private double xCoordinateField;

        private bool xCoordinateFieldSpecified;

        private double yCoordinateField;

        private bool yCoordinateFieldSpecified;

        private System.Xml.XmlAttribute[] anyAttrField;

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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double XCoordinate
        {
            get
            {
                return this.xCoordinateField;
            }
            set
            {
                this.xCoordinateField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool XCoordinateSpecified
        {
            get
            {
                return this.xCoordinateFieldSpecified;
            }
            set
            {
                this.xCoordinateFieldSpecified = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double YCoordinate
        {
            get
            {
                return this.yCoordinateField;
            }
            set
            {
                this.yCoordinateField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YCoordinateSpecified
        {
            get
            {
                return this.yCoordinateFieldSpecified;
            }
            set
            {
                this.yCoordinateFieldSpecified = value;
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