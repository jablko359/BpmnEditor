using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Serialization.XpdlActivities;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [DisplayName("Task")]
    [Draggable(typeof(IDocumentElement))]
    [XpdlActivityFactory(typeof(TaskActivityFactory))]
    [ToolboxVisibile]
    [ElementViewModel(typeof(TaskViewModel), TaskViewModel.InitialWidth, TaskViewModel.InitialHeight)]
    public class TaskElement : VisualElement
    {
        public string Name { get; set; }
    }
}
