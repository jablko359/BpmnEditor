using System.IO;
using System.Text;
using System.Xml.Serialization;
using BPMNCore.Elements;
using XPDL.Xpdl;

namespace BPMNCore.Serialization
{
    public class XpdlSerializer : ISerializer
    {

        public void Serialize(Document document, Stream stream)
        {
            PackageBuilder builder = new PackageBuilder();
            builder.FromDocument(document);
            builder.CreateHeader();
            builder.SetPools();
            builder.SetProcesses();
            XmlSerializer serializer = new XmlSerializer(typeof(PackageType));
            StreamWriter writter = new StreamWriter(stream,Encoding.UTF8);
            serializer.Serialize(writter, builder.Package);
        }

        public Document Deserialize(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PackageType));
            PackageType package = serializer.Deserialize(stream) as PackageType;
            DocumentBuilder builder = new DocumentBuilder();
            builder.FromPackage(package);
            return builder.Document;
        }
    }
}
