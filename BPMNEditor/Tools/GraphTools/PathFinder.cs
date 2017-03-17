using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Tools.GraphTools
{
    public class PathFinder
    {
        private DocumentViewModel _documetData;

        public PathFinder(DocumentViewModel documentData)
        {
            _documetData = documentData;
        }

        public IEnumerable<Point> CalculatePath(Point startPoint, Point endPoint, Placemement startPlacemement, Placemement endPlacemement)
        {
            List<Point> points = new List<Point>();
            double horizontalBreak = (startPoint.X + endPoint.X) / 2;
            double verticalBreak = (startPoint.Y + endPoint.Y) / 2;
            Point firtsBreakPoint = new Point();
            Point secondBreakPoint = new Point();
            ConnectionType type = GetConnectionType(startPlacemement, endPlacemement);
            switch (type)
            {
                case ConnectionType.Horizontal:
                    firtsBreakPoint.X = horizontalBreak;
                    firtsBreakPoint.Y = startPoint.Y;
                    secondBreakPoint.X = horizontalBreak;
                    secondBreakPoint.Y = endPoint.Y;
                    break;
                case ConnectionType.Vertical:
                    firtsBreakPoint.X = startPoint.X;
                    firtsBreakPoint.Y = verticalBreak;
                    secondBreakPoint.X = endPoint.X;
                    secondBreakPoint.Y = verticalBreak;
                    break;
                case ConnectionType.Mixed:
                    firtsBreakPoint.X = startPoint.X;
                    firtsBreakPoint.Y = startPoint.Y;
                    secondBreakPoint.X = startPoint.X;
                    secondBreakPoint.Y = endPoint.Y;
                    break;
            }
            points.Add(firtsBreakPoint);
            points.Add(secondBreakPoint);
            return points;
        }

        private static ConnectionType GetConnectionType(Placemement startPlacemement, Placemement endPlacemement)
        {
            ConnectionType result = ConnectionType.Horizontal;
            if (GetPlacementSubType(startPlacemement) != GetPlacementSubType(endPlacemement))
            {
                result = ConnectionType.Mixed;
            }
            else if (startPlacemement == Placemement.Left || startPlacemement == Placemement.Right)
            {
                result = ConnectionType.Horizontal;
            }
            else
            {
                result = ConnectionType.Vertical;
            }
            return result;
        }

        private static ConnectionType GetPlacementSubType(Placemement placement)
        {
            return (placement == Placemement.Left || placement == Placemement.Right) ? ConnectionType.Horizontal : ConnectionType.Vertical;
        }

        private enum ConnectionType
        {
            Horizontal, Vertical, Mixed
        }
    }
}
