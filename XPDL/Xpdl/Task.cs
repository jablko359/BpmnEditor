namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Task
    {

        private object itemField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("TaskApplication", typeof(TaskApplication))]
        [System.Xml.Serialization.XmlElementAttribute("TaskBusinessRule", typeof(TaskBusinessRule))]
        [System.Xml.Serialization.XmlElementAttribute("TaskManual", typeof(TaskManual))]
        [System.Xml.Serialization.XmlElementAttribute("TaskReceive", typeof(TaskReceive))]
        [System.Xml.Serialization.XmlElementAttribute("TaskReference", typeof(TaskReference))]
        [System.Xml.Serialization.XmlElementAttribute("TaskScript", typeof(TaskScript))]
        [System.Xml.Serialization.XmlElementAttribute("TaskSend", typeof(TaskSend))]
        [System.Xml.Serialization.XmlElementAttribute("TaskService", typeof(TaskService))]
        [System.Xml.Serialization.XmlElementAttribute("TaskUser", typeof(TaskUser))]
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