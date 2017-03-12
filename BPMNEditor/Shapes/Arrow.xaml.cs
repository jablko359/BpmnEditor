using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using BPMNEditor.Annotations;

namespace BPMNEditor.Shapes
{
    /// <summary>
    /// Interaction logic for Arrow.xaml
    /// </summary>
    public partial class Arrow : UserControl, INotifyPropertyChanged
    {
        #region Dependency properties
        public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register(
            "StartPoint", typeof(Point), typeof(Arrow), new PropertyMetadata(default(Point)));

        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }

        public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register(
            "EndPoint", typeof(Point), typeof(Arrow), new PropertyMetadata(default(Point)));

        public Point EndPoint
        {
            get { return (Point)GetValue(EndPointProperty); }
            set { SetValue(EndPointProperty, value); }
        }

        public static readonly DependencyProperty HeadWidthProperty = DependencyProperty.Register(
            "HeadWidth", typeof(double), typeof(Arrow), new PropertyMetadata(default(double)));

        public double HeadWidth
        {
            get { return (double)GetValue(HeadWidthProperty); }
            set
            {
                SetValue(HeadWidthProperty, value);
            }
        }

        public static readonly DependencyProperty HeadHeightProperty = DependencyProperty.Register(
            "HeadHeight", typeof(double), typeof(Arrow), new PropertyMetadata(default(double)));

        public double HeadHeight
        {
            get { return (double)GetValue(HeadHeightProperty); }
            set
            {
                SetValue(HeadHeightProperty, value);
            }
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        public Point HeadPoint1 { get; set; }
        public Point HeadPoint2 { get; set; }

        public Arrow()
        {
            InitializeComponent();
            this.LayoutUpdated += Arrow_LayoutUpdated;
        }

        private void Arrow_LayoutUpdated(object sender, EventArgs e)
        {
            CalcualteArrow();
        }

        private void CalcualteArrow()
        {
            double theta = Math.Atan2(StartPoint.Y - EndPoint.Y, StartPoint.X - EndPoint.X);
            double sint = Math.Sin(theta);
            double cost = Math.Cos(theta);

            HeadPoint1 = new Point(
                EndPoint.X + (HeadWidth * cost - HeadHeight * sint),
                EndPoint.Y + (HeadWidth * sint + HeadHeight * cost));

            HeadPoint2 = new Point(
                EndPoint.X + (HeadWidth * cost + HeadHeight * sint),
                EndPoint.Y - (HeadHeight * cost - HeadWidth * sint));

            OnPropertyChanged(nameof(HeadPoint1));
            OnPropertyChanged(nameof(HeadPoint2));
        }


    }
}
