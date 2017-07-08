using System.Reflection;
using System.Text;
using XPDL.Xpdl;

namespace BPMNCore
{
    public static class VisualElementTools
    {
        public static void SetVisualElementInfo(NodeGraphicsInfos infos, VisualElement element)
        {
            NodeGraphicsInfo info = null;
            foreach (var nodeGraphicsInfo in infos.NodeGraphicsInfo)
            {
                info = nodeGraphicsInfo;
                if (nodeGraphicsInfo.ToolId.StartsWith("BPMEditor"))
                {
                    break;
                }
            }
            if (info != null)
            {
                if (info.HeightSpecified)
                {
                    element.Height = info.Height;
                }
                if (info.WidthSpecified)
                {
                    element.Width = info.Width;
                }
                if (info.Coordinates != null)
                {
                    if (info.Coordinates.XCoordinateSpecified)
                    {
                        element.X = info.Coordinates.XCoordinate;
                    }
                    if (info.Coordinates.YCoordinateSpecified)
                    {
                        element.Y = info.Coordinates.YCoordinate;
                    }
                }
            }

        }

        public static string GetToolId(VisualElement element)
        {
            StringBuilder toolIdBuilder = new StringBuilder("BPMNEditor");
            var attr = element.GetType().GetCustomAttribute<ActivityMapperAttribute>();
            if (attr != null)
            {
                string name = attr.Name;
                toolIdBuilder.AppendFormat("(\"{0}\")", name);
            }
            return toolIdBuilder.ToString();
        }
    }
}
