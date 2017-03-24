using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.Tools.GraphTools;
using BPMNEditor.ViewModels.Command;


namespace BPMNEditor.ViewModels
{
    public class DocumentViewModel : PropertyChangedBase, IDropable
    {
        #region Private members

        private double _trackerCenterX;
        private double _trackerCenterY;

        private ConnectorViewModel _currentConnetor;
        private DrawingConnectionViewModel _drawingConnectionViewModel;
        #endregion

        #region Properties

        public TrackerViewModel Tracker { get; }
        public SelectionViewModel Selection { get; }

        public ObservableCollection<BaseElementViewModel> BaseElements { get; }

        #endregion


        public DocumentViewModel()
        {
            BaseElements = new ObservableCollection<BaseElementViewModel>();
            Tracker = new TrackerViewModel(this);
            Selection = new SelectionViewModel(this);
            _drawingConnectionViewModel = new DrawingConnectionViewModel(this);
            BaseElements.Add(Tracker);
            BaseElements.Add(Selection);
            BaseElements.Add(_drawingConnectionViewModel);
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

        public void DeselectAll()
        {
            foreach (BaseElementViewModel baseElement in BaseElements)
            {
                baseElement.Deselect();
            }
        }

        public void SelectSignleItem(BaseElementViewModel sender)
        {
            foreach (BaseElementViewModel baseElement in BaseElements)
            {
                if (baseElement != sender)
                {
                    baseElement.IsSelected = false;
                    baseElement.IsConnectorVisible = false;
                }
            }
        }

        public void DeleteItem(BaseElementViewModel item)
        {
            BaseElements.Remove(item);
        }

        public void BringItemToFront(BaseElementViewModel item)
        {
            foreach (BaseElementViewModel baseElement in BaseElements)
            {
                if (baseElement == item)
                {
                    baseElement.ItemZIndex = 1;
                }
                else
                {
                    baseElement.ItemZIndex = 0;
                }
            }
        }

        public void NotifyConnectors(Type connectorType, ConnectorViewModel connector, BaseElementViewModel source)
        {
            if (_currentConnetor == null)
            {
                source.HideOtherConnectors(connector);
                foreach (BaseElementViewModel baseElement in BaseElements)
                {
                    if (source != baseElement && baseElement.IsTypeApplicable(connectorType))
                    {
                        baseElement.IsConnectorVisible = true;
                    }
                }
                _currentConnetor = connector;
            }
            else
            {
                _drawingConnectionViewModel.IsVisible = false;
                foreach (BaseElementViewModel baseElement in BaseElements)
                {
                    baseElement.ShowAllConnectors();
                }
                ElementsConnectionViewModel connection = new ElementsConnectionViewModel(this, _currentConnetor, connector);
                this.BaseElements.Add(connection);
                _currentConnetor = null;
            }

        }


        #endregion

        #region PrivateMethods

        private void PlaceElement(ITypeProvider provider, double x, double y)
        {
            BaseElementViewModel viewModel = BaseElementViewModel.GetViewModel(provider.ElementType, this);
            viewModel.Left = x - _trackerCenterX;
            viewModel.Top = y - _trackerCenterY;
            BaseElements.Add(viewModel);
        }
        #endregion

        public void StartSelection(Point startPoint)
        {
            Selection.Start(startPoint);
        }

        public void ReleaseSelection()
        {
            Selection.Release();
        }

        public void ChangeSelection(Point getPosition)
        {
            Selection.ChangeSelection(getPosition, BaseElements);
        }

        public void DrawConnectorLine(Point point)
        {
            if (_currentConnetor != null)
            {
                _drawingConnectionViewModel.StartConnetor = _currentConnetor;
                _drawingConnectionViewModel.EndPoint = point;
                _drawingConnectionViewModel.CalculatePath();
                _drawingConnectionViewModel.IsVisible = true;
            }
        }

        public void EndDrawConnectionLine(Point position)
        {
            if (_currentConnetor != null)
            {
                BaseElementViewModel source = _currentConnetor.Parent;
                _drawingConnectionViewModel.IsVisible = false;
                List<BaseElementViewModel> tempList = new List<BaseElementViewModel>(BaseElements);
                foreach (BaseElementViewModel baseElement in tempList)
                {
                    if (baseElement.BaseElement == null)
                    {
                        continue;
                    }
                    if (source != baseElement && baseElement.IsTypeApplicable(baseElement.BaseElement.GetType()))
                    {
                        Rect elementRect = Helper.GetRect(baseElement, 10);
                        Rect pointRect = new Rect(position, new Size(1, 1));
                        ConnectorViewModel connector = null;
                        bool connectionAdded = false;

                        foreach (ConnectorViewModel baseElementConnector in baseElement.Connectors)
                        {
                            Rect connectorRect = baseElementConnector.GetRectWithMargin(0);
                            if (connectorRect.IntersectsWith(pointRect))
                            {
                                connector = baseElementConnector;
                                break;
                            }
                            else if (baseElementConnector.Placemement == _drawingConnectionViewModel.EndPlacemement && elementRect.IntersectsWith(pointRect))
                            {
                                connector = baseElementConnector;
                            }
                        }
                        if (connector != null)
                        {
                            ElementsConnectionViewModel connection = new ElementsConnectionViewModel(this, _currentConnetor, connector);
                            this.BaseElements.Add(connection);
                            break;
                        }

                    }
                    baseElement.ShowAllConnectors();
                }
            }
            _currentConnetor = null;
        }
    }
}
