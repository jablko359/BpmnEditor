using System;
using System.Windows;
using System.Windows.Controls;

namespace BPMNEditor.WindowStyle
{
	[TemplatePart(Name = "closeButton", Type = typeof(Button))]
	[TemplatePart(Name = "titleBar", Type = typeof(Border))]
	public class NonMovableWindow : Window
	{
		private Border _titlePanel;
		private Button _closeButton;
		private TextBlock _title;
		private double _titleFontSize = 12;
		private Thickness _titleMargin = new Thickness(10,7,0,2);

		public double TitleFontSize
		{
			get { return _titleFontSize; }
			set
			{
				_titleFontSize = value;
				if (_title != null)
				{
					_title.FontSize = value;
				}
			}
		}

		public Thickness TitleMargin
		{
			get { return _titleMargin; }
			set
			{
				_titleMargin = value;
				if (_title != null)
				{
					_title.Margin = value;
				}
			}
		}

		public NonMovableWindow()
		{
			ResourceDictionary resourceDict = new ResourceDictionary();
			resourceDict.Source = new Uri("WindowStyle/NonMovableWindow.xaml", UriKind.Relative);

			Style = resourceDict["NonMovableWindow"] as Style;
			Loaded += LengthNonMovableWindowLoaded;
		}

		private void LengthNonMovableWindowLoaded(object sender, RoutedEventArgs e)
		{
			_closeButton = (Button)Template.FindName("closeButton", this);
			_closeButton.Click += OnCloseButton_Click;

			_titlePanel = (Border)Template.FindName("titleBar", this);

			_title = (TextBlock)Template.FindName("title", this);
			_title.FontSize = _titleFontSize;
			_title.Margin = _titleMargin;
		}

		private void OnCloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		
	}
}
