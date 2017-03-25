using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
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
            DataType = GetDataType(elementType);
        }

        public Type DataType { get; }

        private static Type GetDataType(Type providedType)
        {
            var attribute = Attribute.GetCustomAttribute(providedType, typeof(DraggableAttribute)) as DraggableAttribute;
            if (attribute == null)
            {
                return typeof(IDocumentElement);
            }
            return attribute.DataType;
        }

    }
}
