using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views.Controls
{
    public class RaisePropertyChangedActionBehavior : Behavior<FrameworkElement>
    {

        public string ControlPropertyName { get; set; }
        public string UpdatePropertyName { get; set; }


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
        }

        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = AssociatedObject.DataContext as BaseElementViewModel;
            var data = AssociatedObject.GetType().GetProperty(ControlPropertyName);
            viewModel?.NotifyActionPropertyChagned(UpdatePropertyName, data);
        }

        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = AssociatedObject.DataContext as BaseElementViewModel;
            viewModel?.RememberProperty(UpdatePropertyName);
        }
    }
}
