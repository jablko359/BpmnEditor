namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ActivitySet
    {

        private Activities activitiesField;

        private DataObjects dataObjectsField;

        private DataStoreReferences dataStoreReferencesField;

        private Transitions transitionsField;

        private DataAssociations dataAssociationsField;

        private Object objectField;

        private Associations associationsField;

        private Artifacts artifactsField;

        private System.Xml.XmlElement[] anyField;

        private string idField;

        private string nameField;

        private bool adHocField;

        private ActivitySetAdHocOrdering adHocOrderingField;

        private string adHocCompletionConditionField;

        private string defaultStartActivityIdField;

        private bool triggeredByEventField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public ActivitySet()
        {
            this.adHocField = false;
            this.adHocOrderingField = ActivitySetAdHocOrdering.Parallel;
            this.triggeredByEventField = false;
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
        [System.ComponentModel.DefaultValueAttribute(ActivitySetAdHocOrdering.Parallel)]
        public ActivitySetAdHocOrdering AdHocOrdering
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool TriggeredByEvent
        {
            get
            {
                return this.triggeredByEventField;
            }
            set
            {
                this.triggeredByEventField = value;
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