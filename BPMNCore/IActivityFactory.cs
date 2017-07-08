using XPDL.Xpdl;

namespace BPMNCore
{
    public interface IActivityFactory
    {
        Activity CreateActivity(IBaseElement baseElement);
    }
}
