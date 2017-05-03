using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization
{
    public class XpdlSerializer : ISerializer
    {

        public void Serialize(Document document, Stream stream)
        {
            PackageBuilder builder = new PackageBuilder();
            builder.FromDocument(document);
            builder.CreateHeader();
            builder.SetPools();
            XmlSerializer serializer = new XmlSerializer(typeof(PackageType));
            StreamWriter writter = new StreamWriter(stream,Encoding.UTF8);
            serializer.Serialize(writter, builder.Package);
        }
    }

    public static class XpdlInfo
    {
        public const string Version = "2.2";
        public const string Format = "xpdl";
        public const string FormatInfo = "XML Process Definition Language";


        public static string GetFileFilter()
        {
            return string.Format("{0} | *.{1}", FormatInfo, Format);
        }
    }

}
