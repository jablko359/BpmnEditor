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
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views
{
    /// <summary>
    /// Interaction logic for PoolView.xaml
    /// </summary>
    public partial class PoolView : DragableUserControl
    {
        public PoolView()
        {
            InitializeComponent();
        }

        protected override void DoDrag(double x, double y)
        {
            BaseElementViewModel viewModel = (BaseElementViewModel)DataContext;
            if (viewModel.IsSelected)
            {
                viewModel.Left = x - TextArea.ActualWidth / 2;
                viewModel.Top = y - TextArea.ActualHeight / 2;
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
    }
}
