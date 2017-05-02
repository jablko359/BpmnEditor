namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    public partial class ApplicationType
    {

        private object itemField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("BusinessRule", typeof(ApplicationTypeBusinessRule))]
        [System.Xml.Serialization.XmlElementAttribute("Ejb", typeof(ApplicationTypeEjb))]
        [System.Xml.Serialization.XmlElementAttribute("Form", typeof(ApplicationTypeForm))]
        [System.Xml.Serialization.XmlElementAttribute("Pojo", typeof(ApplicationTypePojo))]
        [System.Xml.Serialization.XmlElementAttribute("Script", typeof(ApplicationTypeScript))]
        [System.Xml.Serialization.XmlElementAttribute("WebService", typeof(ApplicationTypeWebService))]
        [System.Xml.Serialization.XmlElementAttribute("Xslt", typeof(ApplicationTypeXslt))]
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