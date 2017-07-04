using XPDL.Xpdl;

namespace BPMNCore.Serialization.XpdlActivities
{
    public interface IActivityFactory
    {
        Activity CreateActivity(IBaseElement baseElement);
    }
}
