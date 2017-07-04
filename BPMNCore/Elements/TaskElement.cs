using System.ComponentModel;
using BPMNCore.DragAndDrop;
using BPMNCore.Serialization.XpdlActivities;
using BPMNCore.ViewModels;
using XPDL.Xpdl;

namespace BPMNCore.Elements
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
