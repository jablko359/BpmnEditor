namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class Activity
    {

        private string descriptionField;

        private string limitField;

        private object itemField;

        private string performerField;

        private StartMode startModeField;

        private FinishMode finishModeField;

        private string priorityField;

        private Deadline[] deadlineField;

        private SimulationInformation simulationInformationField;

        private string iconField;

        private string documentationField;

        private TransitionRestriction[] transitionRestrictionsField;

        private ExtendedAttribute[] extendedAttributesField;

        private string idField;

        private string nameField;

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
        public string Limit
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
        public string Performer
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
        public StartMode StartMode
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
        public FinishMode FinishMode
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
        public string Priority
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
        public Deadline[] Deadline
        {
            get
            {
                return this.deadlineField;
            }
            set
            {
                this.deadlineField = value;
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
        public string Icon
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
        [System.Xml.Serialization.XmlArrayItemAttribute("TransitionRestriction", IsNullable = false)]
        public TransitionRestriction[] TransitionRestrictions
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