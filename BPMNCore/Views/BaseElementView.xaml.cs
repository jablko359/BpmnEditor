using System.Windows.Input;
using BPMNCore.DragAndDrop;
using BPMNCore.ViewModels;

namespace BPMNCore.Views
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
