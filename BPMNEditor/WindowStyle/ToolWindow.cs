using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BPMNEditor.WindowStyle
{
	[TemplatePart(Name = "closeButton", Type = typeof(Button))]
	[TemplatePart(Name = "titleBar", Type = typeof(Border))]
	public class ToolWindow : Window
	{
		private Border _titlePanel;
		private Button _closeButton;
		private TextBlock _title;

		public ToolWindow()
		{
			ResourceDictionary resourceDict = new ResourceDictionary();
			resourceDict.Source = new Uri("WindowStyle/ToolWindow.xaml", UriKind.Relative);

			Style = resourceDict["ToolWindow"] as Style;
			Loaded += LengthToolWindow_Loaded;
		}

		private void LengthToolWindow_Loaded(object sender, RoutedEventArgs e)
		{
			_closeButton = (Button)Template.FindName("closeButton", this);
			_closeButton.Click += OnCloseButton_Click;

			_titlePanel = (Border)Template.FindName("titleBar", this);
			_titlePanel.MouseLeftButtonDown += OnTitlePanel_MouseLeftButtonDown;

			_title = (TextBlock)Template.FindName("title", this);
			Deactivated += WindowDeactivated;
			Activated += WindowActivated;
		}

		private void OnTitlePanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if(e.ButtonState == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void OnCloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void WindowDeactivated(object sender, EventArgs e)
		{
			//_title.Foreground = Brushes.Gray;
		}

		private void WindowActivated(object sender, EventArgs e)
		{
			//_title.Foreground = Brushes.Black;
		}
	}
}
