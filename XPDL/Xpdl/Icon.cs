namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Icon
    {

        private string xCOORDField;

        private string yCOORDField;

        private string wIDTHField;

        private string hEIGHTField;

        private IconSHAPE sHAPEField;

        private System.Xml.XmlAttribute[] anyAttrField;

        private string valueField;

        public Icon()
        {
            this.sHAPEField = IconSHAPE.RoundRectangle;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string XCOORD
        {
            get
            {
                return this.xCOORDField;
            }
            set
            {
                this.xCOORDField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string YCOORD
        {
            get
            {
                return this.yCOORDField;
            }
            set
            {
                this.yCOORDField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string WIDTH
        {
            get
            {
                return this.wIDTHField;
            }
            set
            {
                this.wIDTHField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string HEIGHT
        {
            get
            {
                return this.hEIGHTField;
            }
            set
            {
                this.hEIGHTField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(IconSHAPE.RoundRectangle)]
        public IconSHAPE SHAPE
        {
            get
            {
                return this.sHAPEField;
            }
            set
            {
                this.sHAPEField = value;
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

        /// <uwagi/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}