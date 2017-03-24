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
using BPMNEditor.Tools;
using BPMNEditor.Tools.GraphTools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views
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
