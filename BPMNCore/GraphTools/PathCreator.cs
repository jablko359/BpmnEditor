using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BPMNCore.ViewModels;

namespace BPMNCore.GraphTools
{
    class PathCreator
    {
        private const int Margin = 40;

        internal static List<Point> GetConnectionLine(ConnectorBase source, ConnectorBase sink,
            bool showLastLine, List<Hook> userHooks)
        {
            List<Point> linePoints = new List<Point>();

            //ConnectorBase end = userHooks.Count > 0 ? userHooks[0].HookPoint : arrowPoint;

            return linePoints;
        }

        internal static List<Point> GetConnectionLine(ConnectorBase source, ConnectorBase sink, bool showLastLine)
        {
            List<Point> linePoints = new List<Point>();
            
            Rect rectSource = source.GetParentRectWithMargin(Margin);
            Rect rectSink = sink.GetParentRectWithMargin(Margin);

            Point startPoint = GetOffsetPoint(source, rectSource);
            Point endPoint = GetOffsetPoint(sink, rectSink);

            linePoints.Add(startPoint);
            Point currentPoint = startPoint;

            if (!rectSink.Contains(currentPoint) && !rectSource.Contains(endPoint))
            {
                while (true)
                {
                    #region source node

                    if (IsPointVisible(currentPoint, endPoint, new Rect[] { rectSource, rectSink }))
                    {
                        linePoints.Add(endPoint);
                        currentPoint = endPoint;
                        break;
                    }

                    Point neighbour = GetNearestVisibleNeighborSink(currentPoint, endPoint, sink, rectSource, rectSink);
                    if (!double.IsNaN(neighbour.X))
                    {
                        linePoints.Add(neighbour);
                        linePoints.Add(endPoint);
                        currentPoint = endPoint;
                        break;
                    }

                    if (currentPoint == startPoint)
                    {
                        bool flag;
                        Point n = GetNearestNeighborSource(source, endPoint, rectSource, rectSink, out flag);
                        linePoints.Add(n);
                        currentPoint = n;

                        if (!IsRectVisible(currentPoint, rectSink, new Rect[] { rectSource }))
                        {
                            Point n1, n2;
                            GetOppositeCorners(source.Placemement, rectSource, out n1, out n2);
                            if (flag)
                            {
                                linePoints.Add(n1);
                                currentPoint = n1;
                            }
                            else
                            {
                                linePoints.Add(n2);
                                currentPoint = n2;
                            }
                            if (!IsRectVisible(currentPoint, rectSink, new Rect[] { rectSource }))
                            {
                                if (flag)
                                {
                                    linePoints.Add(n2);
                                    currentPoint = n2;
                                }
                                else
                                {
                                    linePoints.Add(n1);
                                    currentPoint = n1;
                                }
                            }
                        }
                    }
                    #endregion

                    #region sink node

                    else // from here on we jump to the sink node
                    {
                        Point n1, n2; // neighbour corner
                        Point s1, s2; // opposite corner
                        GetNeighborCorners(sink.Placemement, rectSink, out s1, out s2);
                        GetOppositeCorners(sink.Placemement, rectSink, out n1, out n2);

                        bool n1Visible = IsPointVisible(currentPoint, n1, new Rect[] { rectSource, rectSink });
                        bool n2Visible = IsPointVisible(currentPoint, n2, new Rect[] { rectSource, rectSink });

                        if (n1Visible && n2Visible)
                        {
                            if (rectSource.Contains(n1))
                            {
                                linePoints.Add(n2);
                                if (rectSource.Contains(s2))
                                {
                                    linePoints.Add(n1);
                                    linePoints.Add(s1);
                                }
                                else
                                    linePoints.Add(s2);

                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }

                            if (rectSource.Contains(n2))
                            {
                                linePoints.Add(n1);
                                if (rectSource.Contains(s1))
                                {
                                    linePoints.Add(n2);
                                    linePoints.Add(s2);
                                }
                                else
                                    linePoints.Add(s1);

                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }

                            if ((Distance(n1, endPoint) <= Distance(n2, endPoint)))
                            {
                                linePoints.Add(n1);
                                if (rectSource.Contains(s1))
                                {
                                    linePoints.Add(n2);
                                    linePoints.Add(s2);
                                }
                                else
                                    linePoints.Add(s1);
                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }
                            else
                            {
                                linePoints.Add(n2);
                                if (rectSource.Contains(s2))
                                {
                                    linePoints.Add(n1);
                                    linePoints.Add(s1);
                                }
                                else
                                    linePoints.Add(s2);
                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }
                        }
                        else if (n1Visible)
                        {
                            linePoints.Add(n1);
                            if (rectSource.Contains(s1))
                            {
                                linePoints.Add(n2);
                                linePoints.Add(s2);
                            }
                            else
                                linePoints.Add(s1);
                            linePoints.Add(endPoint);
                            currentPoint = endPoint;
                            break;
                        }
                        else
                        {
                            linePoints.Add(n2);
                            if (rectSource.Contains(s2))
                            {
                                linePoints.Add(n1);
                                linePoints.Add(s1);
                            }
                            else
                                linePoints.Add(s2);
                            linePoints.Add(endPoint);
                            currentPoint = endPoint;
                            break;
                        }
                    }
                    #endregion
                }
            }
            else
            {
                linePoints.Add(endPoint);
            }

            linePoints = OptimizeLinePoints(linePoints, new Rect[] { rectSource, rectSink }, source.Placemement, sink.Placemement);

            CheckPathEnd(source, sink, showLastLine, linePoints);
            return linePoints;
        }

        internal static List<Point> GetConnectionLine(ConnectorViewModel source, Point sinkPoint, Placemement preferredOrientation)
        {
            List<Point> linePoints = new List<Point>();
            Rect rectSource = source.GetParentRectWithMargin(10);
            Point startPoint = GetOffsetPoint(source, rectSource);
            Point endPoint = sinkPoint;

            linePoints.Add(startPoint);
            Point currentPoint = startPoint;

            if (!rectSource.Contains(endPoint))
            {
                while (true)
                {
                    if (IsPointVisible(currentPoint, endPoint, new Rect[] { rectSource }))
                    {
                        linePoints.Add(endPoint);
                        break;
                    }

                    bool sideFlag;
                    Point n = GetNearestNeighborSource(source, endPoint, rectSource, out sideFlag);
                    linePoints.Add(n);
                    currentPoint = n;

                    if (IsPointVisible(currentPoint, endPoint, new Rect[] { rectSource }))
                    {
                        linePoints.Add(endPoint);
                        break;
                    }
                    else
                    {
                        Point n1, n2;
                        GetOppositeCorners(source.Placemement, rectSource, out n1, out n2);
                        if (sideFlag)
                            linePoints.Add(n1);
                        else
                            linePoints.Add(n2);

                        linePoints.Add(endPoint);
                        break;
                    }
                }
            }
            else
            {
                linePoints.Add(endPoint);
            }

            if (preferredOrientation != Placemement.None)
                linePoints = OptimizeLinePoints(linePoints, new Rect[] { rectSource }, source.Placemement, preferredOrientation);
            else
                linePoints = OptimizeLinePoints(linePoints, new Rect[] { rectSource }, source.Placemement, GetOpositeOrientation(source.Placemement));

            return linePoints;
        }

        private static List<Point> OptimizeLinePoints(List<Point> linePoints, Rect[] rectangles, Placemement sourceOrientation, Placemement sinkOrientation)
        {
            List<Point> points = new List<Point>();
            int cut = 0;

            for (int i = 0; i < linePoints.Count; i++)
            {
                if (i >= cut)
                {
                    for (int k = linePoints.Count - 1; k > i; k--)
                    {
                        if (IsPointVisible(linePoints[i], linePoints[k], rectangles))
                        {
                            cut = k;
                            break;
                        }
                    }
                    points.Add(linePoints[i]);
                }
            }

            #region Line
            for (int j = 0; j < points.Count - 1; j++)
            {
                if (points[j].X != points[j + 1].X && points[j].Y != points[j + 1].Y)
                {
                    Placemement orientationFrom;
                    Placemement orientationTo;

                    // orientation from point
                    if (j == 0)
                        orientationFrom = sourceOrientation;
                    else
                        orientationFrom = GetOrientation(points[j], points[j - 1]);

                    // orientation to pint 
                    if (j == points.Count - 2)
                        orientationTo = sinkOrientation;
                    else
                        orientationTo = GetOrientation(points[j + 1], points[j + 2]);


                    if ((orientationFrom == Placemement.Left || orientationFrom == Placemement.Right) &&
                        (orientationTo == Placemement.Left || orientationTo == Placemement.Right))
                    {
                        double centerX = Math.Min(points[j].X, points[j + 1].X) + Math.Abs(points[j].X - points[j + 1].X) / 2;
                        points.Insert(j + 1, new Point(centerX, points[j].Y));
                        points.Insert(j + 2, new Point(centerX, points[j + 2].Y));
                        if (points.Count - 1 > j + 3)
                            points.RemoveAt(j + 3);
                        return points;
                    }

                    if ((orientationFrom == Placemement.Top || orientationFrom == Placemement.Bottom) &&
                        (orientationTo == Placemement.Top || orientationTo == Placemement.Bottom))
                    {
                        double centerY = Math.Min(points[j].Y, points[j + 1].Y) + Math.Abs(points[j].Y - points[j + 1].Y) / 2;
                        points.Insert(j + 1, new Point(points[j].X, centerY));
                        points.Insert(j + 2, new Point(points[j + 2].X, centerY));
                        if (points.Count - 1 > j + 3)
                            points.RemoveAt(j + 3);
                        return points;
                    }

                    if ((orientationFrom == Placemement.Left || orientationFrom == Placemement.Right) &&
                        (orientationTo == Placemement.Top || orientationTo == Placemement.Bottom))
                    {
                        points.Insert(j + 1, new Point(points[j + 1].X, points[j].Y));
                        return points;
                    }

                    if ((orientationFrom == Placemement.Top || orientationFrom == Placemement.Bottom) &&
                        (orientationTo == Placemement.Left || orientationTo == Placemement.Right))
                    {
                        points.Insert(j + 1, new Point(points[j].X, points[j + 1].Y));
                        return points;
                    }
                }
            }
            #endregion

            return points;
        }

        private static Placemement GetOrientation(Point p1, Point p2)
        {
            if (p1.X == p2.X)
            {
                if (p1.Y >= p2.Y)
                    return Placemement.Bottom;
                else
                    return Placemement.Top;
            }
            else if (p1.Y == p2.Y)
            {
                if (p1.X >= p2.X)
                    return Placemement.Right;
                else
                    return Placemement.Left;
            }
            throw new Exception("Failed to retrieve orientation");
        }

        private static Orientation GetOrientation(Placemement sourceOrientation)
        {
            switch (sourceOrientation)
            {
                case Placemement.Left:
                    return Orientation.Horizontal;
                case Placemement.Top:
                    return Orientation.Vertical;
                case Placemement.Right:
                    return Orientation.Horizontal;
                case Placemement.Bottom:
                    return Orientation.Vertical;
                default:
                    throw new Exception("Unknown ConnectorOrientation");
            }
        }

        private static Point GetNearestNeighborSource(ConnectorBase source, Point endPoint, Rect rectSource, Rect rectSink, out bool flag)
        {
            Point n1, n2; // neighbors
            GetNeighborCorners(source.Placemement, rectSource, out n1, out n2);

            if (rectSink.Contains(n1))
            {
                flag = false;
                return n2;
            }

            if (rectSink.Contains(n2))
            {
                flag = true;
                return n1;
            }

            if ((Distance(n1, endPoint) <= Distance(n2, endPoint)))
            {
                flag = true;
                return n1;
            }
            else
            {
                flag = false;
                return n2;
            }
        }

        private static Point GetNearestNeighborSource(ConnectorViewModel source, Point endPoint, Rect rectSource, out bool flag)
        {
            Point n1, n2; // neighbors
            GetNeighborCorners(source.Placemement, rectSource, out n1, out n2);

            if ((Distance(n1, endPoint) <= Distance(n2, endPoint)))
            {
                flag = true;
                return n1;
            }
            else
            {
                flag = false;
                return n2;
            }
        }

        private static Point GetNearestVisibleNeighborSink(Point currentPoint, Point endPoint, ConnectorBase sink, Rect rectSource, Rect rectSink)
        {
            Point s1, s2; // neighbors on sink side
            GetNeighborCorners(sink.Placemement, rectSink, out s1, out s2);

            bool flag1 = IsPointVisible(currentPoint, s1, new Rect[] { rectSource, rectSink });
            bool flag2 = IsPointVisible(currentPoint, s2, new Rect[] { rectSource, rectSink });

            if (flag1) // s1 visible
            {
                if (flag2) // s1 and s2 visible
                {
                    if (rectSink.Contains(s1))
                        return s2;

                    if (rectSink.Contains(s2))
                        return s1;

                    if ((Distance(s1, endPoint) <= Distance(s2, endPoint)))
                        return s1;
                    else
                        return s2;

                }
                else
                {
                    return s1;
                }
            }
            else // s1 not visible
            {
                if (flag2) // only s2 visible
                {
                    return s2;
                }
                else // s1 and s2 not visible
                {
                    return new Point(double.NaN, double.NaN);
                }
            }
        }

        private static bool IsPointVisible(Point fromPoint, Point targetPoint, Rect[] rectangles)
        {
            foreach (Rect rect in rectangles)
            {
                if (RectangleIntersectsLine(rect, fromPoint, targetPoint))
                    return false;
            }
            return true;
        }

        private static bool IsRectVisible(Point fromPoint, Rect targetRect, Rect[] rectangles)
        {
            if (IsPointVisible(fromPoint, targetRect.TopLeft, rectangles))
                return true;

            if (IsPointVisible(fromPoint, targetRect.TopRight, rectangles))
                return true;

            if (IsPointVisible(fromPoint, targetRect.BottomLeft, rectangles))
                return true;

            if (IsPointVisible(fromPoint, targetRect.BottomRight, rectangles))
                return true;

            return false;
        }

        private static bool RectangleIntersectsLine(Rect rect, Point startPoint, Point endPoint)
        {
            rect.Inflate(-1, -1);
            return rect.IntersectsWith(new Rect(startPoint, endPoint));
        }

        private static void GetOppositeCorners(Placemement orientation, Rect rect, out Point n1, out Point n2)
        {
            switch (orientation)
            {
                case Placemement.Left:
                    n1 = rect.TopRight; n2 = rect.BottomRight;
                    break;
                case Placemement.Top:
                    n1 = rect.BottomLeft; n2 = rect.BottomRight;
                    break;
                case Placemement.Right:
                    n1 = rect.TopLeft; n2 = rect.BottomLeft;
                    break;
                case Placemement.Bottom:
                    n1 = rect.TopLeft; n2 = rect.TopRight;
                    break;
                default:
                    throw new Exception("No opposite corners found!");
            }
        }

        private static void GetNeighborCorners(Placemement orientation, Rect rect, out Point n1, out Point n2)
        {
            switch (orientation)
            {
                case Placemement.Left:
                    n1 = rect.TopLeft; n2 = rect.BottomLeft;
                    break;
                case Placemement.Top:
                    n1 = rect.TopLeft; n2 = rect.TopRight;
                    break;
                case Placemement.Right:
                    n1 = rect.TopRight; n2 = rect.BottomRight;
                    break;
                case Placemement.Bottom:
                    n1 = rect.BottomLeft; n2 = rect.BottomRight;
                    break;
                default:
                    throw new Exception("No neighour corners found!");
            }
        }

        private static double Distance(Point p1, Point p2)
        {
            return Point.Subtract(p1, p2).Length;
        }

        //private static Rect GetParentRectWithMargin(ConnectorViewModel connectorThumb, double margin)
        //{
        //    Rect rect = new Rect(connectorThumb.Parent.Left,
        //                         connectorThumb.Parent.Top,
        //                         connectorThumb.Parent.Width,
        //                         connectorThumb.Parent.Height);

        //    rect.Inflate(margin, margin);

        //    return rect;
        //}

        private static Point GetOffsetPoint(ConnectorBase connector, Rect rect)
        {
            Point offsetPoint = new Point();

            switch (connector.Placemement)
            {
                case Placemement.Left:
                    offsetPoint = new Point(rect.Left, connector.Position.Y);
                    break;
                case Placemement.Top:
                    offsetPoint = new Point(connector.Position.X, rect.Top);
                    break;
                case Placemement.Right:
                    offsetPoint = new Point(rect.Right, connector.Position.Y);
                    break;
                case Placemement.Bottom:
                    offsetPoint = new Point(connector.Position.X, rect.Bottom);
                    break;
                default:
                    break;
            }

            return offsetPoint;
        }

        private static void CheckPathEnd(ConnectorBase source, ConnectorBase sink, bool showLastLine, List<Point> linePoints)
        {
            if (showLastLine)
            {
                Point startPoint = new Point(0, 0);
                Point endPoint = new Point(0, 0);
                double marginPath = 15;
                switch (source.Placemement)
                {
                    case Placemement.Left:
                        startPoint = new Point(source.Position.X - marginPath, source.Position.Y);
                        break;
                    case Placemement.Top:
                        startPoint = new Point(source.Position.X, source.Position.Y - marginPath);
                        break;
                    case Placemement.Right:
                        startPoint = new Point(source.Position.X + marginPath, source.Position.Y);
                        break;
                    case Placemement.Bottom:
                        startPoint = new Point(source.Position.X, source.Position.Y + marginPath);
                        break;
                    default:
                        break;
                }

                switch (sink.Placemement)
                {
                    case Placemement.Left:
                        endPoint = new Point(sink.Position.X - marginPath, sink.Position.Y);
                        break;
                    case Placemement.Top:
                        endPoint = new Point(sink.Position.X, sink.Position.Y - marginPath);
                        break;
                    case Placemement.Right:
                        endPoint = new Point(sink.Position.X + marginPath, sink.Position.Y);
                        break;
                    case Placemement.Bottom:
                        endPoint = new Point(sink.Position.X, sink.Position.Y + marginPath);
                        break;
                    default:
                        break;
                }
                linePoints.Insert(0, startPoint);
                linePoints.Add(endPoint);
            }
            else
            {
                linePoints.Insert(0, source.Position);
                linePoints.Add(sink.Position);
            }
        }

        public static Placemement GetOpositeOrientation(Placemement connectorOrientation)
        {
            switch (connectorOrientation)
            {
                case Placemement.Left:
                    return Placemement.Right;
                case Placemement.Top:
                    return Placemement.Bottom;
                case Placemement.Right:
                    return Placemement.Left;
                case Placemement.Bottom:
                    return Placemement.Top;
                default:
                    return Placemement.Top;
            }
        }
    }
}

