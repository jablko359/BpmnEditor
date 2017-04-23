using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using BPMNEditor.ViewModels;
using BPMNEditor.Views.Controls;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace BPMNEditor.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        private MainViewModel _viewModel;

        public MainView()
        {
            InitializeComponent();
            Loaded += MainView_Loaded;

        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
            if (_viewModel != null)
            {
                if (_viewModel.Documents.Count > 0)
                {
                    AddDocument(_viewModel.Documents[0]);
                }
                _viewModel.Documents.CollectionChanged += DocumentsOnCollectionChanged;
                _viewModel.PropertyChanged += ViewModel_PropertyChanged;
                SetPropertyGridVisibility();
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSettingsEditorVisible")
            {
                SetPropertyGridVisibility();
            }
        }

        private void SetPropertyGridVisibility()
        {
            
                if (_viewModel.IsSettingsEditorVisible)
                {
                    PropertyGrid.Show();
                }
                else
                {
                    PropertyGrid.Hide();
                }
            
        }

        private void DocumentsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        AddDocument(newItem as DocumentViewModel);
                    }
                    break;
            }
        }

        private void AddDocument(DocumentViewModel documentViewModel)
        {
            GraphDocument document = new GraphDocument(documentViewModel);
            document.Closing += Document_Closing;
            LayoutDocumentPane.Children.Add(document);
        }

        private void Document_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show(this, "Do you want to save before exit?", "Close document", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                GraphDocument document = sender as GraphDocument;
                DocumentView view = document.Content as DocumentView;
                _viewModel.RemoveDocument(view.DataContext as DocumentViewModel);
                document.Closing -= Document_Closing;
            }
            
        }

        private void DockingManager_OnActiveContentChanged(object sender, EventArgs e)
        {
            DocumentView document = DockingManager.ActiveContent as DocumentView;
            DocumentViewModel documentViewModel = document?.DataContext as DocumentViewModel;
            if (documentViewModel != null)
            {
                _viewModel.ActiveDocument = documentViewModel;
            }
        }

        
        private void PropertyGrid_OnPropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            PropertyGrid senderElement = sender as PropertyGrid;
            if (senderElement != null)
            {
                var baseElementViewModel = senderElement.SelectedObject as BaseElementViewModel;
                var propertyItem = e.OriginalSource as PropertyItem;
                if (propertyItem != null)
                {
                    baseElementViewModel?.NotifyActionPropertyChagned(propertyItem.PropertyName, e.OldValue, e.NewValue);
                }
            }
            
        }
    }
}
