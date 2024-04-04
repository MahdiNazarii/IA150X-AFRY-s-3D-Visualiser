using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _VehicleID;
    [SerializeField]
    private TextMeshProUGUI _AllVehicleIDs;
    private int _VehicleCount = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        _AllVehicleIDs.text = "Vehicle " + 0;
        for (int i = 1; i < _VehicleCount; i++)
        {
            _AllVehicleIDs.text += "\nVehicle " + i;
        }


    }
    public void ActivateLockedViewUI(long id)
    {
        _VehicleID.text = "Vehicle " + id;
        _AllVehicleIDs.enabled = false;
        _VehicleID.enabled = true;
        


    }
    public void ActivateFlyingViewUI()
    {
        _VehicleID.enabled = false;
        _AllVehicleIDs.enabled = true;

    }
}
