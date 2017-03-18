﻿using System;
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
    public partial class ConnectionView : UserControl
    {
        private bool _hookDragging;
        private Panel _parentPanel;

        public ConnectionView()
        {
            Loaded += ConnectionView_Loaded;
            InitializeComponent();
        }

        private void ConnectionView_Loaded(object sender, RoutedEventArgs e)
        {
            _parentPanel = VisualHelper.FindParent<Grid>(this);
        }

        //private void OnHookDragDelta(object sender, DragDeltaEventArgs e)
        //{

        //    FrameworkElement element = sender as FrameworkElement;
        //    if (element != null)
        //    {
        //       Hook draggingHook = element.DataContext as Hook;
        //       draggingHook?.MoveHook(e.HorizontalChange, e.VerticalChange);
        //    }
        //    e.Handled = true;
        //}
        private void HookOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement hookElement = sender as FrameworkElement;
            if (hookElement != null)
            {
                _hookDragging = true;
                hookElement.CaptureMouse();
            }

        }

        private void HookOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement hookElement = sender as FrameworkElement;
            if (hookElement != null)
            {
                _hookDragging = false;
                hookElement.ReleaseMouseCapture();
            }

        }

        private void HookOnMouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = e.GetPosition(_parentPanel);
            if (_hookDragging)
            {
                FrameworkElement hookElement = sender as FrameworkElement;
                Hook itemHook = hookElement.DataContext as Hook;
                itemHook?.MoveHook(newPosition.X, newPosition.Y);
            }
        }

      
    }
}
