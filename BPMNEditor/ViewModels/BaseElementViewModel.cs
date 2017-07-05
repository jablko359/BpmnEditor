using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using BPMNCore;
using BPMNEditor.Actions;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.Tools.GraphTools;
using BPMNEditor.ViewModels.Command;



namespace BPMNEditor.ViewModels
{
    public abstract class BaseElementViewModel : VisualElementViewModel, IResizable, IMovable, IInsertable, IPropertyRemember
    {
        private static readonly HashSet<string> DimensionProperties = new HashSet<string>() { nameof(Width), nameof(Height), nameof(Top), nameof(Left) };


        #region Private members

        private bool _isSelected;
        private int _itemZIndex;
        private bool _isConnectorVisible;
        private PropertyMemento _lastProperty;
        private bool _isVisible;

        private Point _lastPoint;
        private Rect _lastSize;


        private readonly ConnectorViewModel[] _connectors = new ConnectorViewModel[4];
        private readonly List<ElementsConnectionViewModel> _activeConnections = new List<ElementsConnectionViewModel>();
        #endregion

        #region Commands
        [Browsable(false)]
        public ICommand SelectCommand { get; private set; }
        [Browsable(false)]
        public ICommand DeleteCommand { get; private set; }
        [Browsable(false)]
        public ICommand BringToFrontCommand { get; private set; }
        #endregion

        #region Properties

        [Browsable(false)]
        public virtual bool CanConnect => false;

        [Browsable(false)]
        public bool CanMove => IsSelected;

        [Browsable(false)]
        public DocumentViewModel Document { get; }

        [Browsable(false)]
        public ConnectorViewModel[] Connectors
        {
            get { return _connectors; }
        }

        [Browsable(false)]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(nameof(IsSelected));
            }
        }

        [Browsable(false)]
        public int ItemZIndex
        {
            get { return _itemZIndex; }
            set
            {
                _itemZIndex = value;
                NotifyOfPropertyChange(nameof(ItemZIndex));
            }
        }

        [Browsable(false)]
        public bool IsConnectorVisible
        {
            get { return _isConnectorVisible; }
            set
            {
                _isConnectorVisible = value;
                NotifyOfPropertyChange(nameof(IsConnectorVisible));
            }
        }


        [Browsable(false)]
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(nameof(IsVisible));
            }
        }

        [Browsable(false)]
        public virtual bool IsSelectableByUser { get { return true; } }
        [Browsable(false)]
        public double MinHeight { get; set; }
        [Browsable(false)]
        public double MinWidth { get; set; }

        #endregion

        #region Abstract and virtual
        protected abstract VisualElement CreateElement();

        protected virtual void SetElement(VisualElement element)
        {
            BaseElement = element;
        }
        #endregion

        #region Events
        public event EventHandler<ActionPerformedEventArgs> ActionPerformed;
        public event EventHandler<EventArgs> ElementDeleted;
        #endregion



        #region Constructor

        protected BaseElementViewModel(DocumentViewModel documentViewModel)
        {
            _itemZIndex = 0;
            Document = documentViewModel;
            PropertyChanged += BaseElementViewModel_PropertyChanged;
            SelectCommand = new RelayCommand(item => Select());
            DeleteCommand = new RelayCommand(item => Delete());
            //Doesn't work
            BringToFrontCommand = new RelayCommand(item => BringToFront());
            InitializeConnectors();

        }

        private void BaseElementViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DimensionProperties.Contains(e.PropertyName))
            {
                DimensionChanged();
            }
        }

        private void InitializeConnectors()
        {
            for (int i = 0; i < _connectors.Length; i++)
            {
                _connectors[i] = new ConnectorViewModel(this, (Placemement)i);
            }
        }

        protected void NotifyActionPerformed(IAction action)
        {
            ActionPerformedEventArgs eventArgs = new ActionPerformedEventArgs(action);
            ActionPerformed?.Invoke(this, eventArgs);
        }

        #endregion

        #region Public methods

        public void Select()
        {
            IsSelected = true;
            IsConnectorVisible = true;
            Document.SelectSignleItem(this);
        }

        public void Deselect()
        {
            IsSelected = false;
            IsConnectorVisible = false;
            ShowAllConnectors();
        }

        public void Delete()
        {
            Document.DeleteItem(this);
            ElementDeleted?.Invoke(this, new EventArgs());
        }

        public void BringToFront()
        {
            Document.BringItemToFront(this);
        }

        public void ConnectorStart(ConnectorViewModel connector)
        {
            Document.NotifyConnectors(BaseElement.GetType(), connector, this);
        }

        public void SetConnection(ElementsConnectionViewModel connection)
        {
            connection.ElementDeleted += Connection_ElementDeleted;
            GenericAddedAction<BaseElementViewModel> addedAction = new GenericAddedAction<BaseElementViewModel>(Document, connection);
            var addedActionArgs = new ActionPerformedEventArgs(addedAction);
            ActionPerformed?.Invoke(this, addedActionArgs);
            _activeConnections.Add(connection);
        }

        private void Connection_ElementDeleted(object sender, EventArgs e)
        {
            ElementsConnectionViewModel senderConnectionViewModel = sender as ElementsConnectionViewModel;
            if (senderConnectionViewModel != null)
            {
                senderConnectionViewModel.ElementDeleted -= Connection_ElementDeleted;
                RemoveConnection(senderConnectionViewModel);
            }
        }

        

        /// <summary>
        /// Hides all connectors expcept specified one
        /// </summary>
        /// <param name="connector"></param>
        public void HideOtherConnectors(ConnectorViewModel connector)
        {
            foreach (ConnectorViewModel viewModel in _connectors)
            {
                if (viewModel != connector)
                {
                    viewModel.IsVisible = false;
                }
            }
        }

        public void ShowAllConnectors()
        {
            foreach (ConnectorViewModel viewModel in _connectors)
            {
                viewModel.IsVisible = true;
            }
        }



        #endregion

        private void RemoveConnection(ElementsConnectionViewModel connection)
        {
            _activeConnections.Remove(connection);
        }

        protected virtual void DimensionChanged()
        {
        }

        public virtual void StartMove()
        {
            _lastPoint = new Point(Left, Top);
        }

        public virtual void StopMove()
        {
            ElementMoveAction moveAction = new ElementMoveAction(this, _lastPoint, new Point(Left, Top));
            ActionPerformedEventArgs moveActionEventArgs = new ActionPerformedEventArgs(moveAction);
            ActionPerformed?.Invoke(this, moveActionEventArgs);
        }



        #region Factory

        public static BaseElementViewModel GetViewModel(Type elementType, DocumentViewModel documentViewModel, bool setModelData = true)
        {
            BaseElementViewModel resultViewModel = null;
            CustomModelAttribute attribute =
                (CustomModelAttribute) Attribute.GetCustomAttribute(elementType, typeof(CustomModelAttribute));
            if (attribute == null)
            {
                resultViewModel = CreateStandardModel(elementType, documentViewModel, setModelData);
            }
            else
            {
                resultViewModel = CreateCustomModel(elementType, documentViewModel, setModelData);
            }
            return resultViewModel;
        }

        private static BaseElementViewModel CreateCustomModel(Type elementType, DocumentViewModel documentViewModel, bool setModelData)
        {
            BaseElementViewModel viewModel = new GenericViewModelAdapter(documentViewModel, elementType);
            if (setModelData)
            {
                viewModel.BaseElement = viewModel.CreateElement();
                
            }
            return viewModel;
        }

        internal static BaseElementViewModel GetViewModel(VisualElement baseElement, DocumentViewModel documentViewModel)
        {
            BaseElementViewModel viewModel = GetViewModel(baseElement.GetType(), documentViewModel, false);
            viewModel.SetElement(baseElement);
            
            return viewModel;
        }

        public static BaseElementViewModel CreateStandardModel(Type elementType, DocumentViewModel documentViewModel,
            bool setModelData = true)
        {
            ElementViewModelAttribute attribute =
               (ElementViewModelAttribute)Attribute.GetCustomAttribute(elementType, typeof(ElementViewModelAttribute));
            if (attribute == null)
            {
                throw new NotSupportedException(string.Format("Not supported type {0}. Does not have ElementViewModelAttribute", elementType));
            }
            Type viewModelType = attribute.ViewModelType;
            BaseElementViewModel viewModel =
                (BaseElementViewModel)Activator.CreateInstance(viewModelType, documentViewModel);
            if (setModelData)
            {
                viewModel.BaseElement = viewModel.CreateElement();
                viewModel.Height = attribute.InitialSize.Height;
                viewModel.Width = attribute.InitialSize.Width;
            }
            return viewModel;
        }

        #endregion

        public void ResizeStart()
        {
            Size lastSize = new Size(Width, Height);
            Point lastPos = new Point(Left, Top);
            _lastSize = new Rect(lastPos, lastSize);
        }

        public void ResizeStop()
        {
            Size newSize = new Size(Width, Height);
            Point newPos = new Point(Left, Top);
            Rect newRect = new Rect(newPos, newSize);
            IAction actionPerformed = new ElementResizeAction(this, _lastSize, newRect);
            ActionPerformedEventArgs actionPerformedEventArgs = new ActionPerformedEventArgs(actionPerformed);
            ActionPerformed?.Invoke(this, actionPerformedEventArgs);
        }

        public void RememberProperty(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);
            if (property != null)
            {
                object value = property.GetValue(this);
                _lastProperty = new PropertyMemento(value, propertyName);
            }
            else
            {
                throw new ArgumentException($"Property {propertyName} not found");
            }
        }

        public void NotifyActionPropertyChagned(string propertyName, object oldValue, object newValue)
        {
            var property = GetType().GetProperty(propertyName);
            if (property.PropertyType == oldValue.GetType())
            {
                _lastProperty = new PropertyMemento(oldValue, propertyName);
            }
            NotifyActionPropertyChagned(propertyName, newValue);
        }

        public void NotifyActionPropertyChagned(string propertyName, object value)
        {
            if (_lastProperty == null)
            {
                throw new NullReferenceException("Property not saved. Cannot raise event");
            }
            if (_lastProperty.Name == propertyName)
            {
                var property = GetType().GetProperty(propertyName);
                if (property == null)
                {
                    throw new ArgumentException($"Property {propertyName} not found");
                }
                if (!value.Equals(_lastProperty.Value))
                {
                    PropertyChangedAction action = new PropertyChangedAction(this, _lastProperty.Value, value, propertyName);
                    NotifyActionPerformed(action);
                }
            }
            else
            {
                throw new ArgumentException($"Last property is {_lastProperty.Name} not {propertyName}");
            }
        }

        /// <summary>
        /// Finds connector that is nearest to the point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public ConnectorViewModel GetNearestConnector(Point point)
        {
            double distance = Double.MaxValue;
            ConnectorViewModel result = null;
            foreach (ConnectorViewModel connectorViewModel in Connectors)
            {
                connectorViewModel.UpdatePosition();
                var dist = connectorViewModel.Position - point;
                if (dist.LengthSquared < distance)
                {
                    result = connectorViewModel;
                    distance = dist.LengthSquared;
                }
            }
            return result;
        }

        #region IInsertable

        public void AfterInsert()
        {
            foreach (var item in Document.BaseElements)
            {
                ElementsConnectionViewModel connectionViewModel = item as ElementsConnectionViewModel;
                if (connectionViewModel != null && (connectionViewModel.From == this || connectionViewModel.To == this))
                {
                    _activeConnections.Add(connectionViewModel);
                }
            }
        }

        public void AfterDelete()
        {

        }
        #endregion


    }
}
