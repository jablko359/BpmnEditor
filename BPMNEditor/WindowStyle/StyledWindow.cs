using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using Button = System.Windows.Controls.Button;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Drawing.Point;

namespace BPMNEditor.WindowStyle
{
	/// <summary>
	/// Length Window used to modify non client area of default window.
	/// To change style, chagne resource name in constructor.
	/// </summary>
	[TemplatePart(Name = "minimizeButton", Type = typeof(Button))]
	[TemplatePart(Name = "closeButton", Type = typeof(Button))]
	[TemplatePart(Name = "restoreButton", Type = typeof(Button))]
	[TemplatePart(Name = "titleBar", Type = typeof(Border))]
	public abstract class StyledWindow : Window
	{
		#region Private members
		private Button _restoreButton;
		private Button _minimizeButton;
		private Button _closeButton;
		private Border _titlePanel;
		private TextBlock _title;
		private bool _restoreIfMove;
	

		#endregion

		#region Properties
		

		#endregion

		#region Constructor
		protected StyledWindow()
		{
			//Style of the window (it includes title bar)	
			ResourceDictionary resourceDict = new ResourceDictionary();
			resourceDict.Source = new Uri("WindowStyle/StyledWindow.xaml", UriKind.Relative);


			Style = resourceDict["WindowStyle"] as Style;
			Loaded += LengthWindow_Loaded;

			StateChanged += LengthWindow_StateChanged;
			
		}

		private void LengthWindow_StateChanged(object sender, EventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				SetWindowMaxSize();
			}
		}

		#endregion

		private void LengthWindow_Loaded(object sender, RoutedEventArgs e)
		{
			_minimizeButton = (Button)Template.FindName("minimizeButton", this);
			_minimizeButton.Click += OnMinimizeButton_Click;

			_restoreButton = (Button)Template.FindName("restoreButton", this);
			_restoreButton.Click += OnRestoreButton_Click;

			_closeButton = (Button)Template.FindName("closeButton", this);
			_closeButton.Click += OnCloseButton_Click;

			_titlePanel = (Border)Template.FindName("titleBar", this);
			_titlePanel.MouseLeftButtonDown += OnTitlePanel_MouseLeftButtonDown;
			_titlePanel.MouseMove += MouseMoved;
			_titlePanel.MouseLeftButtonUp += LeftButtonUp;

			_title = (TextBlock) Template.FindName("title",this);
			Deactivated += WindowDeactivated;
			Activated += WindowActivated;

		}

		private void WindowDeactivated(object sender, EventArgs e)
		{
			//_title.Foreground = Brushes.Gray;
		}

		private void WindowActivated(object sender, EventArgs e)
		{
			//_title.Foreground = Brushes.Black;
		}
		private void OnTitlePanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				if (WindowState == WindowState.Normal)
				{
					SetWindowMaxSize();
					WindowState = WindowState.Maximized;
				}
				else if (WindowState == WindowState.Maximized)
				{
					WindowState = WindowState.Normal;
				}
			}
			else
			{
				if (WindowState == WindowState.Maximized)
				{
					_restoreIfMove = true;
				}
				else if (Mouse.LeftButton == MouseButtonState.Pressed)
				{
					DragMove();
				}
			}
		}

		private void OnCloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void OnRestoreButton_Click(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}
			else if (WindowState == WindowState.Normal)
			{
				SetWindowMaxSize();
				WindowState = WindowState.Maximized;
			}
		}

		private void OnMinimizeButton_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void MouseMoved(object sender, MouseEventArgs e)
		{
			if (_restoreIfMove)
			{
				_restoreIfMove = false;
				double mouseX = System.Windows.Forms.Cursor.Position.X;
				double width = RestoreBounds.Width;
				double x = mouseX - width / 2;
				Point mp = new Point(System.Windows.Forms.Cursor.Position.X,
						System.Windows.Forms.Cursor.Position.Y);
				Screen currentScreen = Screen.FromPoint(mp);
				if (x + width > currentScreen.WorkingArea.Right)
				{
					x = currentScreen.WorkingArea.X - width;
				}
				WindowState = WindowState.Normal;
				Left = x;
				Top = System.Windows.Forms.Cursor.Position.Y - ((FrameworkElement)sender).ActualHeight;
				if (Mouse.LeftButton == MouseButtonState.Pressed)
				{
					DragMove();
				}
			}
		}
		/// <summary>
		/// When window style is set to none it prevents window to cover taskbar
		/// </summary>
		private void SetWindowMaxSize()
		{
			var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
			MaxWidth = screen.WorkingArea.Width + Margin.Left + Margin.Right;
			MaxHeight = screen.WorkingArea.Height + Margin.Top + Margin.Bottom;
		}

		private void LeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			_restoreIfMove = false;
		}
	}

}
