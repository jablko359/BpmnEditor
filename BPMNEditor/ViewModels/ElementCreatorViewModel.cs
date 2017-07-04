using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;


namespace BPMNEditor.ViewModels
{
    public class ElementCreatorViewModel : PropertyChangedBase, IDragable, ITypeProvider
    {
        private readonly Type _elementType;
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public Type ElementType
        {
            get { return _elementType; }
        }

        public ElementCreatorViewModel(Type elementType)
        {
            _elementType = elementType;
            SetName();
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

        private void SetName()
        {
            var attr = _elementType.GetCustomAttribute<DisplayNameAttribute>();
            if (attr != null)
            {
                _name = attr.DisplayName;
            }
            else
            {
                _name = _elementType.Name;
            }
            NotifyOfPropertyChange(nameof(Name));

        }

    }
}
