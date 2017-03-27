using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views
{
    /// <summary>
    /// Interaction logic for LaneView.xaml
    /// </summary>
    public partial class LaneView : UserControl
    {
        private bool _isDragging = false;
        private Point _startPoint = new Point();

        public LaneView()
        {
            InitializeComponent();
        }

        private void BorderOnLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _startPoint = e.GetPosition(this);
            ResizeRectangle.CaptureMouse();
        }

        private void BorderOnLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            ResizeRectangle.ReleaseMouseCapture();
        }

        private void BorderOnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Vector change = _startPoint - e.GetPosition(this);
                LaneViewModel viewModel = DataContext as LaneViewModel;
                if (viewModel != null)
                {
                    double newHeight = viewModel.Height - change.Y;
                    viewModel.Resize(newHeight);
                    _startPoint = e.GetPosition(this);
                }
            }
        }
    }
}
