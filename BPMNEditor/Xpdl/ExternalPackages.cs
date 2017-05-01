namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class ExternalPackages
    {

        private ExternalPackage[] externalPackageField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ExternalPackage")]
        public ExternalPackage[] ExternalPackage
        {
            get
            {
                return this.externalPackageField;
            }
            set
            {
                this.externalPackageField = value;
            }
        }
    }
}