using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNCore
{
    public interface IPropertyRemember
    {
        void NotifyActionPropertyChagned(string propertyName, object value);
        void RememberProperty(string propertyName);
    }
}
