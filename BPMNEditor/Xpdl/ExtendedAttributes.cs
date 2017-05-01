namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class ExtendedAttributes
    {

        private ExtendedAttribute[] extendedAttributeField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ExtendedAttribute")]
        public ExtendedAttribute[] ExtendedAttribute
        {
            get
            {
                return this.extendedAttributeField;
            }
            set
            {
                this.extendedAttributeField = value;
            }
        }
    }
}