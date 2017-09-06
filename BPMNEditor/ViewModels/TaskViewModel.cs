using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPMNCore;
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

        public override bool CanConnect => true;
        

        #endregion



        public TaskViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
           
            //ApplicableTypes = new HashSet<Type>() { typeof(EventElement), typeof(TaskElement), typeof(GatewayElement), typeof(CustomVisualElement) };
        }

        protected override VisualElement CreateElement()
        {
            _taskElement = new TaskElement("Task");
            return _taskElement;
        }

        

        protected override void SetElement(VisualElement element)
        {
            TaskElement taskElement = element as TaskElement;
            _taskElement = taskElement;
            base.SetElement(element);
        }
    }
}
