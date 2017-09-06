using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public abstract class PoolElementViewModel : BaseElementViewModel
    {
        private PoolViewModel _pool;

        public string Name
        {
            get { return BaseElement?.Name; }
            set
            {
                if (BaseElement != null)
                {
                    BaseElement.Name = value;
                    NotifyOfPropertyChange(nameof(Name));
                }
            }
        }


        [Browsable(false)]
        public PoolViewModel Pool
        {
            get { return _pool; }
            set
            {
                PoolElement poolElement = null;
                if (_pool == null)
                {
                    poolElement = Document.Document.MainPoolElement;
                }
                else
                {
                    poolElement = _pool.BaseElement as PoolElement;
                }
                poolElement?.Elements.Remove(BaseElement);
                List<ConnectionElement> connections =
                    poolElement.Connections.Where(
                        item => item.SourceElement == BaseElement || item.TargetElement == BaseElement).ToList();
                poolElement.Connections.RemoveAll(
                    item => item.SourceElement == BaseElement || item.TargetElement == BaseElement);
                if (value != null)
                {
                    var newPool = value.BaseElement as PoolElement;
                    newPool.Connections.AddRange(connections);
                }
                _pool = value;
            }
        }

        protected PoolElementViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            this.ElementDeleted += PoolElementViewModel_ElementDeleted;
        }

        private void PoolElementViewModel_ElementDeleted(object sender, EventArgs e)
        {
            if (Pool != null)
            {
                Pool.RemoveElement(this);
            }
            else
            {
                this.Document.Document.MainPoolElement.Elements.Remove(BaseElement);
            }

        }

        protected override void DimensionChanged()
        {
            var objectRect = Helper.GetRect(this);
            var currentPool = Pool;
            if (Pool != null)
            {
                var poolRect = Helper.GetRect(Pool);
                if (poolRect.Contains(objectRect))
                {
                    return;
                }
                else
                {
                    currentPool.RemoveElement(this);
                    Pool = null;
                }
            }

            //Check if is inside new pool

            foreach (BaseElementViewModel baseElement in Document.BaseElements)
            {
                PoolViewModel pool = baseElement as PoolViewModel;
                if (pool != null)
                {
                    var poolRect = Helper.GetRect(pool);
                    if (poolRect.Contains(objectRect))
                    {
                        if (currentPool != null)
                        {
                            currentPool.RemoveElement(this);
                        }
                        pool.AddElement(this);
                        Pool = pool;
                        break;
                    }
                }

            }
        }
    }
}
