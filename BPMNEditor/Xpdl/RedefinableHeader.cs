namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class RedefinableHeader
    {

        private string authorField;

        private string versionField;

        private string codepageField;

        private string countrykeyField;

        private string[] responsiblesField;

        private RedefinableHeaderPublicationStatus publicationStatusField;

        private bool publicationStatusFieldSpecified;

        /// <uwagi/>
        public string Author
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
        public string Version
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
        public string Codepage
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
        public string Countrykey
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
        [System.Xml.Serialization.XmlArrayItemAttribute("Responsible", IsNullable = false)]
        public string[] Responsibles
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
    }
}