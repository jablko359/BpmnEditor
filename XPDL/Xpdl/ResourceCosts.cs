namespace XPDL.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class ResourceCosts
    {

        private string resourceCostNameField;

        private decimal resourceCostField;

        private ResourceCostsCostUnitOfTime costUnitOfTimeField;

        /// <uwagi/>
        public string ResourceCostName
        {
            get
            {
                return this.resourceCostNameField;
            }
            set
            {
                this.resourceCostNameField = value;
            }
        }

        /// <uwagi/>
        public decimal ResourceCost
        {
            get
            {
                return this.resourceCostField;
            }
            set
            {
                this.resourceCostField = value;
            }
        }

        /// <uwagi/>
        public ResourceCostsCostUnitOfTime CostUnitOfTime
        {
            get
            {
                return this.costUnitOfTimeField;
            }
            set
            {
                this.costUnitOfTimeField = value;
            }
        }
    }
}