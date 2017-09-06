using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using BPMNCore;
using BPMNEditor.Actions;
using BPMNEditor.Models.Elements;
using BPMNEditor.Properties;
using BPMNEditor.Serialization;
using BPMNEditor.Serialization.XpdlActivities;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels.Command;
using BPMNEditor.Views.Controls;


namespace BPMNEditor.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        #region Private members
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
        public ICommand OpenCommand { get; private set; }

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
            OpenCommand = new RelayCommand(x => Open());
        }

        private void Document_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == ActiveDocument)
            {
                PropertyEditElement = e.SelectedItem;
            }
        }
        /// <summary>
        /// Reads avaliable elements at start
        /// </summary>
        private void ReadAvailableElements()
        {
            ClassReader reader = new ClassReader(null, IsTypeToolboxVisible);
            var types = reader.GetTypes();
            ClassAssemblyReader classAssemblyReader = new ClassAssemblyReader(Settings.Default.Assemblies);
            types.AddRange(classAssemblyReader.GetTypes(IsTypeToolboxVisible));
            foreach (Type type in types)
            {
                ElementCreatorViewModel model = new ElementCreatorViewModel(type);
                ActivityMapperAttribute activityMapperAttribute = type.GetCustomAttribute<ActivityMapperAttribute>();
                activityMapperAttribute?.Register();
                Elements.Add(model);
            }
        }

        public bool IsTypeToolboxVisible(Type type)
        {
            bool isVisible = typeof(IBaseElement).IsAssignableFrom(type) && !type.IsAbstract;
            if (isVisible)
            {
                var attribute = type.GetCustomAttribute<ToolboxVisibileAttribute>();
                if (attribute == null)
                {
                    isVisible = false;
                }
            }
            return isVisible;

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
            Document document = _activeDocument.Document;
            file.FileName = document.Name;
            file.Filter = XpdlInfo.GetFileFilter();
            if (file.ShowDialog() == DialogResult.OK)
            {
                ISerializer serializer = new XpdlSerializer();
                
                using (var outputStream = file.OpenFile())
                {
                    serializer.Serialize(document, outputStream);
                }
            }
            
        }

        private void Open()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = XpdlInfo.GetFileFilter();
            if (file.ShowDialog() == DialogResult.OK)
            {
                ISerializer serialzier = new XpdlSerializer();

                using (var inputStream = file.OpenFile())
                {
                    var document = serialzier.Deserialize(inputStream);
                    DocumentViewModel viewModel = DocumentViewModel.FromModel(document);
                    viewModel.SelectionChanged += Document_SelectionChanged;
                    Documents.Add(viewModel);
                }
            }
        }
        #endregion


    }
}
