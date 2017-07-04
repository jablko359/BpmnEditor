namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    public partial class ApplicationTypeBusinessRule
    {

        private ApplicationTypeBusinessRuleRuleName ruleNameField;

        private ApplicationTypeBusinessRuleLocation locationField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public ApplicationTypeBusinessRuleRuleName RuleName
        {
            get
            {
                return this.ruleNameField;
            }
            set
            {
                this.ruleNameField = value;
            }
        }

        /// <uwagi/>
        public ApplicationTypeBusinessRuleLocation Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
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