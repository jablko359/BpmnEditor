using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.DragAndDrop;


namespace BPMNEditor.ViewModels
{
    public class ElementCreatorViewModel : PropertyChangedBase, IDragable, ITypeProvider
    {
        private readonly Type _elementType;

        public string Name
        {
            get
            {
                string elementName = _elementType.Name;
                return elementName;
            }
        }

        public Type ElementType
        {
            get { return _elementType; }
        }

        public ElementCreatorViewModel(Type elementType)
        {
            _elementType = elementType;
        }

        public Type DataType { get { return typeof(IBaseElement); } }
    }
}
