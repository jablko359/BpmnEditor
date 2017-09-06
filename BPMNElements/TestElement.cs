using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNElements.Properties;
using XPDL.Xpdl;

namespace BPMNElements
{
    [CustomModel]
    [ToolboxVisibile]
    [ActivityMapper(typeof(Implementation), typeof(ExampleActivityMapper), "ExampleActivityMapper")]
    [XpdlActivityFactory(typeof(ExampleActivityMapper))]
    [ToolboxPresenter(typeof(ExampleElementViewProvider))]
    public class ExampleElement : CustomVisualElement, INotifyPropertyChanged
    {
        private string _Example;

        public string Text
        {
            get { return _Example; }
            set
            {
                _Example = value;
                OnPropertyChanged(nameof(Text));
            }
        }


        public ExampleElement()
        {
            Height = 200;
            Width = 100;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
