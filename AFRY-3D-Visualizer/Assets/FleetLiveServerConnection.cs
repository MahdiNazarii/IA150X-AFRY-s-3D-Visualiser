//using MCSData.FleetLive.Entities.Status;
using System;
using System.Collections.Generic;
using System.Reflection;
//using MCSData.Shared.Utils;
//using MCSData.Shared.Extensions;
using Microsoft.Extensions.Logging;

/* Unmerged change from project 'MCSData.FleetLive (net6.0)'
Before:
using MCSData.FleetLive.Interfaces;
After:
using MCSData.FleetLive.Interfaces;
using MCSData.FleetLive.Communication;
using MCSData;
using MCSData.FleetLive;
*/
//using MCSData.FleetLive.Interfaces;
//using MCSData.Shared;
using System.Timers;
using System.Threading;
using MCSData.Communication;
using UnityEngine;

namespace MCSData.FleetLive.Communication
{
    public class FleetLiveServerConnection : MonoBehaviour
    {
        //private readonly ILogger<FleetLiveServerConnection> _logger;

        //Changed from IserverConnection to DRFConnection
        private readonly DRFConnection connection;

        //private readonly Dictionary<int, MachineStatusUpdate> _latestMacStatusUpdate = new Dictionary<int, MachineStatusUpdate>();
        private readonly Dictionary<int, MachinePositionUpdate> _latestMacPosUpdate = new Dictionary<int, MachinePositionUpdate>();
        //private readonly Dictionary<int, MachineAttachUpdate> _latestMacAttachUpdate = new Dictionary<int, MachineAttachUpdate>();

        public event EventHandler StatusUpdate;

        private System.Timers.Timer _timer;

        // public FleetLiveServerConnection(ILogger<FleetLiveServerConnection> logger, ILoggerFactory loggerFactory, ServerConnectionType connectionType)
        // {
        //     _logger = logger;
        //     switch (connectionType)
        //     {
        //         case ServerConnectionType.DRF:
        //             connection = new DRFConnection(loggerFactory.CreateLogger<DRFConnection>());
        //             break;
        //         case ServerConnectionType.G2:
        //         default:
        //             connection = new G2Connection(loggerFactory.CreateLogger<G2Connection>());
        //             break;
        //     }
        //     //connection.RegisterCallback(this, "OPTU-MACHINE-STATUS", GetMethodInfo(nameof(MachineStatusUpdate)));
        //     connection.RegisterCallback(this, "OPTU-MACHINE-POSITION", GetMethodInfo(nameof(MachinePositionUpdate)));
        //     //connection.RegisterCallback(this, "OPTU-ATTACH-MACHINE-STATUS", GetMethodInfo(nameof(MachineAttachUpdate)));
        //     //connection.RegisterCallback(this, "OPTU-DETACH-MACHINE-STATUS", GetMethodInfo(nameof(MachineDetachUpdate)));
        // }
        public FleetLiveServerConnection()
        {
            connection = new DRFConnection();

            //connection.RegisterCallback(this, "OPTU-MACHINE-STATUS", GetMethodInfo(nameof(MachineStatusUpdate)));
            connection.RegisterCallback(this, "OPTU-MACHINE-POSITION", GetMethodInfo(nameof(MachinePositionUpdate)));
            //connection.RegisterCallback(this, "OPTU-ATTACH-MACHINE-STATUS", GetMethodInfo(nameof(MachineAttachUpdate)));
            //connection.RegisterCallback(this, "OPTU-DETACH-MACHINE-STATUS", GetMethodInfo(nameof(MachineDetachUpdate)));
        }

        internal bool Connect(string hostname)
        {
            try
            {
                bool success = connection.ConnectToServer(hostname);
                if (success)
                {
                    //_logger.LogInformation("Successfully connected to MCS at: {0}", hostname);
                    Debug.Log("Successfully connected to MCS at: {0}" + hostname);
                    InitializeConnection();
                    StartHeartbeat();
                }
                else
                {
                    //_logger.LogWarning("Unable to connected to MCS at: {0}", hostname);
                    Debug.Log("Successfully connected to MCS at: {0}" + hostname);
                }
                return success;
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Unable to connect to MCS server: {hostname}", hostname);
                Debug.Log(e + "Unable to connect to MCS server: {hostname}" + hostname);
                return false;
            }
            
        }

        internal void Disconnect()
        {
            try
            {
                //_logger.LogInformation("Logging off from MCS");
                try
                {
                    connection.Call("OPTU-VIEW-LOGOFF", new object[0]);
                }
                catch (Exception e)
                {
                    //_logger.LogError(e, "An error occured when logging of view station");
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "An error occured when disconnecting MCS server connection");
            }
            
        }


        private void StartHeartbeat()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 800;
            _timer.Elapsed += HeartBeat;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void HeartBeat(object sender, ElapsedEventArgs eea)
        {
            try
            {
                if ((int)connection.Call("OPTU-HEARTBEAT", new object[0]) == 0)
                {
                    InitializeConnection();
                }
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "An error occured when checking heartbeat. Try again in 5 sec");
                Thread.Sleep(5000);
            }
        }

        private void InitializeConnection()
        {
            connection.Call("OPTU-VIEW-LOGON", new object[] { "MCSDATA", Environment.MachineName });
            connection.Call("OPTU-INITIALISE", new object[] { });
        }

        private bool MachinePositionUpdate(IList<object> machine)
        {
            try
            {
                int area_id = (int)machine[0];
                int zone_id = (int)machine[1];
                int machine_id = (int)machine[2];

                double x_pos = (double)machine[3];
                double y_pos = (double)machine[4];
                double front_heading = (double)machine[5];
                double rear_heading = (double)machine[6];

                double currSpeed = 0;
                if (machine.Count >= 10)
                {
                    currSpeed = (double)machine[8];
                }
                int currLevel = -1;
                if (machine.Count >= 11)
                {
                    currLevel = (int)machine[10];
                }
                
              
                var status = new MachinePositionUpdate()
                {
                    AreaId = area_id,
                    ZoneId = zone_id,
                    MachineId = machine_id,
                    XPos = x_pos,
                    YPos = y_pos,
                    FrontHeading = front_heading,
                    RearHeading = rear_heading,
                    Speed = currSpeed,
                    Level = currLevel
                };

                lock (_latestMacPosUpdate)
                {
                    _latestMacPosUpdate[machine_id] = status;
                }

                StatusUpdate.Invoke(connection.ServerName, status);
            }
            catch (Exception e)
            {
                //_logger.LogError(e,"Recieved position status from G2. Unable to update machine position");
                return false;
            }

            return true;
        }

        /*private bool MachineStatusUpdate(IList<object> machine)
        {
            try
            {

                int area_id = (int)machine[0];
                int zone_id = (int)machine[1];
                int machine_id = (int)machine[2];
                int intstatus = (int)machine[3];
                int extstatus = (int)machine[4];
                bool blocked = (bool)machine[5];

                var status = new MachineStatusUpdate()
                {
                    AreaId = area_id,
                    ZoneId = zone_id,
                    MachineId = machine_id,
                    IntStatus = intstatus,
                    ExtStatus = extstatus,
                    Blocked = blocked
                };

                lock (_latestMacStatusUpdate)
                {
                    _latestMacStatusUpdate[machine_id] = status;
                }
                StatusUpdate?.Invoke(connection.ServerName, status);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Recieved machine status from G2. Unable to update machine status");
                return false;
            }

            return true;
        }*/

        /* private bool MachineAttachUpdate(int zoneId, int machineId, int areaId)
        {
            try
            {
                _logger.LogInformation("Received machine attach update. Mac: {0}, Area: {1}, Zone: {2}", machineId, areaId, zoneId);
                var status = new MachineAttachUpdate()
                {
                    AreaId = areaId,
                    ZoneId = zoneId,
                    MachineId = machineId,
                };
                lock (_latestMacAttachUpdate)
                {
                    _latestMacAttachUpdate[machineId] = status;
                }
                _logger.LogInformation("Received machine attach update. Mac: {0}, Area: {1}, Zone: {2}", machineId, areaId, zoneId);
                StatusUpdate?.Invoke(connection.ServerName, status);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Recieved attach status from G2. Unable to update machine attach");
                return false;
            }

            return true;
        } */

        /* private bool MachineDetachUpdate(int zoneId, int machineId, int areaId)
        {
            try
            {
                var status = new MachineDetachUpdate()
                {
                    AreaId = areaId,
                    ZoneId = zoneId,
                    MachineId = machineId,
                };
                _logger.LogInformation("Received machine detach update. Mac: {0}, Area: {1}, Zone: {2}", machineId, areaId, zoneId);
                lock (_latestMacAttachUpdate)
                {
                    _latestMacAttachUpdate.Remove(machineId);
                }
                StatusUpdate?.Invoke(connection.ServerName, status);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Recieved detach status from G2. Unable to update machine detach");
                return false;
            }

            return true;
        } */

        private MethodInfo GetMethodInfo(string name)
        {
            return GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
        }


        // public void Dispose()
        // {
        //     _timer.Stop();
        //     _timer.Dispose();
        //     Disconnect();
        //     //connection.Dispose();
        // }

        // public IReadOnlyCollection<MachineAttachUpdate> GetLatestMachinesAttachUpdate()
        // {
        //     lock(_latestMacAttachUpdate)
        //     {
        //         return _latestMacAttachUpdate.Values.AsReadOnly();
        //     }
        // }

        // public IReadOnlyCollection<MachinePositionUpdate> GetLatestMachinesPositionUpdate()
        // {
        //     lock(_latestMacPosUpdate)
        //     {
        //         return _latestMacPosUpdate.Values.AsReadOnly();
        //     }
        // }

        // public IReadOnlyCollection<MachineStatusUpdate> GetLatestMachinesStatusUpdate()
        // {
        //     lock(_latestMacStatusUpdate)
        //     {
        //         return _latestMacStatusUpdate.Values.AsReadOnly();
        //     }
        // }
    }
}