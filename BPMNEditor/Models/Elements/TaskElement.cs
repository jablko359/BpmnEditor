using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Serialization.XpdlActivities;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;
using XPDL.Xpdl;
using Task = XPDL.Xpdl.Task;

namespace BPMNEditor.Models.Elements
{
    [DisplayName("Task")]
    [Draggable(typeof(IDocumentElement))]
    [XpdlActivityFactory(typeof(TaskActivityMapper))]
    [ActivityMapper(typeof(Implementation), typeof(TaskActivityMapper))]
    [ToolboxVisibile]
    [ElementViewModel(typeof(TaskViewModel), TaskViewModel.InitialWidth, TaskViewModel.InitialHeight)]
    public class TaskElement : VisualElement
    {
       
    }
}
