namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class TimeEstimation
    {

        private string waitingTimeField;

        private string workingTimeField;

        private string durationField;

        /// <uwagi/>
        public string WaitingTime
        {
            get
            {
                return this.waitingTimeField;
            }
            set
            {
                this.waitingTimeField = value;
            }
        }

        /// <uwagi/>
        public string WorkingTime
        {
            get
            {
                return this.workingTimeField;
            }
            set
            {
                this.workingTimeField = value;
            }
        }

        /// <uwagi/>
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }
}