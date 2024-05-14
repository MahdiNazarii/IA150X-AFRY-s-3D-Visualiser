using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using UnityEngine;
using MCSData.Communication;
using MCSData.FleetLive.Communication;

public class VehicleManager : MonoBehaviour
{

    private FleetLiveServerConnection fleetLiveServerConnection;

    [SerializeField] GameObject[] vehicle;


    
    

    void Start() {
        fleetLiveServerConnection = new FleetLiveServerConnection();
        fleetLiveServerConnection.Connect("10.40.109.105");

    }

    void Update()
    {

        if(fleetLiveServerConnection.newDataFlag)
        {
            foreach (KeyValuePair<int, float[]> entry in fleetLiveServerConnection.HashMap)
            {
                float id = entry.Key;
                float[] values = entry.Value;

                float x_pos = values[0];
                float y_pos = values[1];
                float angle = values[2];
                int level = (int)values[3];
                UpdateVehicleWithId((int)id, x_pos, y_pos, angle, level);
               
            }
            fleetLiveServerConnection.newDataFlag = false;
        }
    }
    



    public void UpdateVehicleWithId(int id, float x_pos, float y_pos, float angle, int level)
    {
        int length = vehicle.Length;
        for (int i = 0; i < length; i++)
        {
            if (vehicle[i].GetComponent<MetaData>().GetId().Equals(id))
            {                
                vehicle[i].GetComponent<CoordinateBasedMovement>().MovementSystem(x_pos, y_pos, angle, level);
                return;
            }
        }
        throw new System.Collections.Generic.KeyNotFoundException("Vehicle id was not found: ");
    }
}

    
   
