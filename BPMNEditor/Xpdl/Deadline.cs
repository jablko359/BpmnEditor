namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class Deadline
    {

        private object deadlineConditionField;

        private object exceptionNameField;

        private DeadlineExecution executionField;

        private bool executionFieldSpecified;

        /// <uwagi/>
        public object DeadlineCondition
        {
            get
            {
                return this.deadlineConditionField;
            }
            set
            {
                this.deadlineConditionField = value;
            }
        }

        /// <uwagi/>
        public object ExceptionName
        {
            get
            {
                return this.exceptionNameField;
            }
            set
            {
                this.exceptionNameField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public DeadlineExecution Execution
        {
            get
            {
                return this.executionField;
            }
            set
            {
                this.executionField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExecutionSpecified
        {
            get
            {
                return this.executionFieldSpecified;
            }
            set
            {
                this.executionFieldSpecified = value;
            }
        }
    }
}