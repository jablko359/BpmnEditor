using System.Windows;
using System.Windows.Controls;

namespace BPMNCore.Views
{
    /// <summary>
    /// Interaction logic for ConnectionView.xaml
    /// </summary>
    public partial class DrawingConnectionView : UserControl
    {
        public DrawingConnectionView()
        {
            Loaded += ConnectionView_Loaded;
            InitializeComponent();
        }

        private void ConnectionView_Loaded(object sender, RoutedEventArgs e)
        {
        }
        
    }
}
