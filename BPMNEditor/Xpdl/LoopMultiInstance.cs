namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class LoopMultiInstance
    {

        private ExpressionType mI_ConditionField;

        private ExpressionType complexMI_FlowConditionField;

        private System.Xml.XmlElement[] anyField;

        private string mI_Condition1Field;

        private string loopCounterField;

        private LoopMultiInstanceMI_Ordering mI_OrderingField;

        private LoopMultiInstanceMI_FlowCondition mI_FlowConditionField;

        private string complexMI_FlowCondition1Field;

        private System.Xml.XmlAttribute[] anyAttrField;

        public LoopMultiInstance()
        {
            this.mI_OrderingField = LoopMultiInstanceMI_Ordering.Parallel;
            this.mI_FlowConditionField = LoopMultiInstanceMI_FlowCondition.All;
        }

        /// <uwagi/>
        public ExpressionType MI_Condition
        {
            get
            {
                return this.mI_ConditionField;
            }
            set
            {
                this.mI_ConditionField = value;
            }
        }

        /// <uwagi/>
        public ExpressionType ComplexMI_FlowCondition
        {
            get
            {
                return this.complexMI_FlowConditionField;
            }
            set
            {
                this.complexMI_FlowConditionField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute("MI_Condition")]
        public string MI_Condition1
        {
            get
            {
                return this.mI_Condition1Field;
            }
            set
            {
                this.mI_Condition1Field = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(LoopMultiInstanceMI_Ordering.Parallel)]
        public LoopMultiInstanceMI_Ordering MI_Ordering
        {
            get
            {
                return this.mI_OrderingField;
            }
            set
            {
                this.mI_OrderingField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(LoopMultiInstanceMI_FlowCondition.All)]
        public LoopMultiInstanceMI_FlowCondition MI_FlowCondition
        {
            get
            {
                return this.mI_FlowConditionField;
            }
            set
            {
                this.mI_FlowConditionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute("ComplexMI_FlowCondition")]
        public string ComplexMI_FlowCondition1
        {
            get
            {
                return this.complexMI_FlowCondition1Field;
            }
            set
            {
                this.complexMI_FlowCondition1Field = value;
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