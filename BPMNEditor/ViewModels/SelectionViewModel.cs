using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public class SelectionViewModel : BaseElementViewModel
    {
        private bool _isVisible;
        private Point _startPoint;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(nameof(IsVisible));
            }
        }

        


        public SelectionViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
        }

        public void Start(Point startPoint)
        {
            _startPoint = startPoint;
            Rect selectedRect = new Rect(_startPoint, new Size(0,0));
            SetDimension(selectedRect);
            IsVisible = true;
        }

        public void Release()
        {
            _startPoint = new Point(0,0);
            Rect selectedRect = new Rect(_startPoint, new Size(0, 0));
            SetDimension(selectedRect);
            IsVisible = false;
        }

        public void ChangeSelection(Point point, IEnumerable<BaseElementViewModel> selectableModels)
        {
            Rect selectedRect = new Rect(_startPoint, point);
            SetDimension(selectedRect);
            Select(selectableModels, selectedRect);
        }

        private void SetDimension(Rect selected)
        {
            Top = selected.Top;
            Left = selected.Left;
            Width = selected.Width;
            Height = selected.Height;
        }

        private void Select(IEnumerable<BaseElementViewModel> selectableModels, Rect selectedRect)
        {
            foreach (BaseElementViewModel model in selectableModels.Where(item => item.IsSelectableByUser))
            {
                Rect itemRect = Helper.GetRect(model);
                if (selectedRect.Contains(itemRect))
                {
                    model.IsSelected = true;
                }
                else
                {
                    model.IsSelected = false;
                }
            }
        }

        #region BaseElementViewModel
        public override bool IsSelectableByUser => false;
        protected override HashSet<Type> ApplicableTypes => new HashSet<Type>();
        protected override IBaseElement CreateElement()
        {
            return null;
        }

        #endregion

    }
}
