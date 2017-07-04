namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class LoopStandard
    {

        private ExpressionType loopConditionField;

        private System.Xml.XmlElement[] anyField;

        private string loopCondition1Field;

        private string loopCounterField;

        private string loopMaximumField;

        private LoopStandardTestTime testTimeField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public LoopStandard()
        {
            this.testTimeField = LoopStandardTestTime.After;
        }

        /// <uwagi/>
        public ExpressionType LoopCondition
        {
            get
            {
                return this.loopConditionField;
            }
            set
            {
                this.loopConditionField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute("LoopCondition")]
        public string LoopCondition1
        {
            get
            {
                return this.loopCondition1Field;
            }
            set
            {
                this.loopCondition1Field = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string LoopCounter
        {
            get
            {
                return this.loopCounterField;
            }
            set
            {
                this.loopCounterField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string LoopMaximum
        {
            get
            {
                return this.loopMaximumField;
            }
            set
            {
                this.loopMaximumField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(LoopStandardTestTime.After)]
        public LoopStandardTestTime TestTime
        {
            get
            {
                return this.testTimeField;
            }
            set
            {
                this.testTimeField = value;
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