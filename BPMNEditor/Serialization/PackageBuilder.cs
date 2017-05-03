using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            pools.Pool[0] = CreatePool(_document.MainPoolElement, false);
            for (int i = 0; i < _document.Pools.Count; i++)
            {
                pools.Pool[i + 1] = CreatePool(_document.Pools[i]);
            }
            Package.Pools = pools;

        }
        /// <summary>
        /// Creates xpdl pool based on program pool
        /// </summary>
        /// <param name="poolElement"></param>
        /// <param name="isVisible"></param>
        /// <returns></returns>
        private static Pool CreatePool(PoolElement poolElement, bool isVisible = true)
        {
            Pool result = new Pool();
            result.BoundaryVisible = isVisible;
            result.Id = poolElement.GetId();
            result.Process = poolElement.ProcessGuid.ToString();
            result.Lanes = GetLanes(poolElement);
            result.Name = poolElement.Name;
            result.NodeGraphicsInfos = new NodeGraphicsInfos();
            result.NodeGraphicsInfos.NodeGraphicsInfo = new NodeGraphicsInfo[1];
            result.NodeGraphicsInfos.NodeGraphicsInfo[0] = CreateNodeGraphicsInfo(poolElement);
            return result;
        }

        /// <summary>
        /// Creates NodeGraphicInfo (width,height and coordinates)
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static NodeGraphicsInfo CreateNodeGraphicsInfo(VisualElement element)
        {
            NodeGraphicsInfo info = new NodeGraphicsInfo();
            info.SetSize(element);
            info.ToolId = Assembly.GetExecutingAssembly().GetName().Name;
            return info;
        }

        /// <summary>
        /// Creates NodeGraphic info for lane based on parent position
        /// </summary>
        /// <param name="element"></param>
        /// <param name="parent"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static NodeGraphicsInfo CreateNodeGraphicsInfo(LaneElement element, int index)
        {
            NodeGraphicsInfo info = new NodeGraphicsInfo();
            info.Coordinates = new Coordinates();
            info.Coordinates.YCoordinate = index;
            info.Coordinates.YCoordinateSpecified = true;
            info.Height = element.Height;
            info.HeightSpecified = true;
            info.ToolId = Assembly.GetExecutingAssembly().GetName().Name;
            return info;
        }

        private static Lanes GetLanes(PoolElement poolElement)
        {
            Lanes lanes = new Lanes();
            lanes.Lane = new Lane[poolElement.Lanes.Count];
            for (int i = 0; i < poolElement.Lanes.Count; i++)
            {
                lanes.Lane[i] = new Lane();
                var laneElement = poolElement.Lanes[i];
                lanes.Lane[i].Id = laneElement.GetId();
                lanes.Lane[i].Name = laneElement.Name;
                lanes.Lane[i].ParentPool = poolElement.GetId();
                lanes.Lane[i].NodeGraphicsInfos = new NodeGraphicsInfos();
                lanes.Lane[i].NodeGraphicsInfos.NodeGraphicsInfo = new NodeGraphicsInfo[1];
                lanes.Lane[i].NodeGraphicsInfos.NodeGraphicsInfo[0] = CreateNodeGraphicsInfo(laneElement, i);
                 
            }
            return lanes;
        }

        
    }

    public static class XpdlExtensions
    {
        public static void SetSize(this NodeGraphicsInfo info, VisualElement element)
        {
            info.Height = element.Height;
            info.HeightSpecified = true;
            info.Width = element.Width;
            info.WidthSpecified = true;
            Coordinates coordinates = new Coordinates
            {
                XCoordinate = element.X,
                XCoordinateSpecified = true,
                YCoordinate = element.Y,
                YCoordinateSpecified = true
            };
            info.Coordinates = coordinates;
        }
    }
}
