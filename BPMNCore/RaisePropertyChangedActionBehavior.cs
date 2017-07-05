using System.Windows;
using System.Windows.Interactivity;

namespace BPMNCore
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
            var viewModel = AssociatedObject.DataContext as IPropertyRemember;
            var data = AssociatedObject.GetType().GetProperty(ControlPropertyName);
            if (data != null)
            {
                viewModel?.NotifyActionPropertyChagned(UpdatePropertyName, data.GetValue(AssociatedObject));
            }
           
        }

        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = AssociatedObject.DataContext as IPropertyRemember;
            viewModel?.RememberProperty(UpdatePropertyName);
        }
    }
}
