using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Actions
{
    public class ObservableDropoutStack<T> : ObservableCollection<T>
    {
        private readonly int _size;

        public ObservableDropoutStack()
        {
            _size = Int32.MaxValue;
        }

        public ObservableDropoutStack(int size)
        {
            _size = size;
        }

        public void Push(T item)
        {
            this.Insert(0,item);
            if (Count > _size)
            {
                RemoveAt(Count - 1);
            }
        }

        public T Pop()
        {
            if (Count == 0)
            {
                return default(T);
            }
            T result = this[0];
            RemoveAt(0);
            return result;
        }

        

        

        
    }
}
