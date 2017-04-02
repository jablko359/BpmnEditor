﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.Tools.GraphTools;
using BPMNEditor.ViewModels.Command;


namespace BPMNEditor.ViewModels
{
    public abstract class BaseElementViewModel : PropertyChangedBase, IResizableObject, IMovable
    {
        private static readonly HashSet<string> DimensionProperties = new HashSet<string>() { nameof(Width), nameof(Height), nameof(Top), nameof(Left) };


        #region Private members
        private double _width;
        private double _top;
        private double _height;
        private double _left;
        private bool _isSelected;
        private int _itemZIndex;
        private bool _isConnectorVisible;

        protected readonly DocumentViewModel Document;
        private readonly List<ConnectorViewModel> _connectors = new List<ConnectorViewModel>();
        private readonly List<ElementsConnectionViewModel> _activeConnections = new List<ElementsConnectionViewModel>();
        #endregion

        #region Commands
        public ICommand SelectCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand BringToFrontCommand { get; private set; }
        #endregion


        #region Properties

        public IEnumerable<ConnectorViewModel> Connectors
        {
            get { return _connectors; }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(nameof(Width));
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                NotifyOfPropertyChange(nameof(Height));
            }
        }

        public double Left
        {
            get { return _left; }
            set
            {
                if (value > 0)
                {
                    LocationChagnedEventArgs args = new LocationChagnedEventArgs(0,value - Left);
                    _left = value;
                    NotifyLocationChanged(args);
                    NotifyOfPropertyChange(nameof(Left));
                }

            }
        }

        public double Top
        {
            get { return _top; }
            set
            {
                if (value > 0)
                {
                    LocationChagnedEventArgs args = new LocationChagnedEventArgs(value - Top, 0);
                    _top = value;
                    NotifyLocationChanged(args);
                    NotifyOfPropertyChange(nameof(Top));
                }

            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(nameof(IsSelected));
            }
        }

        public int ItemZIndex
        {
            get { return _itemZIndex; }
            set
            {
                _itemZIndex = value;
                NotifyOfPropertyChange(nameof(ItemZIndex));
            }
        }

        public bool IsConnectorVisible
        {
            get { return _isConnectorVisible; }
            set
            {
                _isConnectorVisible = value;
                NotifyOfPropertyChange(nameof(IsConnectorVisible));
            }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(nameof(IsVisible));
            }
        }


        public virtual bool IsSelectableByUser { get { return true; } }

        public double MinHeight { get; set; }
        public double MinWidth { get; set; }
        protected abstract HashSet<Type> ApplicableTypes { get; }
        public IBaseElement BaseElement { get; private set; }
        #endregion


        #region Abstract
        protected abstract IBaseElement CreateElement();
        #endregion

        #region Events

        public event EventHandler<EventArgs> ElementDeleted;
        public event EventHandler<LocationChagnedEventArgs> LocationChanged;

        private void NotifyLocationChanged(LocationChagnedEventArgs args)
        {
            LocationChanged?.Invoke(this, args);
        }


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
        }

        private void BaseElementViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DimensionProperties.Contains(e.PropertyName))
            {
                DimensionChanged();
            }
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
        /// Checks if connectiom between items can be made
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public virtual bool IsTypeApplicable(Type objectType)
        {
            bool isApplicable = ApplicableTypes.Contains(objectType);
            return isApplicable;
        }

        public void AddConenctor(ConnectorViewModel connector)
        {
            _connectors.Add(connector);
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



        #region Factory

        public static BaseElementViewModel GetViewModel(Type elementType, DocumentViewModel documentViewModel)
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
            viewModel.BaseElement = viewModel.CreateElement();
            viewModel.Height = attribute.InitialSize.Height;
            viewModel.Width = attribute.InitialSize.Width;
            return viewModel;
        }

        public bool CanMove { get { return IsSelected; } }

        #endregion

    }
}
