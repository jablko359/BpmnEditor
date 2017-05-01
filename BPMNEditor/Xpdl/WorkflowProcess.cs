namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class WorkflowProcess
    {

        private ProcessHeader processHeaderField;

        private RedefinableHeader redefinableHeaderField;

        private FormalParameters formalParametersField;

        private DataField[] dataFieldsField;

        private Participant[] participantsField;

        private Application[] applicationsField;

        private ActivitySet[] activitySetsField;

        private Activity[] activitiesField;

        private Transition[] transitionsField;

        private ExtendedAttribute[] extendedAttributesField;

        private string idField;

        private string nameField;

        private WorkflowProcessAccessLevel accessLevelField;

        private bool accessLevelFieldSpecified;

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
        [System.Xml.Serialization.XmlArrayItemAttribute("ActivitySet", IsNullable = false)]
        public ActivitySet[] ActivitySets
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
        [System.Xml.Serialization.XmlArrayItemAttribute("Activity", IsNullable = false)]
        public Activity[] Activities
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
        [System.Xml.Serialization.XmlArrayItemAttribute("Transition", IsNullable = false)]
        public Transition[] Transitions
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

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public WorkflowProcessAccessLevel AccessLevel
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccessLevelSpecified
        {
            get
            {
                return this.accessLevelFieldSpecified;
            }
            set
            {
                this.accessLevelFieldSpecified = value;
            }
        }
    }
}