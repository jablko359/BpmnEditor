using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.ViewModels
{

    /// <summary>
    /// Fills DocumentViewModel based on document Model
    /// </summary>
    class DocumentViewModelBuilder
    {
        private readonly Dictionary<Guid, BaseElementViewModel> _viewModelDictionary = new Dictionary<Guid, BaseElementViewModel>();
        private readonly Dictionary<Guid, PoolViewModel> _poolViewModelsDictionary = new Dictionary<Guid, PoolViewModel>();
        private readonly List<BaseElementViewModel> _viewModels = new List<BaseElementViewModel>();

        public DocumentViewModel DocumentViewModel { get; private set; }

        public DocumentViewModelBuilder(DocumentViewModel viewModel)
        {
            DocumentViewModel = viewModel;
        }

        public void Fill()
        {
            //TODO: Refactor
            PoolElement mainPoolElement = DocumentViewModel.Document.MainPoolElement;

            foreach (IBaseElement baseElement in mainPoolElement.Elements)
            {
                VisualElement visualElement = baseElement as VisualElement;
                BaseElementViewModel baseViewModel = BaseElementViewModel.GetViewModel(visualElement, DocumentViewModel);
                _viewModelDictionary.Add(visualElement.Guid, baseViewModel);
                _viewModels.Add(baseViewModel);
            }
            foreach (ConnectionElement connection in mainPoolElement.Connections)
            {
                BaseElementViewModel start = null;
                BaseElementViewModel end = null;
                if (_viewModelDictionary.TryGetValue(connection.SourceElement.Guid, out start) &&
                    _viewModelDictionary.TryGetValue(connection.TargetElement.Guid, out end))
                {
                    Point startPoint = new Point();
                    Point endPoint = new Point();
                    if (connection.Points.Count >= 2)
                    {
                        startPoint = connection.Points[0];
                        endPoint = connection.Points.Last();
                    }

                    ElementsConnectionViewModel connectionViewModel = new ElementsConnectionViewModel(
                        DocumentViewModel, connection, start, end, startPoint, endPoint);
                    _viewModels.Add(connectionViewModel);
                }
            }
            foreach (PoolElement poolElement in DocumentViewModel.Document.Pools)
            {
                PoolViewModel poolViewModel = new PoolViewModel(DocumentViewModel, poolElement);
                _poolViewModelsDictionary.Add(poolElement.Guid, poolViewModel);
                _viewModels.Add(poolViewModel);
                foreach (IBaseElement baseElement in poolElement.Elements)
                {
                    VisualElement visualElement = baseElement as VisualElement;
                    BaseElementViewModel baseViewModel = BaseElementViewModel.GetViewModel(visualElement, DocumentViewModel);
                    PoolElementViewModel poolElementViewModel = baseViewModel as PoolElementViewModel;
                    poolElementViewModel.Pool = poolViewModel;
                    poolViewModel.Elements.Add(poolElementViewModel);
                    _viewModelDictionary.Add(visualElement.Guid, baseViewModel);
                    _viewModels.Add(baseViewModel);
                }
                foreach (ConnectionElement connection in poolElement.Connections)
                {
                    BaseElementViewModel start = null;
                    BaseElementViewModel end = null;
                    if (_viewModelDictionary.TryGetValue(connection.SourceElement.Guid, out start) &&
                        _viewModelDictionary.TryGetValue(connection.TargetElement.Guid, out end))
                    {
                        Point startPoint = new Point();
                        Point endPoint = new Point();
                        if (connection.Points.Count >= 2)
                        {
                            startPoint = connection.Points[0];
                            endPoint = connection.Points.Last();
                        }

                        ElementsConnectionViewModel connectionViewModel = new ElementsConnectionViewModel(
                            DocumentViewModel, connection, start, end, startPoint, endPoint);
                        _viewModels.Add(connectionViewModel);
                    }
                }
            }
            DocumentViewModel.BaseElements = new ObservableCollection<BaseElementViewModel>(_viewModels);
        }


    }
}
