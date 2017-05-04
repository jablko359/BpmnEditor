using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization
{
    public static class XpdlExtensions
    {
        public static void SetSize(this NodeGraphicsInfo info, VisualElement element)
        {
            info.Height = element.Height;
            info.HeightSpecified = true;
            info.Width = element.Width;
            info.WidthSpecified = true;
            Coordinates coordinates = new Coordinates
            {
                XCoordinate = element.X,
                XCoordinateSpecified = true,
                YCoordinate = element.Y,
                YCoordinateSpecified = true
            };
            info.Coordinates = coordinates;
        }
    }
}