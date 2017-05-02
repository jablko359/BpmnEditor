namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Activity
    {

        private Description descriptionField;

        private Limit limitField;

        private object itemField;

        private Transaction transactionField;

        private Performers performersField;

        private Performer performerField;

        private Priority priorityField;

        private Deadline[] itemsField;

        private SimulationInformation simulationInformationField;

        private Icon iconField;

        private Documentation documentationField;

        private TransitionRestrictions transitionRestrictionsField;

        private ExtendedAttribute[] extendedAttributesField;

        private DataFields dataFieldsField;

        private FormalParameters formalParametersField;

        private ActualParameters actualParametersField;

        private InputSets inputSetsField;

        private OutputSets outputSetsField;

        private IORules iORulesField;

        private Loop loopField;

        private Assignments assignmentsField;

        private Object objectField;

        private NodeGraphicsInfos nodeGraphicsInfosField;

        private object[] items1Field;

        private string idField;

        private bool isForCompensationField;

        private string nameField;

        private bool startActivityField;

        private bool startActivityFieldSpecified;

        private ActivityStatus statusField;

        private ActivityStartMode startModeField;

        private bool startModeFieldSpecified;

        private ActivityFinishMode finishModeField;

        private bool finishModeFieldSpecified;

        private string startQuantityField;

        private string completionQuantityField;

        private bool isATransactionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public Activity()
        {
            this.isForCompensationField = false;
            this.statusField = ActivityStatus.None;
            this.startQuantityField = "1";
            this.completionQuantityField = "1";
            this.isATransactionField = false;
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
        public Limit Limit
        {
            get
            {
                return this.limitField;
            }
            set
            {
                this.limitField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("BlockActivity", typeof(BlockActivity))]
        [System.Xml.Serialization.XmlElementAttribute("EventElement", typeof(Event))]
        [System.Xml.Serialization.XmlElementAttribute("Implementation", typeof(Implementation))]
        [System.Xml.Serialization.XmlElementAttribute("Route", typeof(Route))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <uwagi/>
        public Transaction Transaction
        {
            get
            {
                return this.transactionField;
            }
            set
            {
                this.transactionField = value;
            }
        }

        /// <uwagi/>
        public Performers Performers
        {
            get
            {
                return this.performersField;
            }
            set
            {
                this.performersField = value;
            }
        }

        /// <uwagi/>
        public Performer Performer
        {
            get
            {
                return this.performerField;
            }
            set
            {
                this.performerField = value;
            }
        }

        /// <uwagi/>
        public Priority Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("Deadline")]
        public Deadline[] Items
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
        public SimulationInformation SimulationInformation
        {
            get
            {
                return this.simulationInformationField;
            }
            set
            {
                this.simulationInformationField = value;
            }
        }

        /// <uwagi/>
        public Icon Icon
        {
            get
            {
                return this.iconField;
            }
            set
            {
                this.iconField = value;
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
        public TransitionRestrictions TransitionRestrictions
        {
            get
            {
                return this.transitionRestrictionsField;
            }
            set
            {
                this.transitionRestrictionsField = value;
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
        public ActualParameters ActualParameters
        {
            get
            {
                return this.actualParametersField;
            }
            set
            {
                this.actualParametersField = value;
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
        public IORules IORules
        {
            get
            {
                return this.iORulesField;
            }
            set
            {
                this.iORulesField = value;
            }
        }

        /// <uwagi/>
        public Loop Loop
        {
            get
            {
                return this.loopField;
            }
            set
            {
                this.loopField = value;
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
        public NodeGraphicsInfos NodeGraphicsInfos
        {
            get
            {
                return this.nodeGraphicsInfosField;
            }
            set
            {
                this.nodeGraphicsInfosField = value;
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
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsForCompensation
        {
            get
            {
                return this.isForCompensationField;
            }
            set
            {
                this.isForCompensationField = value;
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
        public bool StartActivity
        {
            get
            {
                return this.startActivityField;
            }
            set
            {
                this.startActivityField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartActivitySpecified
        {
            get
            {
                return this.startActivityFieldSpecified;
            }
            set
            {
                this.startActivityFieldSpecified = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ActivityStatus.None)]
        public ActivityStatus Status
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
        public ActivityStartMode StartMode
        {
            get
            {
                return this.startModeField;
            }
            set
            {
                this.startModeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartModeSpecified
        {
            get
            {
                return this.startModeFieldSpecified;
            }
            set
            {
                this.startModeFieldSpecified = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActivityFinishMode FinishMode
        {
            get
            {
                return this.finishModeField;
            }
            set
            {
                this.finishModeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FinishModeSpecified
        {
            get
            {
                return this.finishModeFieldSpecified;
            }
            set
            {
                this.finishModeFieldSpecified = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        [System.ComponentModel.DefaultValueAttribute("1")]
        public string StartQuantity
        {
            get
            {
                return this.startQuantityField;
            }
            set
            {
                this.startQuantityField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        [System.ComponentModel.DefaultValueAttribute("1")]
        public string CompletionQuantity
        {
            get
            {
                return this.completionQuantityField;
            }
            set
            {
                this.completionQuantityField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsATransaction
        {
            get
            {
                return this.isATransactionField;
            }
            set
            {
                this.isATransactionField = value;
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