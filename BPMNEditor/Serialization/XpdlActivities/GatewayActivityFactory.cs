using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public class GatewayActivityFactory : BaseActivityFactory
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
    }
}
