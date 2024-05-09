using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DynamicRuntimeFramework.IPC;
using Microsoft.Extensions.Logging;
using UnityEngine;

public class DRFConnection : MonoBehaviour
{

    public bool ServerConnected { get; private set; }
    public string ServerName { get; private set; }
    private bool g2ConnectErrorShown = false;
    private IPCClient m_gateWay;

    public void RegisterCallback(object instance, string name, MethodInfo methodInfo)
    {
        m_gateWay.RegisterCallback(instance, name, methodInfo);
    }


    public DRFConnection(){
        m_gateWay = new IPCClient();
    }

    public bool ConnectToServer(string serverName)
    {
        return ConnectToServer(serverName, 1111);
    }

    public bool ConnectToServer(string serverName, ushort port)
    {
        if (isDisposed) throw new ObjectDisposedException(nameof(DRFConnection));
        //connect to the G2 server
        try
        {
            if (m_gateWay.IPCInterfaceStatus == (int)LinkStatus.Ok)
            {
                m_gateWay.Close();
            }
            m_gateWay.AutoReconnectEnabled = true;
#if DEBUG
            m_gateWay.Hostname = serverName;
            m_gateWay.Port = port;
#else
            m_gateWay.Hostname = serverName;
            m_gateWay.Port = port;
#endif

            bool success = m_gateWay.Connect();

            if (!success || m_gateWay.IPCInterfaceStatus != (int)LinkStatus.Ok)
            {
                if (!g2ConnectErrorShown)
                {
                    //logger?.LogWarning("Unable to connect to DRF");
                    Debug.Log("Could not connect to the server");
                    // MessagePublished($"DRF NOT connected at {m_gateWay.Hostname}:{m_gateWay.Port}");
                    g2ConnectErrorShown = true;
                }
                ServerConnected = false;
            }
            else
            {
                //logger?.LogInformation("Connected to DRF");
                Debug.Log("Connected to the server");
                ServerConnected = true;
                ServerName = serverName;
                g2ConnectErrorShown = false;

            }
        }
        catch (Exception)
        {
            ServerConnected = false;
            throw;
        }
        return ServerConnected;
    }

    protected object[] ParseInputArgumentsObject(MethodInfo method, object InputArguments)
    {
        if (InputArguments == null) return new object[0];
        else if (method == null) return new object[0];
        else
        {
            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                return new object[0];
            }
            else if (parameters.Length == 1)
            {
                return new object[] { InputArguments };
            }
            else
            {
                if (InputArguments is object[])
                {
                    return (object[])InputArguments;

                }
                else if (InputArguments is System.Array)
                {
                    System.Array inputArray = (Array)InputArguments;
                    int length = inputArray.GetLength(0);
                    if (parameters.Length == inputArray.Length)
                    {
                        object[] inputArgs = new object[length];
                        for (int index = 0; index < length; index++)
                        {
                            inputArgs[index] = inputArray.GetValue(index + 1);
                        }
                        return inputArgs;
                    }
                    else
                    {
                        throw new ArgumentException("The number of recived arguments " + length + " doesnt match the number of arguments (" + parameters.Length + ") of the callback method");
                    }
                }
            }
        }
        return new object[0];
    }


    public object Call(string procedureToCall, System.Object[] Arg4G2)
    {
        return Call<object>(procedureToCall, true, Arg4G2);
    }

    public object Call(string procedureToCall, bool showErrMessage, params object[] Arg4G2)
    {
        return Call<object>(procedureToCall, showErrMessage, Arg4G2);
    }


    public TReturn Call<TReturn>(string procedureToCall, bool showErrMessage, params object[] Arg4G2)
    {
        //TODO No active connection
        if (isDisposed) throw new ObjectDisposedException(nameof(DRFConnection));
        try
        {
            if (m_gateWay is null || m_gateWay.IPCInterfaceStatus == (int)LinkStatus.Inactive)
            {
                throw new InvalidOperationException("Unable to execute call. No active connection exists");
            }


            //logger?.LogDebug("Calling DRF procedure: " + procedureToCall);
            Debug.Log("Calling DRF procedure: " + procedureToCall);
            //call the connected G2 server
            return m_gateWay.Call<TReturn>(procedureToCall, Arg4G2);
        }
        catch (Exception e) when (!(e is InvalidOperationException))
        {

            //logger?.LogError("Unable to call DRF procedure: '" + procedureToCall + "'", e);
            //Debug.Log("Unable to call DRF procedure: '" + procedureToCall + "'", e);
            throw;
        }
    }


    public Task<object> CallAsync(string procedureToCall, bool showErrMessage, params object[] Arg4G2)
    {
        return CallAsync<object>(procedureToCall, showErrMessage, Arg4G2);
    }

    public Task<TReturn> CallAsync<TReturn>(string procedureToCall, System.Object[] Arg4G2)
    {
        return CallAsync<TReturn>(procedureToCall, true, Arg4G2);
    }

    public Task<TReturn> CallAsync<TReturn>(string procedureToCall, bool showErrMessage, params object[] Arg4G2)
    {
        //TODO No active connection
        if (isDisposed) throw new ObjectDisposedException(nameof(DRFConnection));
        try
        {
            if (m_gateWay is null || m_gateWay.IPCInterfaceStatus == (int)LinkStatus.Inactive)
            {
                throw new InvalidOperationException("Unable to execute call. No active connection exists");
            }


            // logger?.LogDebug("Calling DRF procedure: " + procedureToCall);
            //call the connected G2 server
            return m_gateWay.CallAsync<TReturn>(procedureToCall, Arg4G2);
        }
        catch (Exception e) when (!(e is InvalidOperationException))
        {

            //logger?.LogError("Unable to call DRF procedure: '" + procedureToCall + "'", e);
            throw;
        }
    }


    public bool IsSystemInSimulationMode()
    {
        try
        {
            bool isMCSInSimulationMode = (bool)Call("app-is-system-in-simulation-mode", false, new object[0]);
            return isMCSInSimulationMode;
        }
        catch (Exception e)
        {
#if DEBUG
            return true;
#else
            logger?.LogWarning("An error occured when trying to determand if DRF is in system simualtion mode", e);
            return false;
#endif
        }
    }

    public void Disconnect()
    {
        if (isDisposed) throw new ObjectDisposedException("DRFConnection");
        //logger?.LogInformation("Disconnecting from DRF");
        m_gateWay.Close();

    }




    bool isDisposed = false;


    public bool isConnected()
    {
        return ServerConnected;
    }

    // ~DRFConnection()
    // {
    //     Dispose(false);
    // }

    private class Callback
    {
        private readonly object _instance;
        public MethodInfo Method { get; }

        public Callback(object instance, MethodInfo method)
        {
            _instance = instance;
            Method = method;
        }

        public object Invoke(object[] args)
        {
            if (Method.IsStatic)
            {
                return Method.Invoke(null, args);
            }
            else
            {
                return Method.Invoke(_instance, args);
            }
        }
    }
}
