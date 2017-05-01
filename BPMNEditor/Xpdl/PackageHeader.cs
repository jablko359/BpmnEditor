namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class PackageHeader
    {

        private string xPDLVersionField;

        private string vendorField;

        private string createdField;

        private string descriptionField;

        private string documentationField;

        private string priorityUnitField;

        private string costUnitField;

        /// <uwagi/>
        public string XPDLVersion
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
        public string Vendor
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
        public string Created
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
        public string Description
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
        public string Documentation
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
        public string PriorityUnit
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
        public string CostUnit
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
    }
}