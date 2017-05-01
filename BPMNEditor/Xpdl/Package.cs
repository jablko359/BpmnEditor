namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class Package
    {

        private PackageHeader packageHeaderField;

        private RedefinableHeader redefinableHeaderField;

        private ConformanceClass conformanceClassField;

        private Script scriptField;

        private ExternalPackage[] externalPackagesField;

        private TypeDeclaration[] typeDeclarationsField;

        private Participant[] participantsField;

        private Application[] applicationsField;

        private DataField[] dataFieldsField;

        private WorkflowProcess[] workflowProcessesField;

        private ExtendedAttribute[] extendedAttributesField;

        private string idField;

        private string nameField;

        /// <uwagi/>
        public PackageHeader PackageHeader
        {
            get
            {
                return this.packageHeaderField;
            }
            set
            {
                this.packageHeaderField = value;
            }
        }

        /// <uwagi/>
        public RedefinableHeader RedefinableHeader
        {
            get
            {
                return this.redefinableHeaderField;
            }
            set
            {
                this.redefinableHeaderField = value;
            }
        }

        /// <uwagi/>
        public ConformanceClass ConformanceClass
        {
            get
            {
                return this.conformanceClassField;
            }
            set
            {
                this.conformanceClassField = value;
            }
        }

        /// <uwagi/>
        public Script Script
        {
            get
            {
                return this.scriptField;
            }
            set
            {
                this.scriptField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ExternalPackage", IsNullable = false)]
        public ExternalPackage[] ExternalPackages
        {
            get
            {
                return this.externalPackagesField;
            }
            set
            {
                this.externalPackagesField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("TypeDeclaration", IsNullable = false)]
        public TypeDeclaration[] TypeDeclarations
        {
            get
            {
                return this.typeDeclarationsField;
            }
            set
            {
                this.typeDeclarationsField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Participant", IsNullable = false)]
        public Participant[] Participants
        {
            get
            {
                return this.participantsField;
            }
            set
            {
                this.participantsField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Application", IsNullable = false)]
        public Application[] Applications
        {
            get
            {
                return this.applicationsField;
            }
            set
            {
                this.applicationsField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("DataField", IsNullable = false)]
        public DataField[] DataFields
        {
            get
            {
                return this.dataFieldsField;
            }
            set
            {
                this.dataFieldsField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("WorkflowProcess", IsNullable = false)]
        public WorkflowProcess[] WorkflowProcesses
        {
            get
            {
                return this.workflowProcessesField;
            }
            set
            {
                this.workflowProcessesField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ExtendedAttribute", IsNullable = false)]
        public ExtendedAttribute[] ExtendedAttributes
        {
            get
            {
                return this.extendedAttributesField;
            }
            set
            {
                this.extendedAttributesField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
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
    }
}