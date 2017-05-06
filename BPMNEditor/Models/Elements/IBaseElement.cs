using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Models.Elements
{
    public interface IBaseElement
    {
        Guid Guid { get; }
        string GetId();
    }
    /// <summary>
    /// Elements that can be directly placed only into pool (ex. Line)
    /// </summary>
    public interface IPoolElement
    {
    }
    /// <summary>
    /// Elements that can be directly placed into document
    /// </summary>
    public interface IDocumentElement
    {
    }
}
