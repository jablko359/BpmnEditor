using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BPMNEditor.Tools.DragAndDrop;

namespace BPMNEditor.Views
{
    /// <summary>
    /// Interaction logic for ResizeThumb.xaml
    /// </summary>
    public partial class ResizeThumb : Thumb
    {
        public ResizeThumb()
        {
            InitializeComponent();
            DragDelta += ResizeThumb_DragDelta;
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            IResizableObject resizable = DataContext as IResizableObject;
            if (resizable != null)
            {
                ChangeVertical(e.VerticalChange, resizable);
                ChangeHorizontal(e.HorizontalChange, resizable);
            }
        }

        private void ChangeVertical(double verticalChange, IResizableObject resizable)
        {
            double deltaVertical;
            switch (VerticalAlignment)
            {
                case VerticalAlignment.Bottom:
                    deltaVertical = Math.Min(verticalChange, resizable.Height - resizable.MinHeight);
                    resizable.Height += deltaVertical;
                    break;
                case VerticalAlignment.Top:
                    deltaVertical = Math.Min(verticalChange, resizable.Height - resizable.MinHeight);
                    resizable.Top += deltaVertical;
                    resizable.Height -= deltaVertical;
                    break;
                default:
                    break;
            }

        }

        private void ChangeHorizontal(double horizontalChange, IResizableObject resizable)
        {
            double deltaHorizontal;
            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    deltaHorizontal = Math.Min(horizontalChange, resizable.Width - resizable.MinWidth);
                    resizable.Left += deltaHorizontal;
                    resizable.Width -= deltaHorizontal;
                    break;
                case HorizontalAlignment.Right:
                    deltaHorizontal = Math.Min(horizontalChange, resizable.Width - resizable.MinWidth);
                    resizable.Width += deltaHorizontal;
                    break;
                default:
                    break;
            }
        }
    }
}
