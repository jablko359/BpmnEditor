namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute("WorkflowProcess", Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ProcessType
    {

        private ProcessHeader processHeaderField;

        private RedefinableHeader redefinableHeaderField;

        private FormalParameters formalParametersField;

        private InputSets inputSetsField;

        private OutputSets outputSetsField;

        private object[] itemsField;

        private ActivitySets activitySetsField;

        private Activities activitiesField;

        private DataObjects dataObjectsField;

        private DataInputOutputs dataInputOutputsField;

        private DataStoreReferences dataStoreReferencesField;

        private Transitions transitionsField;

        private DataAssociations dataAssociationsField;

        private ExtendedAttribute[] extendedAttributesField;

        private Assignments assignmentsField;

        private PartnerLinks partnerLinksField;

        private Object objectField;

        private object[] items1Field;

        private string idField;

        private string nameField;

        private ProcessTypeAccessLevel accessLevelField;

        private ProcessTypeProcessType processType1Field;

        private ProcessTypeStatus statusField;

        private bool suppressJoinFailureField;

        private bool enableInstanceCompensationField;

        private bool adHocField;

        private ProcessTypeAdHocOrdering adHocOrderingField;

        private string adHocCompletionConditionField;

        private string defaultStartActivitySetIdField;

        private string defaultStartActivityIdField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public ProcessType()
        {
            this.accessLevelField = ProcessTypeAccessLevel.PUBLIC;
            this.processType1Field = ProcessTypeProcessType.None;
            this.statusField = ProcessTypeStatus.None;
            this.suppressJoinFailureField = false;
            this.enableInstanceCompensationField = false;
            this.adHocField = false;
            this.adHocOrderingField = ProcessTypeAdHocOrdering.Parallel;
        }

        /// <uwagi/>
        public ProcessHeader ProcessHeader
        {
            get
            {
                return this.processHeaderField;
            }
            set
            {
                this.processHeaderField = value;
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
        public FormalParameters FormalParameters
        {
            get
            {
                return this.formalParametersField;
            }
            set
            {
                this.formalParametersField = value;
            }
        }

        /// <uwagi/>
        public InputSets InputSets
        {
            get
            {
                return this.inputSetsField;
            }
            set
            {
                this.inputSetsField = value;
            }
        }

        /// <uwagi/>
        public OutputSets OutputSets
        {
            get
            {
                return this.outputSetsField;
            }
            set
            {
                this.outputSetsField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("Applications", typeof(Applications))]
        [System.Xml.Serialization.XmlElementAttribute("DataFields", typeof(DataFields))]
        [System.Xml.Serialization.XmlElementAttribute("Participants", typeof(Participants))]
        public object[] Items
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
        public ActivitySets ActivitySets
        {
            get
            {
                return this.activitySetsField;
            }
            set
            {
                this.activitySetsField = value;
            }
        }

        /// <uwagi/>
        public Activities Activities
        {
            get
            {
                return this.activitiesField;
            }
            set
            {
                this.activitiesField = value;
            }
        }

        /// <uwagi/>
        public DataObjects DataObjects
        {
            get
            {
                return this.dataObjectsField;
            }
            set
            {
                this.dataObjectsField = value;
            }
        }

        /// <uwagi/>
        public DataInputOutputs DataInputOutputs
        {
            get
            {
                return this.dataInputOutputsField;
            }
            set
            {
                this.dataInputOutputsField = value;
            }
        }

        /// <uwagi/>
        public DataStoreReferences DataStoreReferences
        {
            get
            {
                return this.dataStoreReferencesField;
            }
            set
            {
                this.dataStoreReferencesField = value;
            }
        }

        /// <uwagi/>
        public Transitions Transitions
        {
            get
            {
                return this.transitionsField;
            }
            set
            {
                this.transitionsField = value;
            }
        }

        /// <uwagi/>
        public DataAssociations DataAssociations
        {
            get
            {
                return this.dataAssociationsField;
            }
            set
            {
                this.dataAssociationsField = value;
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
        public Assignments Assignments
        {
            get
            {
                return this.assignmentsField;
            }
            set
            {
                this.assignmentsField = value;
            }
        }

        /// <uwagi/>
        public PartnerLinks PartnerLinks
        {
            get
            {
                return this.partnerLinksField;
            }
            set
            {
                this.partnerLinksField = value;
            }
        }

        /// <uwagi/>
        public Object Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Extensions", typeof(object))]
        public object[] Items1
        {
            get
            {
                return this.items1Field;
            }
            set
            {
                this.items1Field = value;
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
        [System.ComponentModel.DefaultValueAttribute(ProcessTypeAccessLevel.PUBLIC)]
        public ProcessTypeAccessLevel AccessLevel
        {
            get
            {
                return this.accessLevelField;
            }
            set
            {
                this.accessLevelField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute("ProcessType")]
        [System.ComponentModel.DefaultValueAttribute(ProcessTypeProcessType.None)]
        public ProcessTypeProcessType ProcessType1
        {
            get
            {
                return this.processType1Field;
            }
            set
            {
                this.processType1Field = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ProcessTypeStatus.None)]
        public ProcessTypeStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool SuppressJoinFailure
        {
            get
            {
                return this.suppressJoinFailureField;
            }
            set
            {
                this.suppressJoinFailureField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool EnableInstanceCompensation
        {
            get
            {
                return this.enableInstanceCompensationField;
            }
            set
            {
                this.enableInstanceCompensationField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AdHoc
        {
            get
            {
                return this.adHocField;
            }
            set
            {
                this.adHocField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ProcessTypeAdHocOrdering.Parallel)]
        public ProcessTypeAdHocOrdering AdHocOrdering
        {
            get
            {
                return this.adHocOrderingField;
            }
            set
            {
                this.adHocOrderingField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AdHocCompletionCondition
        {
            get
            {
                return this.adHocCompletionConditionField;
            }
            set
            {
                this.adHocCompletionConditionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string DefaultStartActivitySetId
        {
            get
            {
                return this.defaultStartActivitySetIdField;
            }
            set
            {
                this.defaultStartActivitySetIdField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string DefaultStartActivityId
        {
            get
            {
                return this.defaultStartActivityIdField;
            }
            set
            {
                this.defaultStartActivityIdField = value;
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