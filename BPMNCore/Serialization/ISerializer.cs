using System.IO;
using BPMNCore.Elements;

namespace BPMNCore.Serialization
{
    public interface ISerializer
    {
        void Serialize(Document document, Stream stream);

        Document Deserialize(Stream stream);
    }
}
