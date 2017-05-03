using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;


namespace BPMNEditor.ViewModels
{
    public class TaskViewModel : PoolElementViewModel
    {
        public const double InitialWidth = 128;
        public const double InitialHeight = 80;

        private TaskElement _taskElement;

        #region Properties

        public string Name
        {
            get { return _taskElement.Name; }
            set
            {
                _taskElement.Name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        #endregion



        public TaskViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
           
            ApplicableTypes = new HashSet<Type>() { typeof(EventElement), typeof(TaskElement), typeof(GatewayElement) };
        }

        protected override IBaseElement CreateElement()
        {
            _taskElement = new TaskElement();
            Name = "Task";
            return _taskElement;
        }

        protected override HashSet<Type> ApplicableTypes { get; }
    }
}
