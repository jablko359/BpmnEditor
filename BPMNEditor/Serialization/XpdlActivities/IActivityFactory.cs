using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BPMNCore;
using BPMNEditor.Models.Elements;
using XPDL.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public interface IActivityFactory
    {
        Activity CreateActivity(IBaseElement baseElement);
    }
}
