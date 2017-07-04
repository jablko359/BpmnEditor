namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class PackageHeader
    {

        private XPDLVersion xPDLVersionField;

        private Vendor vendorField;

        private Created createdField;

        private ModificationDate modificationDateField;

        private Description descriptionField;

        private Documentation documentationField;

        private PriorityUnit priorityUnitField;

        private CostUnit costUnitField;

        private VendorExtensions vendorExtensionsField;

        private LayoutInfo layoutInfoField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        public XPDLVersion XPDLVersion
        {
            get
            {
                return this.xPDLVersionField;
            }
            set
            {
                this.xPDLVersionField = value;
            }
        }

        /// <uwagi/>
        public Vendor Vendor
        {
            get
            {
                return this.vendorField;
            }
            set
            {
                this.vendorField = value;
            }
        }

        /// <uwagi/>
        public Created Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <uwagi/>
        public ModificationDate ModificationDate
        {
            get
            {
                return this.modificationDateField;
            }
            set
            {
                this.modificationDateField = value;
            }
        }

        /// <uwagi/>
        public Description Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <uwagi/>
        public Documentation Documentation
        {
            get
            {
                return this.documentationField;
            }
            set
            {
                this.documentationField = value;
            }
        }

        /// <uwagi/>
        public PriorityUnit PriorityUnit
        {
            get
            {
                return this.priorityUnitField;
            }
            set
            {
                this.priorityUnitField = value;
            }
        }

        /// <uwagi/>
        public CostUnit CostUnit
        {
            get
            {
                return this.costUnitField;
            }
            set
            {
                this.costUnitField = value;
            }
        }

        /// <uwagi/>
        public VendorExtensions VendorExtensions
        {
            get
            {
                return this.vendorExtensionsField;
            }
            set
            {
                this.vendorExtensionsField = value;
            }
        }

        /// <uwagi/>
        public LayoutInfo LayoutInfo
        {
            get
            {
                return this.layoutInfoField;
            }
            set
            {
                this.layoutInfoField = value;
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