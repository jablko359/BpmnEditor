using System;
using XPDL.Xpdl;

namespace BPMNCore
{
    public abstract class BaseActivityMapper : IActivityFactory, IActivityMapper
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
                info.ToolId = VisualElementTools.GetToolId(visualElement);
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
                throw new ArgumentException(string.Format("BaseActivityMapper exception. Expected {0}, provided {1}", typeof(T), element.GetType()));
            }
            return result;
        }

        protected T GetXpdlType<T>(object xpdlItem) where T : class
        {
            T result = xpdlItem as T;
            if (result == null)
            {
                throw new ArgumentException(string.Format("BaseActivityMapper exception. Expected {0}, provided {1}", typeof(T), xpdlItem.GetType()));
            }
            return result;
        }

        public IBaseElement CreateElement(object xpdlItem, NodeGraphicsInfos graphicInfo)
        {
            IBaseElement baseElement = CreateElement(xpdlItem);
            if (graphicInfo != null)
            {
                VisualElement visualElement = baseElement as VisualElement;
                if (visualElement != null)
                {
                    VisualElementTools.SetVisualElementInfo(graphicInfo, visualElement);
                }
            }
            return baseElement;
        }

        protected abstract IBaseElement CreateElement(object xpdlItem);

        public abstract void ProcessActivity(Activity activity, IBaseElement baseElement);
    }
}
