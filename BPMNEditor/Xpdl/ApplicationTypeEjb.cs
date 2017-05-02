namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    public partial class ApplicationTypeEjb
    {

        private ApplicationTypeEjbJndiName jndiNameField;

        private ApplicationTypeEjbHomeClass homeClassField;

        private ApplicationTypeEjbMethod methodField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public ApplicationTypeEjbJndiName JndiName
        {
            get
            {
                return this.jndiNameField;
            }
            set
            {
                this.jndiNameField = value;
            }
        }

        /// <uwagi/>
        public ApplicationTypeEjbHomeClass HomeClass
        {
            get
            {
                return this.homeClassField;
            }
            set
            {
                this.homeClassField = value;
            }
        }

        /// <uwagi/>
        public ApplicationTypeEjbMethod Method
        {
            get
            {
                return this.methodField;
            }
            set
            {
                this.methodField = value;
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