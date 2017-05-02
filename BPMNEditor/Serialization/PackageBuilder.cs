using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;
using Pool = BPMNEditor.Xpdl.Pool;

namespace BPMNEditor.Serialization
{
    class PackageBuilder
    {
        private Document _document;

        public PackageType Package { get; private set; }

        /// <summary>
        /// Initializes Package name based on document
        /// </summary>
        /// <param name="document"></param>
        public void FromDocument(Document document)
        {
            _document = document;
            Package = new PackageType();
            Package.Name = document.Name;
            Package.Id = _document.Guid.ToString();
        }
        /// <summary>
        /// Add Package Header to Package
        /// </summary>
        public void CreateHeader()
        {
            PackageHeader header = new PackageHeader();
            header.XPDLVersion = new XPDLVersion()
            {
                Value = XpdlInfo.Version
            };
            header.Vendor = new Vendor()
            {
                Value = Assembly.GetExecutingAssembly().GetName().Name
            };
            //To Utc date time format
            header.Created = new Created()
            {
                Value = _document.CreatedOn.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")
            };
            Package.PackageHeader = header;
        }

        public void SetPools()
        {
            Pools pools = new Pools();
            pools.Pool = new Pool[_document.Pools.Count + 1];
            Pool mainPool = new Pool();
            mainPool.BoundaryVisible = false;
            mainPool.Id = _document.MainPool.Guid.ToString();
            mainPool.Process = _document.MainProcessGuid.ToString();
            pools.Pool[0] = mainPool;
            for (int i = 0; i < _document.Pools.Count; i++)
            {
                
            }

        }
    }
}
