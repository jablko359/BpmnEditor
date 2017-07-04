namespace BPMNCore.DragAndDrop
{
    public interface IResizable
    {
        double Width { get; set; }
        double Height { get; set; }
        double Left { get; set; }
        double Top { get; set; }
        double MinHeight { get; set; }
        double MinWidth { get; set; }
    }
}