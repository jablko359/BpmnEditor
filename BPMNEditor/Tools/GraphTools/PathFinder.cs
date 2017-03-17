using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        

        public IEnumerable<Point> CalculatePath(Point startPoint, Point endPoint, Placemement startPlacemement, 
            Placemement endPlacemement, List<Hook> hooks)
        {
            List<Point> points = new List<Point>();
            Point arrowPoint = CalculateArrowPoint(endPoint, endPlacemement);
            Direction stepDirection = GetRequireDirection(startPlacemement);
            Point currentPoint = startPoint;

            int i = 0;
            
            Point pathEnd = hooks.Count > 0 ? hooks[0].HookPoint : arrowPoint;
            do
            {
                while (!currentPoint.Equals(pathEnd))
                {

                    currentPoint = CalculateNextPoint(currentPoint, pathEnd, stepDirection);
                    stepDirection = GetOther(stepDirection);
                    if (i < hooks.Count && currentPoint.Equals(hooks[i].HookPoint))
                    {
                        continue;
                    }
                    else
                    {
                        points.Add(currentPoint);
                    }
                    
                }
                i++;
                if (i < hooks.Count)
                {
                    pathEnd = hooks[i].HookPoint;
                    stepDirection = hooks[i - 1].Orientation == Orientation.Horizontal
                        ? Direction.Vertical
                        : Direction.Horizontal;
                }
                else
                {
                    pathEnd = arrowPoint;
                    Hook last = hooks.LastOrDefault();
                    if (last != null)
                    {
                        stepDirection = last.Orientation == Orientation.Horizontal
                        ? Direction.Vertical
                        : Direction.Horizontal;
                    }
                }
                
            } while (i <= hooks.Count);
            
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

        private Placemement GetPlacement(Orientation orientation)
        {
            return orientation == Orientation.Horizontal ? Placemement.Left : Placemement.Top;
        }

        private enum Direction
        {
            None, Horizontal, Vertical
        }
    }
}
