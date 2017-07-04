using XPDL.Xpdl;

namespace BPMNCore.Serialization.XpdlActivities
{
    /// <summary>
    /// Creates model base element based on activity Item
    /// </summary>
    public interface IActivityMapper
    {
        IBaseElement CreateElement(object xpdlItem, NodeGraphicsInfos graphicInfo);
    }
}