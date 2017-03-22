using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BPMNEditor.ViewModels;
using QuickGraph;
using QuickGraph.Algorithms;


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

            if (hooks.Count == 0)
            {
                var hook = new Hook(startPoint, endPoint, null);
                hook.Orientation = stepDirection == Direction.Horizontal ? Orientation.Vertical : Orientation.Horizontal;
                hooks.Add(hook);
            }

            var graph = CreateGraph(_crossElements, hooks, startPoint, endPoint);



            Func<Edge<PointComparable>, double> pointDistances = PointDistances;
            var tryGetFunc = graph.ShortestPathsDijkstra(pointDistances, new PointComparable(endPoint));
            IEnumerable<Edge<PointComparable>> resultPoints = null;
            if (tryGetFunc(new PointComparable(endPoint), out resultPoints))
            {
                int fsadf = 0;
            }
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

        private double PointDistances(Edge<PointComparable> edge)
        {
            var source = edge.Source;
            var target = edge.Target;
            var vector = target.Point - source.Point;
            return vector.Length;
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

        private static List<Point> GetPoints(List<BaseElementViewModel> rects, List<Hook> hooks, Point startPoint, Point endPoint)
        {
            List<Point> resultPoints = new List<Point>() { startPoint, endPoint };
            foreach (BaseElementViewModel model in rects)
            {
                resultPoints.AddRange(GetPoints(model));
            }
            foreach (Hook hook in hooks)
            {
                Point hookPoint = hook.HookPoint;
                List<Point> tempPoints = new List<Point>(resultPoints);
                HashSet<double> addedPositions = new HashSet<double>();
                foreach (Point point in tempPoints)
                {
                    if (hook.Orientation == Orientation.Horizontal)
                    {
                        if (addedPositions.Contains(point.Y))
                        {
                            continue;
                        }
                        Point cross = new Point(hookPoint.X, point.Y);
                        addedPositions.Add(point.Y);
                        resultPoints.Add(cross);
                    }
                    else
                    {
                        if (addedPositions.Contains(point.X))
                        {
                            continue;
                        }
                        Point cross = new Point(point.X, hookPoint.Y);
                        addedPositions.Add(point.X);
                        resultPoints.Add(cross);
                    }
                }
            }
            return resultPoints;
        }

        private static List<Point> GetPoints(BaseElementViewModel rectViewModel)
        {
            double margin = 20;
            List<Point> points = new List<Point>();
            double left = double.PositiveInfinity;
            double right = double.NegativeInfinity;
            double top = double.PositiveInfinity; ;
            double bottom = double.NegativeInfinity; ;
            foreach (ConnectorViewModel connector in rectViewModel.Connectors)
            {
                Point connectorPoint = connector.Position;
                if (connectorPoint.X < left - margin)
                {
                    left = connectorPoint.X - margin;
                }
                else
                {
                    right = connectorPoint.X + margin;
                }
                if (connectorPoint.Y < top - margin)
                {
                    top = connectorPoint.Y - margin;
                }
                else
                {
                    bottom = connectorPoint.Y + margin;
                }
            }
            points.Add(new Point(left, top));
            points.Add(new Point((left + right) / 2, top));
            points.Add(new Point(left, bottom));
            points.Add(new Point((left + right) / 2, bottom));
            points.Add(new Point(right, top));
            points.Add(new Point(left, (top + bottom) / 2));
            points.Add(new Point(right, bottom));
            points.Add(new Point(right, (top + bottom) / 2));
            //Rect marginRect = GetRectWithMargin(rectViewModel, 15);
            //List<Point> points = GetPoints(marginRect);
            return points;
        }

        private static IVertexAndEdgeListGraph<PointComparable, Edge<PointComparable>> CreateGraph(List<BaseElementViewModel> rects, List<Hook> hooks, Point startPoint, Point endPoint)
        {
            return CreateGraph(GetPoints(rects, hooks, startPoint, endPoint), rects);
        }

        private static IVertexAndEdgeListGraph<PointComparable, Edge<PointComparable>> CreateGraph(List<Point> points, List<BaseElementViewModel> rects)
        {
            BidirectionalGraph<PointComparable, Edge<PointComparable>> graph = new BidirectionalGraph<PointComparable, Edge<PointComparable>>();
            List<Rect> rectItems = new List<Rect>();
            foreach (var baseElementViewModel in rects)
            {
                rectItems.Add(GetRectWithMargin(baseElementViewModel, 0));
            }
            //List<PointNeighbor> neighbors = new List<PointNeighbor>();
            for (int i = 0; i < points.Count; i++)
            {
                var startPoint = points[i];
                var pointNeighbor = new PointNeighbor();
                pointNeighbor.Point = startPoint;
                for (int j = 0; j < points.Count; j++)
                {
                    var endPoint = points[j];
                    if (endPoint == startPoint || IntersecrWithRects(startPoint, endPoint, rectItems))
                    {
                        continue;
                    }
                    if (endPoint.X == startPoint.X)
                    {
                        if (endPoint.Y < startPoint.Y)
                        {
                            if (pointNeighbor.North == null)
                            {
                                pointNeighbor.North = endPoint;
                            }
                            else if (Math.Abs(endPoint.Y - startPoint.Y) < Math.Abs(pointNeighbor.North.Value.Y - startPoint.Y))
                            {
                                pointNeighbor.North = endPoint;
                            }
                        }
                        else
                        {
                            if (pointNeighbor.South == null)
                            {
                                pointNeighbor.South = endPoint;
                            }
                            else if (Math.Abs(endPoint.Y - startPoint.Y) < Math.Abs(pointNeighbor.South.Value.Y - startPoint.Y))
                            {
                                pointNeighbor.South = endPoint;
                            }
                        }
                    }
                    else if (startPoint.Y == endPoint.Y)
                    {
                        if (endPoint.X < startPoint.X)
                        {
                            if (pointNeighbor.West == null)
                            {
                                pointNeighbor.West = endPoint;
                            }
                            else if (Math.Abs(endPoint.X - startPoint.X) < Math.Abs(pointNeighbor.West.Value.X - startPoint.X))
                            {
                                pointNeighbor.West = endPoint;
                            }
                        }
                        else
                        {
                            if (pointNeighbor.East == null)
                            {
                                pointNeighbor.East = endPoint;
                            }
                            else if (Math.Abs(endPoint.X - startPoint.X) < Math.Abs(pointNeighbor.East.Value.X - startPoint.X))
                            {
                                pointNeighbor.East = endPoint;
                            }
                        }
                    }
                }
                AddPointsNeighbor(pointNeighbor, graph);
            }
            return graph;
        }

        private static bool IntersecrWithRects(Point startPoint, Point endPoint, IEnumerable<Rect> rects)
        {
            foreach (Rect rect in rects)
            {
                if (IntersectsWithRect(startPoint, endPoint, rect))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IntersectsWithRect(Point startPoint, Point endPoint, Rect rect)
        {
            Rect line = new Rect(startPoint, endPoint);
            return rect.IntersectsWith(line);
        }

        private static void AddPointsNeighbor(PointNeighbor points, BidirectionalGraph<PointComparable, Edge<PointComparable>> graph)
        {
            graph.AddVertex(new PointComparable(points.Point));
            if (points.East != null)
            {
                graph.AddVertex(new PointComparable(points.East.Value));
                Edge<PointComparable> graphEdge = new Edge<PointComparable>(new PointComparable(points.Point), new PointComparable(points.East.Value));
                //Edge<PointComparable> graphEdgerev = new Edge<PointComparable>(new PointComparable(points.East.Value), new PointComparable(points.Point));
                graph.AddEdge(graphEdge);
                //graph.AddEdge(graphEdgerev);
            }
            if (points.North != null)
            {
                graph.AddVertex(new PointComparable(points.North.Value));
                Edge<PointComparable> graphEdge = new Edge<PointComparable>(new PointComparable(points.Point), new PointComparable(points.North.Value));
                graph.AddEdge(graphEdge);
            }
            if (points.West != null)
            {
                graph.AddVertex(new PointComparable(points.West.Value));
                Edge<PointComparable> graphEdge = new Edge<PointComparable>(new PointComparable(points.Point), new PointComparable(points.West.Value));
                graph.AddEdge(graphEdge);
            }
            if (points.South != null)
            {
                graph.AddVertex(new PointComparable(points.South.Value));
                Edge<PointComparable> graphEdge = new Edge<PointComparable>(new PointComparable(points.Point), new PointComparable(points.South.Value));
                graph.AddEdge(graphEdge);
            }
        }


        private static Rect GetRectWithMargin(BaseElementViewModel rectViewModel, double margin)
        {
            Point topLeft = new Point(rectViewModel.Left - margin / 2, rectViewModel.Top - margin / 2);
            Size size = new Size(rectViewModel.Width + margin / 2, rectViewModel.Height + margin / 2);
            return new Rect(topLeft, size);
        }

        private static List<Point> GetPoints(Rect rect)
        {
            List<Point> pointList = new List<Point>
            {
                rect.TopLeft,
                GetMiddlePoint(rect.TopLeft, rect.TopRight),
                rect.TopRight,
                GetMiddlePoint(rect.TopRight, rect.BottomRight),
                rect.BottomRight,
                GetMiddlePoint(rect.BottomRight, rect.BottomLeft),
                rect.BottomLeft,
                GetMiddlePoint(rect.BottomLeft, rect.TopLeft)
            };
            return pointList;
        }

        private static Point GetMiddlePoint(Point a, Point b)
        {
            var vector = new Vector(b.X, b.Y);
            var sum = a + vector;
            return new Point(sum.X / 2, sum.Y / 2);
        }

        private class PointNeighbor
        {
            public Point Point { get; set; }
            public Point? North { get; set; }
            public Point? East { get; set; }
            public Point? South { get; set; }
            public Point? West { get; set; }
        }

        public class PointComparable : IComparable
        {
            public Point Point { get; }

            public PointComparable(Point point)
            {
                Point = point;
            }

            public int CompareTo(object obj)
            {
                PointComparable comparable = obj as PointComparable;
                if (comparable != null)
                {
                    if (comparable.Point.Equals(Point))
                    {
                        return 0;
                    }
                }
                return -1;
            }

            public override bool Equals(object obj)
            {
                PointComparable comparable = obj as PointComparable;
                if (comparable != null)
                {
                    return comparable.Point.Equals(Point);
                }
                return false;
            }

            public override int GetHashCode()
            {
                return Point.GetHashCode();
            }

            public override string ToString()
            {
                return Point.ToString();
            }
        }
    }
}
