using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] _VehicleID;
    [SerializeField]
    private TextMeshProUGUI _AllVehicleIDs;
    private int _VehicleCount;
    private int currentVehicleNumber;

  
    public void ActivateLockedViewUI(int vehicleNumber)
    {
        _VehicleID[currentVehicleNumber].enabled = false;
        _AllVehicleIDs.enabled = false;
        _VehicleID[vehicleNumber].enabled = true;
    }
    public void ActivateFlyingViewUI()
    {
        _VehicleID[currentVehicleNumber].enabled = false;
        _AllVehicleIDs.enabled = true;

    }
}
