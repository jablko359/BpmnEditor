using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public abstract class PoolElementViewModel : BaseElementViewModel
    {
        public PoolViewModel Pool { get; set; }

        protected PoolElementViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
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
