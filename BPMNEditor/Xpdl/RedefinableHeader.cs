namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class RedefinableHeader
    {

        private Author authorField;

        private Version versionField;

        private Codepage codepageField;

        private Countrykey countrykeyField;

        private Responsibles responsiblesField;

        private System.Xml.XmlElement[] anyField;

        private RedefinableHeaderPublicationStatus publicationStatusField;

        private bool publicationStatusFieldSpecified;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public Author Author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <uwagi/>
        public Version Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <uwagi/>
        public Codepage Codepage
        {
            get
            {
                return this.codepageField;
            }
            set
            {
                this.codepageField = value;
            }
        }

        /// <uwagi/>
        public Countrykey Countrykey
        {
            get
            {
                return this.countrykeyField;
            }
            set
            {
                this.countrykeyField = value;
            }
        }

        /// <uwagi/>
        public Responsibles Responsibles
        {
            get
            {
                return this.responsiblesField;
            }
            set
            {
                this.responsiblesField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public RedefinableHeaderPublicationStatus PublicationStatus
        {
            get
            {
                return this.publicationStatusField;
            }
            set
            {
                this.publicationStatusField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PublicationStatusSpecified
        {
            get
            {
                return this.publicationStatusFieldSpecified;
            }
            set
            {
                this.publicationStatusFieldSpecified = value;
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