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
using BPMNEditor.Tools.GraphTools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class DocumentView : UserControl
    {  
        private bool _initialized = false;
        //For selectiong region
        private bool _isDragging = false;

        
        //TODO! add connection dragger

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
            FrameworkElement sourceControl = e.OriginalSource as FrameworkElement;
            if (sourceControl != null)
            {
                viewModel?.DeselectAll();
                SelectNearLine(e);
                if (e.ChangedButton == MouseButton.Left)
                {
                    IContentSelectable selectableContent = sourceControl.DataContext as IContentSelectable;
                    if (selectableContent?.CanSelect == true)
                    {
                        _isDragging = true;
                        viewModel?.StartSelection(e.GetPosition(this));
                    }

                }
            }
            
        }
        /// <summary>
        /// Select nearby conenctions
        /// </summary>
        /// <param name="e"></param>
        private bool SelectNearLine(MouseButtonEventArgs e)
        {
           
            var paths = VisualHelper.FindVisualChildren<Path>(this);
            var mouseNeighbourhood = Helper.CreateCenteredRect(e.GetPosition(this), new Size(10, 10));
            foreach (Path path in paths)
            {
                
                if (path.Name == "ConnectionPath")
                {
                    ElementsConnectionViewModel viewModel = path.DataContext as ElementsConnectionViewModel;
                    if (viewModel != null)
                    {
                        List<Rect> rects = Helper.GetPathRects(viewModel);
                        foreach (Rect rect in rects)
                        {
                            if (mouseNeighbourhood.IntersectsWith(rect))
                            {
                                if (e.ChangedButton == MouseButton.Left)
                                {
                                    viewModel.Select();
                                }
                                else if(e.ChangedButton == MouseButton.Right)
                                {
                                    viewModel.IsContextMenuOpened = true;
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void DocumentView_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _isDragging = false;
                DocumentViewModel viewModel = DataContext as DocumentViewModel;
                viewModel?.ReleaseSelection();
            }
        }

        private void DocumentView_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                DocumentViewModel viewModel = DataContext as DocumentViewModel;
                viewModel?.ChangeSelection(e.GetPosition(this));
            }
        }
    }
}
