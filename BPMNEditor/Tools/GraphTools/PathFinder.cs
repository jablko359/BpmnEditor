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
        private List<BaseElementViewModel> _crossElements = new List<BaseElementViewModel>();

        public PathFinder(BaseElementViewModel startItem, BaseElementViewModel endItem)
        {
            _crossElements.Add(startItem);
            _crossElements.Add(endItem);
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
                    Point newPoint = CalculateNextPoint(currentPoint, pathEnd, stepDirection);
                    //CrossHit hit = ObjectHitTest(currentPoint, newPoint);
                    //if (hit != null)
                    //{
                    //    points.AddRange(hit.CreatePoints());
                    //    currentPoint = points.Last();
                    //    stepDirection = GetOther(stepDirection);
                    //}
                    //else
                    //{
                    currentPoint = newPoint;
                    stepDirection = GetOther(stepDirection);
                    if (i < hooks.Count && currentPoint.Equals(hooks[i].HookPoint))
                    {
                        //TODO modify this condition
                        continue;
                    }
                    else
                    {
                        points.Add(currentPoint);
                    }
                    //}



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

        private Point CalculateNextPoint(Point previousPoint, Point destinationPoint, Direction requiredDirection)
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

        private Point CalculateArrowPoint(Point endPoint, Placemement endPlacemement)
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

        private CrossHit ObjectHitTest(Point previous, Point next)
        {
            //  Vector moveVector = new Vector(next.X, next.Y);
            Rect lineRect = new Rect(previous, next);
            CrossHit currentHit = new NullHit();
            foreach (BaseElementViewModel crossElement in _crossElements)
            {
                Rect rectElement = GetObjectRect(crossElement);
                if (lineRect.IntersectsWith(rectElement))
                {
                    Orientation lineOrientation = previous.X == next.X ? Orientation.Vertical : Orientation.Horizontal;
                    var hit = new CrossHit(rectElement, next, previous, lineOrientation);
                    if (hit.GetDistance(previous) < currentHit.GetDistance(previous))
                    {
                        currentHit = hit;
                    }
                }
            }
            return currentHit.GetType() == typeof(NullHit) ? null : currentHit;
        }



        private Rect GetObjectRect(BaseElementViewModel model)
        {
            Point leftTopPoint = new Point(model.Left, model.Top);
            Size itemSize = new Size(model.Width, model.Height);
            Rect result = new Rect(leftTopPoint, itemSize);
            return result;
        }

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

        #region Direction

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

        #endregion

        private class CrossHit
        {
            public Orientation Orientation { get; }
            public Rect ObjectRect { get; }
            public Point EndPoint { get; }
            public Point StartPoint { get; }

            public CrossHit(Rect objecRect, Point endPoint, Point startPoint, Orientation orientation)
            {
                Orientation = orientation;
                ObjectRect = objecRect;
                EndPoint = endPoint;
                StartPoint = startPoint;
            }

            public virtual double GetDistance(Point startPoint)
            {
                Point centerPoint = new Point(ObjectRect.X + ObjectRect.Width / 2, ObjectRect.Y + ObjectRect.Height / 2);
                return Math.Sqrt(Math.Pow(centerPoint.X - startPoint.X, 2) + Math.Pow(centerPoint.Y - startPoint.Y, 2));
            }

            public List<Point> CreatePoints()
            {
                List<Point> resultPoints;
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        resultPoints = CreateHorizontalPoints();
                        break;
                    case Orientation.Vertical:
                        resultPoints = CreateVerticalPoints();
                        break;
                    default:
                        throw new ArgumentException("Unknown orientation");
                }
                return resultPoints;
            }

            private List<Point> CreateVerticalPoints()
            {

                List<Point> resultPoints = new List<Point>
                {
                    new Point(ObjectRect.X - ArrowMargin, StartPoint.Y),
                    new Point(ObjectRect.X - ArrowMargin, EndPoint.Y)
                };
                return resultPoints;
            }

            private List<Point> CreateHorizontalPoints()
            {
                List<Point> resultPoints = new List<Point>
                {
                    new Point(StartPoint.X, ObjectRect.Y - ArrowMargin),
                    new Point(EndPoint.X, ObjectRect.Y - ArrowMargin)
                };
                return resultPoints;
            }
        }

        private class NullHit : CrossHit
        {
            public NullHit() : base(new Rect(), new Point(), new Point(), Orientation.Horizontal)
            {
            }

            public override double GetDistance(Point startPoint)
            {
                return double.MaxValue;
            }
        }
    }
}
