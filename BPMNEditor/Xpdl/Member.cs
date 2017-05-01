namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class Member
    {

        private object itemField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("ArrayType", typeof(ArrayType))]
        [System.Xml.Serialization.XmlElementAttribute("BasicType", typeof(BasicType))]
        [System.Xml.Serialization.XmlElementAttribute("DeclaredType", typeof(DeclaredType))]
        [System.Xml.Serialization.XmlElementAttribute("EnumerationType", typeof(EnumerationType))]
        [System.Xml.Serialization.XmlElementAttribute("ExternalReference", typeof(ExternalReference))]
        [System.Xml.Serialization.XmlElementAttribute("ListType", typeof(ListType))]
        [System.Xml.Serialization.XmlElementAttribute("RecordType", typeof(RecordType))]
        [System.Xml.Serialization.XmlElementAttribute("SchemaType", typeof(SchemaType))]
        [System.Xml.Serialization.XmlElementAttribute("UnionType", typeof(UnionType))]
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
    }
}