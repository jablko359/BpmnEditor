namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class TaskBusinessRule
    {

        private TaskBusinessRuleBusinessRuleTaskImplementation businessRuleTaskImplementationField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public TaskBusinessRule()
        {
            this.businessRuleTaskImplementationField = TaskBusinessRuleBusinessRuleTaskImplementation.Other;
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(TaskBusinessRuleBusinessRuleTaskImplementation.Other)]
        public TaskBusinessRuleBusinessRuleTaskImplementation BusinessRuleTaskImplementation
        {
            get
            {
                return this.businessRuleTaskImplementationField;
            }
            set
            {
                this.businessRuleTaskImplementationField = value;
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