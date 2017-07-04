namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute("Package", Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class PackageType
    {

        private PackageHeader packageHeaderField;

        private RedefinableHeader redefinableHeaderField;

        private ConformanceClass conformanceClassField;

        private Script scriptField;

        private ExternalPackages externalPackagesField;

        private TypeDeclarations typeDeclarationsField;

        private Participants participantsField;

        private Applications applicationsField;

        private DataFields dataFieldsField;

        private PartnerLinkTypes partnerLinkTypesField;

        private Pages pagesField;

        private GlobalActivities globalActivitiesField;

        private DataStores dataStoresField;

        private Pools poolsField;

        private MessageFlows messageFlowsField;

        private Associations associationsField;

        private Artifacts artifactsField;

        private WorkflowProcesses workflowProcessesField;

        private ExtendedAttribute[] extendedAttributesField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private string languageField;

        private string queryLanguageField;

        private System.Xml.XmlAttribute[] anyAttrField;

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
        public ExternalPackages ExternalPackages
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
        public TypeDeclarations TypeDeclarations
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
        public Participants Participants
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
        public Applications Applications
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
        public DataFields DataFields
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
        public PartnerLinkTypes PartnerLinkTypes
        {
            get
            {
                return this.partnerLinkTypesField;
            }
            set
            {
                this.partnerLinkTypesField = value;
            }
        }

        /// <uwagi/>
        public Pages Pages
        {
            get
            {
                return this.pagesField;
            }
            set
            {
                this.pagesField = value;
            }
        }

        /// <uwagi/>
        public GlobalActivities GlobalActivities
        {
            get
            {
                return this.globalActivitiesField;
            }
            set
            {
                this.globalActivitiesField = value;
            }
        }

        /// <uwagi/>
        public DataStores DataStores
        {
            get
            {
                return this.dataStoresField;
            }
            set
            {
                this.dataStoresField = value;
            }
        }

        /// <uwagi/>
        public Pools Pools
        {
            get
            {
                return this.poolsField;
            }
            set
            {
                this.poolsField = value;
            }
        }

        /// <uwagi/>
        public MessageFlows MessageFlows
        {
            get
            {
                return this.messageFlowsField;
            }
            set
            {
                this.messageFlowsField = value;
            }
        }

        /// <uwagi/>
        public Associations Associations
        {
            get
            {
                return this.associationsField;
            }
            set
            {
                this.associationsField = value;
            }
        }

        /// <uwagi/>
        public Artifacts Artifacts
        {
            get
            {
                return this.artifactsField;
            }
            set
            {
                this.artifactsField = value;
            }
        }

        /// <uwagi/>
        public WorkflowProcesses WorkflowProcesses
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

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string QueryLanguage
        {
            get
            {
                return this.queryLanguageField;
            }
            set
            {
                this.queryLanguageField = value;
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