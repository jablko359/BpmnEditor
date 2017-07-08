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
    [ActivityMapper(typeof(Implementation), typeof(TestActivityMapper), "TestActivityMapper")]
    [XpdlActivityFactory(typeof(TestActivityMapper))]
    [ToolboxPresenter(typeof(TestElementViewProvider))]
    public class TestElement : CustomVisualElement, INotifyPropertyChanged
    {
        private string _test;

        public string Text
        {
            get { return _test; }
            set
            {
                _test = value;
                OnPropertyChanged(nameof(Text));
            }
        }


        public TestElement()
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
