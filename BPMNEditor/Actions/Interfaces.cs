using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Annotations;

namespace BPMNEditor.Actions
{
    public interface IInsertable
    {
        void AfterInsert();
        void AfterDelete();
    }
}

