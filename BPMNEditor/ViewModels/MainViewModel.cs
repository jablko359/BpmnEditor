using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using BPMNEditor.Actions;
using BPMNEditor.Models.Elements;
using BPMNEditor.Serialization;
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
        private BaseElementViewModel _propertyEditElement;

        #endregion

        #region Properties

        public ObservableCollection<ElementCreatorViewModel> Elements { get; private set; }
        public ObservableCollection<DocumentViewModel> Documents { get; } = new ObservableCollection<DocumentViewModel>();

        private bool _isSettingsEditorVisible;

        public bool IsSettingsEditorVisible
        {
            get { return _isSettingsEditorVisible; }
            set
            {
                _isSettingsEditorVisible = value;
                NotifyOfPropertyChange(nameof(IsSettingsEditorVisible));
            }
        }


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

        public BaseElementViewModel PropertyEditElement
        {
            get { return _propertyEditElement; }
            set
            {
                _propertyEditElement = value;
                NotifyOfPropertyChange(nameof(PropertyEditElement));
            }
        }
            


        public ICommand AddDocumentCommand { get; private set; }
        public ICommand ToggleToolboxCommand { get; private set; }
        public ICommand UndoCommand { get; private set; }
        public ICommand RedoCommand { get; private set; }
        public ICommand RedoUntilCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        #endregion

        #region Constructor and initialize

        public MainViewModel()
        {
            Elements = new ObservableCollection<ElementCreatorViewModel>();
            AddNewDocument();
            ToggleToolboxCommand = new RelayCommand(TriggerToolbox);
            ReadAvailableElements();
            
            AddDocumentCommand = new RelayCommand(x => AddNewDocument());
            UndoCommand = new RelayCommand(x => Revert());
            RedoCommand = new RelayCommand(x => Redo());
            RedoUntilCommand = new RelayCommand(x => Redo(x as IAction));
            SaveCommand = new RelayCommand(x => Save());
        }

        private void Document_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == ActiveDocument)
            {
                PropertyEditElement = e.SelectedItem;
            }
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

        public void RemoveDocument(DocumentViewModel document)
        {
            if (document != null)
            {
                document.SelectionChanged -= Document_SelectionChanged;
                Documents.Remove(document);
            }
        }

        private void AddNewDocument()
        {
            var document = new DocumentViewModel();
            document.SelectionChanged += Document_SelectionChanged;
            Documents.Add(document);
        }

        private void Revert()
        {
            ActiveDocument?.Undo();
        }

        private void Redo()
        {
            ActiveDocument?.Redo();
        }

        private void Redo(IAction action)
        {
            ActiveDocument?.Redo(action);
        }

        private void Save()
        {
            SaveFileDialog file = new SaveFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                ISerializer serializer = new XpdlSerializer();
                Document document = Document.FromViewModel(_activeDocument);
                using (var outputStream = file.OpenFile())
                {
                    serializer.Serialize(document, outputStream);
                }
            }
            
        }
        #endregion


    }
}
