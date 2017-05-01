namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class ActivitySet
    {

        private Activity[] activitiesField;

        private Transition[] transitionsField;

        private string idField;

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
    }
}