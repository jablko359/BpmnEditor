using System;

namespace BPMNCore
{
    public interface IBaseElement
    {
        Guid Guid { get; set; }
        string GetId();
        string Name { get; set; }
    }
}
