namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2002/XPDL1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2002/XPDL1.0", IsNullable = false)]
    public partial class TransitionRestrictions
    {

        private TransitionRestriction[] transitionRestrictionField;

        /// <uwagi/>
        [System.Xml.Serialization.XmlElementAttribute("TransitionRestriction")]
        public TransitionRestriction[] TransitionRestriction
        {
            get
            {
                return this.transitionRestrictionField;
            }
            set
            {
                this.transitionRestrictionField = value;
            }
        }
    }
}