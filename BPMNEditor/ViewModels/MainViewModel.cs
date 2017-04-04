using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels.Command;
using BPMNEditor.Views.Controls;


namespace BPMNEditor.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        #region Private members
        private const string ElementsNamespace = "BPMNEditor.Models.Elements";
        private bool _isToolboxVisible = true;
        private DocumentViewModel _activeDocument;

        #endregion

        #region Properties

        public ObservableCollection<ElementCreatorViewModel> Elements { get; private set; }
        public ObservableCollection<DocumentViewModel> Documents { get; } = new ObservableCollection<DocumentViewModel>();
        

        public bool IsToolBoxVisible
        {
            get { return _isToolboxVisible; }
            set
            {
                _isToolboxVisible = value;
                NotifyOfPropertyChange(nameof(IsToolBoxVisible));
            }
        }

        public DocumentViewModel ActiveDocument
        {
            get { return _activeDocument; }
            set
            {
                _activeDocument = value;
                NotifyOfPropertyChange(nameof(ActiveDocument));
            }
        }


        public ICommand AddDocumentCommand { get; private set; }
        public ICommand ToggleToolboxCommand { get; private set; }
        public ICommand UndoCommand { get; private set; }
        public ICommand RedoCommand { get; private set; }

        #endregion

        #region Constructor and initialize

        public MainViewModel()
        {
            Elements = new ObservableCollection<ElementCreatorViewModel>();
            Documents.Add(new DocumentViewModel());
            ToggleToolboxCommand = new RelayCommand(TriggerToolbox);
            ReadAvailableElements();
            
            AddDocumentCommand = new RelayCommand(x => AddNewDocument());
            UndoCommand = new RelayCommand(x => Revert());
            RedoCommand = new RelayCommand(x => Redo());
        }

        private void ReadAvailableElements()
        {
            ClassReader reader = new ClassReader(ElementsNamespace, type => typeof(IBaseElement).IsAssignableFrom(type));
            var types = reader.GetTypes();
            foreach (Type type in types)
            {
                ElementCreatorViewModel model = new ElementCreatorViewModel(type);
                Elements.Add(model);
            }
        }

        

        #endregion

        #region Commands

        public void TriggerToolbox(object isVisible)
        {
            IsToolBoxVisible = (bool)isVisible;
        }

        private void AddNewDocument()
        {
            Documents.Add(new DocumentViewModel());
        }

        private void Revert()
        {
            if (ActiveDocument != null)
            {
                ActiveDocument.Undo();
            }
        }

        private void Redo()
        {
            if (ActiveDocument != null)
            {
                ActiveDocument.Redo();
            }
        }
        #endregion


    }
}
