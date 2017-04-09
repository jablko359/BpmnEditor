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

namespace BPMNEditor.Views
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

        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as BaseElementViewModel;
            viewModel?.RememberProperty("Name");
        }

        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as BaseElementViewModel;
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                viewModel?.NotifyActionPropertyChagned("Name", textBox.Text);
            }
            
        }
    }
}
