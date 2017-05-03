using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public abstract class BaseActivityFactory : IActivityFactory
    {
        public Activity CreateActivity(IBaseElement baseElement)
        {
            Activity result = new Activity();
            result.Description = new Description();
            result.Documentation = new Documentation();
            IdElement idElement = baseElement as IdElement;
            if (idElement != null)
            {
                result.Id = idElement.GetId();
            }
            VisualElement visualElement = baseElement as VisualElement;
            if (visualElement != null)
            {
                result.NodeGraphicsInfos = new NodeGraphicsInfos();
                result.NodeGraphicsInfos.NodeGraphicsInfo = new NodeGraphicsInfo[1];
                NodeGraphicsInfo info = new NodeGraphicsInfo();
                info.SetSize(visualElement);
                result.NodeGraphicsInfos.NodeGraphicsInfo[0] = info;
            }
            ProcessActivity(result, baseElement);
            return result;
        }

        protected T GetType<T>(IBaseElement element) where T : class, IBaseElement
        {
            T result = element as T;
            if (result == null)
            {
                throw new ArgumentException(string.Format("EventActivityFactory exception. Expected {0}, provided {1}", typeof(T), element.GetType()));
            }
            return result;
        }

        public abstract void ProcessActivity(Activity activity, IBaseElement baseElement);
    }
}
