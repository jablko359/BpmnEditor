namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    public partial class ExpressionType
    {

        private System.Xml.XmlElement[] itemsField;

        private string[] textField;

        private string scriptTypeField;

        private string scriptVersionField;

        private string scriptGrammarField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ScriptType
        {
            get
            {
                return this.scriptTypeField;
            }
            set
            {
                this.scriptTypeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ScriptVersion
        {
            get
            {
                return this.scriptVersionField;
            }
            set
            {
                this.scriptVersionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string ScriptGrammar
        {
            get
            {
                return this.scriptGrammarField;
            }
            set
            {
                this.scriptGrammarField = value;
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