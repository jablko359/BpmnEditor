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
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class DocumentView : UserControl
    {
        private bool _initialized = false;

        public DocumentView()
        {
            InitializeComponent();
        }


        private void DocumentView_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_initialized)
            {
                DocumentViewModel dvm = DataContext as DocumentViewModel;
            }
        }

        private void Tracker_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DocumentViewModel viewModel = DataContext as DocumentViewModel;
            if (viewModel != null)
            {
               viewModel.OnTrackerSizeChanged(e.NewSize);
            }
        }

        private void DocumentView_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DocumentViewModel viewModel = DataContext as DocumentViewModel;
            Control sourceControl = e.OriginalSource as Control;
            if (sourceControl != null)
            {
                viewModel?.GridClicked();
            }
        }
    }
}
