using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization
{
    public class XpdlSerializer : ISerializer
    {
        public void Serialize(Document document, Stream stream)
        {
            Console.WriteLine();
        }
    }
}
