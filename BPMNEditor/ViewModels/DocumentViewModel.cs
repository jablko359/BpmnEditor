using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;


namespace BPMNEditor.ViewModels
{
    public class DocumentViewModel : PropertyChangedBase, IDropable
    {
        #region Private members

        private double _trackerCenterX;
        private double _trackerCenterY;

        #endregion

        #region Properties


        public TrackerViewModel Tracker { get; }


        public ObservableCollection<BaseElementViewModel> BaseElements { get; }

        #endregion


        public DocumentViewModel()
        {
            BaseElements = new ObservableCollection<BaseElementViewModel>();
            Tracker = new TrackerViewModel();
            BaseElements.Add(Tracker);
        }

        #region IDropable
        public Type DataType { get { return typeof(IBaseElement); } }

        public void Drop(object data, double x = 0, double y = 0)
        {
            Tracker.IsTrackerVisible = false;
            ITypeProvider provider = data as ITypeProvider;
            if (provider == null)
            {
                throw new ArgumentException("Incorrect document drag over argument. Expected ITypeProvider");
            }
            PlaceElement(provider, x, y);
        }

        public void DragOver(double x, double y, object dragItem)
        {
            Tracker.IsTrackerVisible = true;
            Tracker.Left = x - _trackerCenterX;
            Tracker.Top = y - _trackerCenterY;
            ITypeProvider provider = dragItem as ITypeProvider;
            if (provider == null)
            {
                throw new ArgumentException("Incorrect document drag over argument. Expected ITypeProvider");
            }
            Tracker.TransferType = provider.ElementType;
        }

        public void DragLeave()
        {
            Tracker.IsTrackerVisible = false;
        }

        #endregion

        #region PublicMethods

        public void OnTrackerSizeChanged(Size newSize)
        {
            _trackerCenterX = newSize.Width / 2;
            _trackerCenterY = newSize.Height / 2;
        }

        #endregion

        #region PrivateMethods

        private void PlaceElement(ITypeProvider provider, double x, double y)
        {
            BaseElementViewModel viewModel = BaseElementViewModel.GetViewModel(provider.ElementType);
            viewModel.Left = x - _trackerCenterX;
            viewModel.Top = y - _trackerCenterY;
            BaseElements.Add(viewModel);
        }

        #endregion
    }
}
