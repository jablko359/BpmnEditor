using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.ViewModels
{
    public class PoolViewModel : BaseElementViewModel
    {
        public const double InitialWidth = 700;
        public const double InitialHeight = 350;

        private Pool _pool;

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }


        public PoolViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>();
            _name = "Pool";
        }

        protected override HashSet<Type> ApplicableTypes { get; }
        protected override IBaseElement CreateElement()
        {
            _pool = new Pool();
            return _pool;
        }
    }
}
