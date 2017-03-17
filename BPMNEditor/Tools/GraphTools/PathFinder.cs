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
        private const double ArrowMargin = 20;
        private DocumentViewModel _documetData;

        public PathFinder(DocumentViewModel documentData)
        {
            _documetData = documentData;
        }

        public IEnumerable<Point> CalculatePath(Point startPoint, Point endPoint, Placemement startPlacemement, Placemement endPlacemement)
        {
            List<Point> points = new List<Point>();
            
            Point arrowPoint = CalculateArrowPoint(endPoint, endPlacemement);
            Direction stepDirection = GetRequireDirection(startPlacemement);
            Point currentPoint = CalculateNextPoint(startPoint, arrowPoint, stepDirection);
            points.Add(currentPoint);
            while (!currentPoint.Equals(arrowPoint))
            {
                stepDirection = GetOther(stepDirection);
                currentPoint = CalculateNextPoint(currentPoint, arrowPoint, stepDirection);
                points.Add(currentPoint);
            }
            return points;
        }

        private Point CalculateNextPoint(Point previousPoint, Point destinationPoint, Direction requiredDirection )
        {
            Point result = new Point();
            switch (requiredDirection)
            {
                case Direction.Vertical:
                    result.X = previousPoint.X;
                    result.Y = destinationPoint.Y;
                    break;
                case Direction.Horizontal:
                    result.X = destinationPoint.X;
                    result.Y = previousPoint.Y;
                    break;


            }
            return result;
        }

        public Point CalculateArrowPoint(Point endPoint, Placemement endPlacemement)
        {
            Point arrowPoint = new Point(endPoint.X, endPoint.Y);
            switch (endPlacemement)
            {
                case Placemement.Left:
                    arrowPoint.X -= ArrowMargin;
                    break;
                case Placemement.Bottom:
                    arrowPoint.Y += ArrowMargin;
                    break;
                case Placemement.Right:
                    arrowPoint.X += ArrowMargin;
                    break;
                case Placemement.Top:
                    arrowPoint.Y -= ArrowMargin;
                    break;
            }
            return arrowPoint;
        }

        //#region Path

        //private class Path
        //{
        //    public const double ArrowMargin = 10;
        //    public List<Point> Points { get; set; }
        //    public Point StartArrowPoint { get; set; }
        //}

        //#endregion


        #region ConnectionType
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
        #endregion

        private Direction GetRequireDirection(Placemement startPlacemement)
        {
            if (startPlacemement == Placemement.Left || startPlacemement == Placemement.Right)
            {
                return Direction.Horizontal;
            }
            else
            {
                return Direction.Vertical;
            }
        }

        private Direction GetOther(Direction direction)
        {
            return direction == Direction.Horizontal ? Direction.Vertical : Direction.Horizontal;
        }

        private enum Direction
        {
            None, Horizontal, Vertical
        }
    }
}
