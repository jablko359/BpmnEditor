using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BPMNCore.Actions;
using BPMNCore.DragAndDrop;
using BPMNCore.Elements;
using BPMNCore.GraphTools;

namespace BPMNCore.ViewModels
{
    public class DocumentViewModel : PropertyChangedBase, IDropable, IContentSelectable, IElementsContainer<BaseElementViewModel>
    {
        #region Private members

        private double _trackerCenterX;
        private double _trackerCenterY;

        private ConnectorViewModel _currentConnetor;
        private DrawingConnectionViewModel _drawingConnectionViewModel;

        private readonly Document _document;
        private ObservableCollection<BaseElementViewModel> _baseElements;

        #endregion

        #region Properties

        public IList<BaseElementViewModel> Items => BaseElements;

        public TrackerViewModel Tracker { get; private set; }
        public SelectionViewModel Selection { get; private set; }


        public ObservableDropoutStack<IAction> Actions { get; } = new ObservableDropoutStack<IAction>(10);
        public ObservableDropoutStack<IAction> RedoActions { get; } = new ObservableDropoutStack<IAction>();

        public ObservableCollection<BaseElementViewModel> BaseElements
        {
            get { return _baseElements; }
            set
            {
                if (_baseElements != null)
                {
                    _baseElements.CollectionChanged -= BaseElements_CollectionChanged;
                    foreach (BaseElementViewModel baseElementViewModel in _baseElements)
                    {
                        baseElementViewModel.ActionPerformed -= ViewModel_ActionPerformed;
                    }
                }

                _baseElements = value;
                foreach (BaseElementViewModel baseElementViewModel in _baseElements)
                {
                    baseElementViewModel.ActionPerformed += ViewModel_ActionPerformed;
                }
                AddDefaultElements();
                _baseElements.CollectionChanged += BaseElements_CollectionChanged;

            }
        }


        public string Name
        {
            get { return _document.Name; }
            set
            {
                _document.Name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        public Document Document { get { return _document; } }

        public bool CanSelect => true;
        #endregion

        #region Events

        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        #endregion

        #region Contructor
        public DocumentViewModel()
        {
            _document = new Document();
            BaseElements = new ObservableCollection<BaseElementViewModel>();
            AddDefaultElements();
            Name = "Graph";
        }

        public DocumentViewModel(Document document) 
        {
            _document = document;
        }
        #endregion

        #region Handlers

        private void BaseElements_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (object item in e.NewItems)
                {
                    var baseElementViewModel = item as BaseElementViewModel;
                    var baseElement = baseElementViewModel.BaseElement;
                    if (baseElement == null)
                    {
                        continue;
                    }
                    if (baseElement is PoolElement)
                    {
                        _document.Pools.Add(baseElement as PoolElement);
                    }
                    else
                    {
                        var poolElement = item as PoolElementViewModel;
                        if (poolElement != null && poolElement.Pool == null)
                        {
                            _document.MainPoolElement.Elements.Add(baseElement);
                        }
                    }
                    baseElementViewModel.ActionPerformed += ViewModel_ActionPerformed;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (object item in e.OldItems)
                {
                    var baseElementViewModel = item as BaseElementViewModel;
                    var baseElement = baseElementViewModel.BaseElement;
                    if (baseElement is PoolElement)
                    {
                        _document.Pools.Remove(baseElement as PoolElement);
                    }
                    else if (baseElementViewModel is ElementsConnectionViewModel)
                    {
                        ModelHelper.RemoveConnectionModel(baseElementViewModel as ElementsConnectionViewModel);
                    }
                    else
                    {
                        _document.BaseElements.Remove(baseElement);
                    }
                    baseElementViewModel.ActionPerformed -= ViewModel_ActionPerformed;
                }
            }

        }

        #endregion

        #region IDropable
        public Type DataType => typeof(IDocumentElement);

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

        #region Static

        internal static DocumentViewModel FromModel(Document document)
        {
            DocumentViewModel documentViewModel = new DocumentViewModel(document);
            DocumentViewModelBuilder helperViewModelBuilder = new DocumentViewModelBuilder(documentViewModel);
            helperViewModelBuilder.Fill();
            return documentViewModel;
        }


        #endregion

        #region PublicMethods

        public void Redo()
        {
            IAction lastUndoAction = RedoActions.Pop();
            IAction undoAction = lastUndoAction.GetInverseAction();
            Actions.Push(undoAction);
            lastUndoAction?.Revert();
        }

        public void Undo()
        {
            IAction lastAction = Actions.Pop();
            IAction redoAction = lastAction.GetInverseAction();
            RedoActions.Push(redoAction);
            lastAction?.Revert();
        }

        public void Redo(IAction action)
        {
            var index = Actions.IndexOf(action);
            if (index != -1)
            {
                for (var i = 0; i <= index; i++)
                {
                    IAction undoAction = Actions.Pop();
                    var redoAction = undoAction.GetInverseAction();
                    RedoActions.Push(redoAction);
                    undoAction.Revert();
                }
            }
        }

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
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(null));
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
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(sender));
        }

        public void DeleteItem(BaseElementViewModel item)
        {
            BaseElements.Remove(item);
            AddUndoAction(new GenericDeletedAction<BaseElementViewModel>(this, item));
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
            var selected = Selection.ChangeSelection(getPosition, BaseElements);
            var selectedCount = selected.Count;
            SelectionChanged?.Invoke(this,
                selectedCount == 1
                    ? new SelectionChangedEventArgs(selected.FirstOrDefault())
                    : new SelectionChangedEventArgs(null));
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


        #endregion

        #region PrivateMethods

        /// <summary>
        /// Add tracker, selection and drawing connection view models
        /// </summary>
        private void AddDefaultElements()
        {
            
            Tracker = new TrackerViewModel(this);
            Selection = new SelectionViewModel(this);
            _drawingConnectionViewModel = new DrawingConnectionViewModel(this);
            BaseElements.Add(Tracker);
            BaseElements.Add(Selection);
            BaseElements.Add(_drawingConnectionViewModel);
        }

        private void PlaceElement(ITypeProvider provider, double x, double y)
        {
            BaseElementViewModel viewModel = BaseElementViewModel.GetViewModel(provider.ElementType, this);
            viewModel.Left = x - _trackerCenterX;
            viewModel.Top = y - _trackerCenterY;
            BaseElements.Add(viewModel);
            AddUndoAction(new GenericAddedAction<BaseElementViewModel>(this, viewModel));
        }

        private void ViewModel_ActionPerformed(object sender, ActionPerformedEventArgs e)
        {
            AddUndoAction(e.Action);
        }

        private void AddUndoAction(IAction action)
        {
            Actions.Push(action);
            RedoActions.Clear();
        }




        #endregion

    }
}
