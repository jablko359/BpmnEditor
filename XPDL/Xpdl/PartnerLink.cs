namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class PartnerLink
    {

        private PartnerLinkMyRole myRoleField;

        private PartnerLinkPartnerRole partnerRoleField;

        private System.Xml.XmlElement[] anyField;

        private string nameField;

        private string idField;

        private string partnerLinkTypeIdField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public PartnerLinkMyRole MyRole
        {
            get
            {
                return this.myRoleField;
            }
            set
            {
                this.myRoleField = value;
            }
        }

        /// <uwagi/>
        public PartnerLinkPartnerRole PartnerRole
        {
            get
            {
                return this.partnerRoleField;
            }
            set
            {
                this.partnerRoleField = value;
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
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string PartnerLinkTypeId
        {
            get
            {
                return this.partnerLinkTypeIdField;
            }
            set
            {
                this.partnerLinkTypeIdField = value;
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