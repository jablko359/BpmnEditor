using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using BPMNCore.GraphTools;

namespace BPMNCore.ViewModels
{
    public class DrawingConnectionViewModel : BaseConnectionViewModel
    {
        public ConnectorViewModel StartConnetor
        {
           set { _start = value; }
        }

        public Placemement EndPlacemement { get; private set; }

        public DrawingConnectionViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            BaseElement = new VisualElement();
        }

        public override void CalculatePath()
        {
            List<Point> points = PathCreator.GetConnectionLine(_start, EndPoint, Placemement.None);
            StartPoint = points[1];
            EndPlacemement = PathCreator.GetOpositeOrientation(_start.Placemement);
            int idx = GetArrowIndex(points, EndPlacemement);
            ArrowPoint = points[idx];
            Points = new PointCollection(points.Take(idx + 1));
        }

        
    }
}
