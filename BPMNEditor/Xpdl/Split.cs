namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Split
    {

        private TransitionRefs transitionRefsField;

        private System.Xml.XmlElement[] anyField;

        private SplitType typeField;

        private bool typeFieldSpecified;

        private SplitExclusiveType exclusiveTypeField;

        private string outgoingConditionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public Split()
        {
            this.exclusiveTypeField = SplitExclusiveType.Data;
        }

        /// <uwagi/>
        public TransitionRefs TransitionRefs
        {
            get
            {
                return this.transitionRefsField;
            }
            set
            {
                this.transitionRefsField = value;
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
        public SplitType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(SplitExclusiveType.Data)]
        public SplitExclusiveType ExclusiveType
        {
            get
            {
                return this.exclusiveTypeField;
            }
            set
            {
                this.exclusiveTypeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OutgoingCondition
        {
            get
            {
                return this.outgoingConditionField;
            }
            set
            {
                this.outgoingConditionField = value;
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