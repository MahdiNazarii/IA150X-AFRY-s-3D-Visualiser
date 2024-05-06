using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script sets meta data for a vehicle (HMs)
 */
public class MetaData : MonoBehaviour
{
    int machineId;
    string machineName;
    int machineType;
    int serialNumber;
    int status;
    public Vector3 positionObject;
    public void SetMetaData(int machine_id, string machine_external_id, int machine_type, int serial_number, int status)
    {
        this.machineId = machine_id;
        this.machineName = machine_external_id;
        this.machineType = machine_type;
        this.serialNumber = serial_number;
        this.status = status;
    }
    public int GetId()
    {
        return machineId;
    }
    public string GetMachineName()
    {
        return machineName;
    }

}
