﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Tools.GraphTools
{
    public static class Helper
    {
        public static List<Rect> GetPathRects(ConnectionViewModel connection)
        {
            var rects = new List<Rect>();
            List<Point> points = new List<Point>() { connection.StartPoint };
            points.AddRange(connection.Points);
            points.Add(connection.EndPoint);
            for (int i = 1; i < points.Count; i++)
            {
                var startPoint = points[i - 1];
                var endPoint = points[i];
                Rect lineRect = new Rect(startPoint,endPoint);
                rects.Add(lineRect);
            }
            return rects;
        }

        public static Rect CreateCenteredRect(Point centerPoint, Size size)
        {
            Point topLeft = new Point(centerPoint.X - size.Width, centerPoint.Y - size.Height);
            return new Rect(topLeft, size);
        }
    }
}