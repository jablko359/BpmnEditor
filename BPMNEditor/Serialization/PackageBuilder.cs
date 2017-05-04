using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;
using BPMNEditor.Serialization.XpdlActivities;
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
                Value = XpdlInfo.GetUtcDateTime(_document.CreatedOn)
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

        /// <summary>
        /// Creates Xpdl Lanes based on LaneElements inside pool
        /// </summary>
        /// <param name="poolElement"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add WorkflowProcess based on pools
        /// </summary>
        public void SetProcesses()
        {
            WorkflowProcesses processes = new WorkflowProcesses();
            processes.WorkflowProcess = new ProcessType[_document.Pools.Count + 1];
            processes.WorkflowProcess[0] = GetProcess(_document.MainPoolElement);
            for (int i = 0; i < _document.Pools.Count; i++)
            {
                var pool = _document.Pools[i];
                var processType = GetProcess(pool);
                processes.WorkflowProcess[i + 1] = processType;
            }
            Package.WorkflowProcesses = processes;
        }

        private ProcessType GetProcess(PoolElement poolElement)
        {
            ProcessType processType = new ProcessType();
            processType.Id = poolElement.ProcessGuid.ToString();
            processType.ProcessHeader = new ProcessHeader();
            processType.ProcessHeader.Created = new Created()
            {
                Value = XpdlInfo.GetUtcDateTime(poolElement.CreatedOn)
            };
            processType.Name = poolElement.Name;
            processType.Activities = GetActivities(poolElement.Elements);
            return processType;
        }

        private Activities GetActivities(IList<IBaseElement> baseElements)
        {
            Activities activities = new Activities();
            activities.Activity = new Activity[baseElements.Count];
            int counter = 0;
            foreach (IBaseElement baseElement in baseElements)
            {
                Type type = baseElement.GetType();
                XpdlActivityFactoryAttribute factoryAttribute = type.GetCustomAttribute<XpdlActivityFactoryAttribute>();
                if (factoryAttribute != null)
                {
                    IActivityFactory factory = factoryAttribute.Factory;
                    Activity activity = factory.CreateActivity(baseElement);
                    activities.Activity[counter] = activity;
                    counter++;
                }
            }
            return activities;
        }
        

    }
}
