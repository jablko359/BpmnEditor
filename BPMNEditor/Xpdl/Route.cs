namespace BPMNEditor.Xpdl
{
    /// <uwagi/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.wfmc.org/2009/XPDL2.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.wfmc.org/2009/XPDL2.2", IsNullable = false)]
    public partial class Route
    {

        private System.Xml.XmlElement[] anyField;

        private RouteGatewayType gatewayTypeField;

        private RouteXORType xORTypeField;

        private RouteExclusiveType exclusiveTypeField;

        private bool instantiateField;

        private bool parallelEventBasedField;

        private bool markerVisibleField;

        private string incomingConditionField;

        private string outgoingConditionField;

        private RouteGatewayDirection gatewayDirectionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public Route()
        {
            this.gatewayTypeField = RouteGatewayType.Exclusive;
            this.xORTypeField = RouteXORType.Data;
            this.exclusiveTypeField = RouteExclusiveType.Data;
            this.instantiateField = false;
            this.parallelEventBasedField = false;
            this.markerVisibleField = false;
            this.gatewayDirectionField = RouteGatewayDirection.Unspecified;
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
        [System.ComponentModel.DefaultValueAttribute(RouteGatewayType.Exclusive)]
        public RouteGatewayType GatewayType
        {
            get
            {
                return this.gatewayTypeField;
            }
            set
            {
                this.gatewayTypeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(RouteXORType.Data)]
        public RouteXORType XORType
        {
            get
            {
                return this.xORTypeField;
            }
            set
            {
                this.xORTypeField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(RouteExclusiveType.Data)]
        public RouteExclusiveType ExclusiveType
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
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Instantiate
        {
            get
            {
                return this.instantiateField;
            }
            set
            {
                this.instantiateField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ParallelEventBased
        {
            get
            {
                return this.parallelEventBasedField;
            }
            set
            {
                this.parallelEventBasedField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool MarkerVisible
        {
            get
            {
                return this.markerVisibleField;
            }
            set
            {
                this.markerVisibleField = value;
            }
        }

        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IncomingCondition
        {
            get
            {
                return this.incomingConditionField;
            }
            set
            {
                this.incomingConditionField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(RouteGatewayDirection.Unspecified)]
        public RouteGatewayDirection GatewayDirection
        {
            get
            {
                return this.gatewayDirectionField;
            }
            set
            {
                this.gatewayDirectionField = value;
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