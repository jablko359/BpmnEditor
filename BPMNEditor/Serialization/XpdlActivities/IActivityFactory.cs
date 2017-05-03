using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public interface IActivityFactory
    {
        Activity CreateActivity(IBaseElement baseElement);
    }
}
