using System.Windows;
using System.Windows.Input;
using BPMNCore.DragAndDrop;
using BPMNCore.ViewModels;

namespace BPMNCore.Views
{
    /// <summary>
    /// Interaction logic for PoolView.xaml
    /// </summary>
    public partial class PoolView : DragableUserControl
    {
        private DocumentView _documentView;

        public PoolView()
        {
            InitializeComponent();
            Loaded += PoolView_Loaded;
            
        }

        private void PoolView_Loaded(object sender, RoutedEventArgs e)
        {
            _documentView = VisualHelper.FindParent<DocumentView>(this);
        }

        protected override void DoDrag(double x, double y)
        {
            BaseElementViewModel viewModel = (BaseElementViewModel)DataContext;
            if (viewModel.IsSelected)
            {
                viewModel.Left = x - DragStartPoint.X;
                viewModel.Top = y - DragStartPoint.Y;
            }
        }
        

        private void TextAreaOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 1)
                {
                    BaseElementViewModel viewModel = (BaseElementViewModel)DataContext;
                    viewModel.IsSelected = true;
                }
            }
        }
        
        private void TextBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox.Focus();
            e.Handled = true;
        }


        private void ItemsClicked(object sender, MouseButtonEventArgs e)
        {
            var viewModel = this.DataContext as BaseElementViewModel;
            if (viewModel != null && viewModel.IsSelected)
            {
                viewModel.IsSelected = false;
            }
        }

        protected override void StartDrag()
        {
            var viewModel = this.DataContext as BaseElementViewModel;
            viewModel?.StartMove();
        }

        protected override void StopDrag()
        {
            var viewModel = this.DataContext as BaseElementViewModel;
            viewModel?.StopMove();
        }
    }
}
