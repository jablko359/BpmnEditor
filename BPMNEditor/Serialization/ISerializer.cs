using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.Serialization
{
    public interface ISerializer
    {
        void Serialize(Document document, Stream stream);

        Document Deserialize(Stream stream);
    }
}
