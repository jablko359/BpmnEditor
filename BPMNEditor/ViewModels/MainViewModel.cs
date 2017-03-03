using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels.Command;


namespace BPMNEditor.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        #region Private members
        private const string ElementsNamespace = "BPMNEditor.Models.Elements";
        private bool _isToolboxVisible = true;

        #endregion

        #region Properties

        public ObservableCollection<ElementCreatorViewModel> Elements { get; private set; }
        public DocumentViewModel Document { get; private set; }
        public ICommand ToggleToolboxCommand { get; private set; }

        public bool IsToolBoxVisible
        {
            get { return _isToolboxVisible; }
            set
            {
                _isToolboxVisible = value;
                NotifyOfPropertyChange(nameof(IsToolBoxVisible));
            }
        }



        #endregion

        #region Constructor and initialize

        public MainViewModel()
        {
            Elements = new ObservableCollection<ElementCreatorViewModel>();
            Document = new DocumentViewModel();
            ToggleToolboxCommand = new RelayCommand(TriggerToolbox);
            ReadAvailableElements();
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

        #endregion


    }
}
