﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Models.Elements;
using XPDL.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public class GatewayActivityMapper : BaseActivityMapper
    {
        public override void ProcessActivity(Activity activity, IBaseElement baseElement)
        {
            GatewayElement element = GetType<GatewayElement>(baseElement);
            Route route = new Route();
            switch (element.Type)
            {
                case GatewayType.Xor:
                    route.GatewayType = RouteGatewayType.XOR;
                    break;
                case GatewayType.Or:
                    route.GatewayType = RouteGatewayType.OR;
                    break;
                case GatewayType.EventBased:
                    route.ExclusiveType = RouteExclusiveType.Event;
                    break;
            }
            activity.Item = route;
        }

        protected override IBaseElement CreateElement(object xpdlItem)
        {
            Route route = GetXpdlType<Route>(xpdlItem);
            GatewayElement element = new GatewayElement();
            if (route.GatewayType == RouteGatewayType.XOR)
            {
                element.Type = GatewayType.Xor;
            }
            else if (route.GatewayType == RouteGatewayType.OR)
            {
                element.Type = GatewayType.Or;
            }
            else if (route.ExclusiveType == RouteExclusiveType.Event)
            {
                element.Type = GatewayType.EventBased;
            }
            return element;
        }
    }
}
