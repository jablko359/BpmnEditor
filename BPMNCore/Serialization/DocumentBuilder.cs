using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using BPMNCore.Elements;
using BPMNCore.Serialization.XpdlActivities;
using XPDL.Xpdl;

namespace BPMNCore.Serialization
{
    class DocumentBuilder
    {
        public Document Document { get; } = new Document();
        private readonly Dictionary<Guid, PoolElement> _poolByProcessDictionary = new Dictionary<Guid, PoolElement>();
        private readonly Dictionary<Guid, IBaseElement> _elements = new Dictionary<Guid, IBaseElement>();

        public void FromPackage(PackageType package)
        {
            Document.Name = package.Name;
            Document.Guid = Guid.Parse(package.Id);
            ReadHeader(package.PackageHeader);
            ReadPools(package.Pools);
            ReadProcesses(package.WorkflowProcesses);
        }

        private void ReadProcesses(WorkflowProcesses workflowProcesses)
        {
            foreach (ProcessType processType in workflowProcesses.WorkflowProcess)
            {
                Guid processGuid = Guid.Parse(processType.Id);
                PoolElement poolElement = null;
                if (_poolByProcessDictionary.TryGetValue(processGuid, out poolElement))
                {
                    ReadHeader(processType.ProcessHeader, poolElement);
                    ReadActivities(processType.Activities, poolElement);
                }
                ReadTransitions(processType);
            }
        }

        private void ReadTransitions(ProcessType processType)
        {
            if (processType.Transitions?.Transition == null)
            {
                return;
            }
            foreach (var transition in processType.Transitions.Transition)
            {
                var from = transition.From;
                var to = transition.To;
                PoolElement poolElement = null;
                var guid = Guid.Parse(processType.Id);
                if (_poolByProcessDictionary.TryGetValue(guid, out poolElement))
                {
                    try
                    {
                        IBaseElement fromElement = _elements[Guid.Parse(from)];
                        IBaseElement toElement = _elements[Guid.Parse(to)];
                        ConnectionElement connection = new ConnectionElement(fromElement, toElement);
                        connection.Guid = Guid.Parse(transition.Id);
                        List<Point> points = GetPoints(transition.ConnectorGraphicsInfos);
                        connection.Points = points;
                        poolElement.Connections.Add(connection);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        throw new BaseElementNotFoundException(ex);

                    }


                }
            }
        }

        private List<Point> GetPoints(ConnectorGraphicsInfos transitionConnectorGraphicsInfos)
        {
            List<Point> points = new List<Point>();
            if (transitionConnectorGraphicsInfos?.ConnectorGraphicsInfo != null)
            {
                foreach (ConnectorGraphicsInfo connectorGraphicsInfo in transitionConnectorGraphicsInfos.ConnectorGraphicsInfo)
                {
                    if (connectorGraphicsInfo.Coordinates != null)
                    {
                        foreach (Coordinates coordinate in connectorGraphicsInfo.Coordinates)
                        {
                            if (coordinate.XCoordinateSpecified && coordinate.YCoordinateSpecified)
                            {
                                points.Add(new Point(coordinate.XCoordinate, coordinate.YCoordinate));
                            }
                        }
                    }
                }
            }
            return points;
        }

        private void ReadActivities(Activities processTypeActivities, PoolElement poolElement)
        {
            if (processTypeActivities!= null && processTypeActivities.Activity != null)
            {
                foreach (Activity activity in processTypeActivities.Activity)
                {
                    object activityItem = activity.Item;
                    if (activityItem != null)
                    {
                        IActivityMapper mapper = ActivityMapperAttribute.GetMapper(activityItem.GetType());
                        if (mapper != null)
                        {
                            IBaseElement element = mapper.CreateElement(activityItem, activity.NodeGraphicsInfos);
                            element.Name = activity.Name;
                            element.Guid = Guid.Parse(activity.Id);
                            _elements.Add(element.Guid, element);
                            poolElement.Elements.Add(element);
                        }
                        else
                        {
                            throw new MapperNotFoundException(activityItem.GetType());
                        }
                    }
                }
            }

        }


        private void ReadPools(Pools packagePools)
        {
            foreach (Pool pool in packagePools.Pool)
            {
                Guid guid = Guid.Parse(pool.Id);
                Guid processGuid = Guid.Parse(pool.Process);
                PoolElement poolElement = new PoolElement(guid)
                {
                    Name = pool.Name,
                    Guid = guid,
                    ProcessGuid = processGuid
                };
                _poolByProcessDictionary.Add(processGuid, poolElement);
                if (poolElement.Name != XpdlInfo.MainPoolName)
                {
                    SetVisualElementInfo(pool.NodeGraphicsInfos, poolElement);
                    Document.Pools.Add(poolElement);
                }
                else
                {
                    Document.MainPoolElement = poolElement;
                }
                SetLanes(poolElement, pool);
            }
        }

        private void SetLanes(PoolElement poolElement, Pool pool)
        {
            List<Lane> orderedLanes = OrderLanes(pool.Lanes);
            foreach (Lane lane in orderedLanes)
            {
                LaneElement laneElement = new LaneElement();
                laneElement.Name = lane.Name;
                laneElement.Guid = Guid.Parse(lane.Id);
                NodeGraphicsInfo graphicsInfo = GetNodeGraphicsInfo(lane.NodeGraphicsInfos);
                if (graphicsInfo != null)
                {
                    laneElement.Height = graphicsInfo.Height;
                }
                poolElement.Lanes.Add(laneElement);
            }
        }

        private List<Lane> OrderLanes(Lanes poolLanes)
        {
            if (poolLanes.Lane == null)
            {
                return new List<Lane>();
            }
            List<Lane> result = poolLanes.Lane.OrderBy(item => item, new LaneIndexComparer(0.001)).ToList();
            return result;
        }

        private void ReadHeader(ProcessHeader processHeader, PoolElement poolElement)
        {
            if (processHeader?.Created != null)
            {
                DateTime dateTime;
                if (DateTime.TryParse(processHeader.Created.Value, out dateTime))
                {
                    poolElement.CreatedOn = dateTime;
                }
            }
        }

        private void ReadHeader(PackageHeader packageHeader)
        {
            if (packageHeader?.Created != null)
            {
                DateTime dateTime;
                if (DateTime.TryParse(packageHeader.Created.Value, out dateTime))
                {
                    Document.CreatedOn = dateTime;
                }
            }
        }

        public static void SetVisualElementInfo(NodeGraphicsInfos infos, VisualElement element)
        {
            NodeGraphicsInfo info = null;
            foreach (var nodeGraphicsInfo in infos.NodeGraphicsInfo)
            {
                info = nodeGraphicsInfo;
                if (nodeGraphicsInfo.ToolId == Assembly.GetExecutingAssembly().GetName().Name)
                {
                    break;
                }
            }
            if (info != null)
            {
                if (info.HeightSpecified)
                {
                    element.Height = info.Height;
                }
                if (info.WidthSpecified)
                {
                    element.Width = info.Width;
                }
                if (info.Coordinates != null)
                {
                    if (info.Coordinates.XCoordinateSpecified)
                    {
                        element.X = info.Coordinates.XCoordinate;
                    }
                    if (info.Coordinates.YCoordinateSpecified)
                    {
                        element.Y = info.Coordinates.YCoordinate;
                    }
                }
            }

        }



        private static NodeGraphicsInfo GetNodeGraphicsInfo(NodeGraphicsInfos infos)
        {
            NodeGraphicsInfo info = null;
            if (infos != null)
            {
                foreach (var nodeGraphicsInfo in infos.NodeGraphicsInfo)
                {
                    info = nodeGraphicsInfo;
                    if (nodeGraphicsInfo.ToolId == Assembly.GetExecutingAssembly().GetName().Name)
                    {
                        break;
                    }
                }
            }
            return info;
        }

        private class LaneIndexComparer : IComparer<Lane>
        {
            private readonly double _tolerance;

            public LaneIndexComparer(double tolerane)
            {
                _tolerance = tolerane;
            }

            public int Compare(Lane x, Lane y)
            {
                double xYCoordinate = 0;
                double yYCoordinate = 0;
                if (x.NodeGraphicsInfos != null && y.NodeGraphicsInfos != null)
                {
                    var xGraphicInfo = GetNodeGraphicsInfo(x.NodeGraphicsInfos);
                    var yGraphicInfo = GetNodeGraphicsInfo(y.NodeGraphicsInfos);
                    if (xGraphicInfo != null && yGraphicInfo != null)
                    {
                        xYCoordinate = xGraphicInfo.Coordinates.YCoordinate;
                        yYCoordinate = yGraphicInfo.Coordinates.YCoordinate;
                    }
                }
                int result = 0;
                if (Math.Abs(xYCoordinate - yYCoordinate) < _tolerance)
                {
                    return result;
                }
                double difference = xYCoordinate - yYCoordinate;
                if (difference > 0)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                }
                return result;
            }
        }
    }
}
