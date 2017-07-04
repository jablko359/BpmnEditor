namespace BPMNCore.Actions
{
    public interface IAction
    {
        string Name { get; }
        void Revert();
        IAction GetInverseAction();
    }
}
