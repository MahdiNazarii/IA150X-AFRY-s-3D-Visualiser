using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMetaData : MonoBehaviour
{
    public long _VehicleID;

    private void Start()
    {
        _VehicleID = GetInstanceID();
    }
    public long GetID()
    {
        return _VehicleID;
    }

}
