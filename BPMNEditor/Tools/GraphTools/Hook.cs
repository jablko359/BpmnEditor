using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Tools.GraphTools
{
    public class Hook 
    {
        public Point HookPoint { get; }
        public Orientation Orientation { get; }

        public Hook(Point point, Orientation orientation)
        {
            HookPoint = point;
            Orientation = orientation;
        }

        public static Orientation GetOrientation(Point startPoint, Point endPoint)
        {
            return startPoint.X == endPoint.X ? Orientation.Vertical : Orientation.Horizontal;
        }
    }


}
