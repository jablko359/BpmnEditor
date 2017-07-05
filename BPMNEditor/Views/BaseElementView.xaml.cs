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
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.ViewModels;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace BPMNEditor.Views
{
    /// <summary>
    /// Interaction logic for BaseElementView.xaml
    /// </summary>
    public partial class BaseElementView : DragableUserControl
    {
        public BaseElementView()
        {
            InitializeComponent();
        }

        protected override void DoDrag(double x, double y)
        {
            BaseElementViewModel viewModel = (BaseElementViewModel) DataContext;
            if (viewModel.IsSelected)
            {
                viewModel.Left = x - DragStartPoint.X;
                viewModel.Top = y - DragStartPoint.Y;
            }
        }

        private void BaseElementView_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BaseElementViewModel viewModel = (BaseElementViewModel)DataContext;
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                viewModel.IsSelected = !viewModel.IsSelected;
            }
            else
            {
                viewModel.Select();
            }
            
            
        }

        protected override void StartDrag()
        {
            BaseElementViewModel viewModel = (BaseElementViewModel)DataContext;
            viewModel.StartMove();
        }

        protected override void StopDrag()
        {
            BaseElementViewModel viewModel = (BaseElementViewModel)DataContext;
            viewModel.StopMove();
        }
        
    }
}
