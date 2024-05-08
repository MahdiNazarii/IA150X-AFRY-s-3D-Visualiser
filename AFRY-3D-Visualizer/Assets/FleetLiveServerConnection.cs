using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Logging;
using System.Timers;
using System.Threading;
using MCSData.Communication;
using UnityEngine;

namespace MCSData.FleetLive.Communication
{
    public class FleetLiveServerConnection : MonoBehaviour
    {
        private readonly DRFConnection connection;

        private readonly Dictionary<int, MachinePositionUpdate> _latestMacPosUpdate = new Dictionary<int, MachinePositionUpdate>();
    
        public event EventHandler StatusUpdate;

        private System.Timers.Timer _timer;

       
        public FleetLiveServerConnection()
        {
            connection = new DRFConnection();

            connection.RegisterCallback(this, "OPTU-MACHINE-POSITION", GetMethodInfo(nameof(MachinePositionUpdate)));
        }


        internal bool Connect(string hostname)
        {
            try
            {
                bool success = connection.ConnectToServer(hostname);
                if (success)
                {
                    Debug.Log("Successfully connected to MCS at: {0}" + hostname);
                    InitializeConnection();
                    StartHeartbeat();
                }
                else
                {
                    Debug.Log("Successfully connected to MCS at: {0}" + hostname);
                }
                return success;
            }
            catch(Exception e)
            {
                Debug.Log(e + "Unable to connect to MCS server: {hostname}" + hostname);
                return false;
            }
            
        }

        internal void Disconnect()
        {
            try
            {
                try
                {
                    connection.Call("OPTU-VIEW-LOGOFF", new object[0]);
                }
                catch (Exception e)
                {
                    //_logger.LogError(e, "An error occured when logging of view station");
                    Debug.Log(e + "An error occured when logging of view station");
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "An error occured when disconnecting MCS server connection");
                Debug.Log(e + "An error occured when disconnecting MCS server connection");
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
            connection.Call("OPTU-VIEW-LOGON", new object[] { "3D-Visualizer", Environment.MachineName });
            connection.Call("OPTU-INITIALISE", new object[] { });
        }

        private bool MachinePositionUpdate(IList<object> machine)
        {
            try
            {   
                Debug.Log("HELLO");
                GetComponent<VehicleConfiguration>().Test();
                //Debug.Log("machine_id: "+ (int)machine[2] + ", x_pos: " + (double)machine[3] + ", y_pos: " + (double)machine[4]+ ", Angle: "+ (double)machine[5] + ", Level: " + (int)machine[10]);
                //GetComponent<VehicleManager>().UpdateVehicleWithId((int)machine[2],(float)machine[3], (float)machine[4], (float)machine[5], (int)machine[10]);
                //Debug.Log("machine_id: "+ (int)machine[2] + ", x_pos: " + (double)machine[3] + ", y_pos: " + (double)machine[4]+ ", Angle: "+ (double)machine[5] + ", Level: " + (int)machine[10]);

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

     

        private MethodInfo GetMethodInfo(string name)
        {
            return GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
        }

    }
}