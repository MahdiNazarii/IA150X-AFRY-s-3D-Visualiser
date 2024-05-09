using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{

    private FleetLiveServerConnection fleetLiveServerConnection;

    private int points=20;
    int index = 0;
    [SerializeField] GameObject[] vehicle;

// <Connection to MCS-Core>
///////////////////////////////////////////////
///
/// 

    int rows = 0;
    int cols = 5;
    float[,] MCSCoreData;
    float[][][] combinedArray = new float[][][] {};
   float[][] v1 = new float[][]
   {
    new float[]{3, 0, 1.4f, 6.0f, 0.1f },
    new float[]{3, 0, 0.82f, 7.7f, 0.1f},
    new float[]{3, 0, 0.24f, 9.4f, 0.1f},
    new float[]{3, 0, -0.34f, 11.1f, 0.1f},
    new float[]{3, 0, -0.92f, 12.8f, 0.1f},
    new float[]{3, 0, -1.5f, 14.5f, 0.1f},
    new float[]{3, 0, -2.08f, 16.2f, 0.1f},
    new float[]{3, 0, -2.66f, 17.9f, 0.1f},
    new float[]{3, 0, -3.24f, 19.6f, 0.1f},
    new float[]{3, 0, -3.82f, 21.3f, 0.1f},
    new float[]{3, 0, -4.4f, 23.0f, 0.1f},
    new float[]{3, 0, -2.22f, 32.07f, 0.1f},
    new float[]{3, 0, -0.04f, 41.14f, 0.1f},
    new float[]{3, 0, 2.14f, 50.21f, 0.1f},
    new float[]{3, 0, 4.32f, 59.28f, 0.1f},
    new float[]{3, 0, 6.5f, 68.35f, 0.1f},
    new float[]{3, 0, 8.68f, 77.42f, 0.1f},
    new float[]{3, 0, 10.86f, 86.49f, 0.1f},
    new float[]{3, 0, 13.04f, 95.56f, 0.1f},
    new float[]{3, 0, 15.22f, 104.63f, 0.1f},
    new float[]{3, 0, 17.4f, 113.7f, 0.1f}
};
    float[][] v3 = new float[][] {
    new float[]{5, 0, 37.8f, 140.7f, -2.094f},
    new float[]{5, 0, 35.51f, 139.08f, -2.094f},
    new float[]{5, 0, 33.22f, 137.46f, -2.094f},
    new float[]{5, 0, 30.93f, 135.84f, -2.094f},
    new float[]{5, 0, 28.64f, 134.22f, -2.094f},
    new float[]{5, 0, 26.35f, 132.6f, -2.094f},
    new float[]{5, 0, 24.06f, 130.98f, -2.094f},
    new float[]{5, 0, 21.77f, 129.36f, -2.094f},
    new float[]{5, 0, 19.48f, 127.74f, -1.094f},
    new float[]{5, 0, 17.19f, 126.12f, -2.618f},
    new float[]{5, 0, 17.02f, 119.92f, -3.24f},
    new float[]{5, 0, 15.87f, 110.66f, -2.818f},
    new float[]{5, 0, 15.22f, 104.63f, -2.818f},
    new float[]{5, 0, 13.04f, 95.56f, -2.818f},
    new float[]{5, 0, 10.86f, 86.49f, -2.818f},
    new float[]{5, 0, 8.68f, 77.42f, -2.818f},
    new float[]{5, 0, 6.5f, 68.35f, -2.818f},
    new float[]{5, 0, 4.32f, 59.28f, -2.818f},
    new float[]{5, 0, 2.14f, 50.21f, -2.818f},
    new float[]{5, 0, -0.04f, 41.14f, -2.818f},
    new float[]{5, 0, -2.22f, 32.07f, -3.24f},
    new float[]{5, 0, -3.82f, 21.3f, -3.24f},
    new float[]{5, 0, -2.08f, 16.2f, -3.24f},
    new float[]{5, 0, -1.5f, 14.5f, -3.24f},
    new float[]{5, 0, 0.24f, 9.4f, -3.24f},
    new float[]{5, 0, 0.82f, 7.7f, -3.24f},
    new float[]{5, 0, 1.4f, 6.0f, -3.24f}
};

    float[][] v2 = {
    new float[] {7, 1, 1.4f, 6.0f, 0.1f},
    new float[] {7, 1, 0.82f, 7.7f, 0.1f},
    new float[] {7, 1, 0.24f, 9.4f, 0.1f},
    new float[] {7, 1, -0.34f, 11.1f, 0.1f},
    new float[] {7, 1, -0.92f, 12.8f, 0.1f},
    new float[] {7, 1, -1.5f, 14.5f, 0.1f},
    new float[] {7, 1, -2.08f, 16.2f, 0.1f},
    new float[] {7, 1, -2.66f, 17.9f, 0.1f},
    new float[] {7, 1, -3.24f, 19.6f, 0.1f},
    new float[] {7, 1, -3.82f, 21.3f, 0.1f},
    new float[] {7, 1, -4.4f, 23.0f, 0.1f},
    new float[] {7, 1, -2.22f, 32.07f, 0.1f},
    new float[] {7, 1, -0.04f, 41.14f, 0.1f},
    new float[] {7, 1, 2.14f, 50.21f, 0.1f},
    new float[] {7, 1, 4.32f, 59.28f, 0.1f},
    new float[] {7, 1, 6.5f, 68.35f, 0.1f},
    new float[] {7, 1, 8.68f, 77.42f, 0.1f},
    new float[] {7, 1, 10.86f, 86.49f, 0.1f},
    new float[] {7, 1, 13.04f, 95.56f, 0.1f},
    new float[] {7, 1, 15.22f, 104.63f, 0.1f},
    new float[] {7, 1, 17.4f, 113.7f, 0.1f}};
    
    float[][] v4 = {
    new float[] {9, 1, 37.8f, 140.7f, -2.094f},
    new float[] {9, 1, 35.51f, 139.08f, -2.094f},
    new float[] {9, 1, 33.22f, 137.46f, -2.094f},
    new float[] {9, 1, 30.93f, 135.84f, -2.094f},
    new float[] {9, 1, 28.64f, 134.22f, -2.094f},
    new float[] {9, 1, 26.35f, 132.6f, -2.094f},
    new float[] {9, 1, 24.06f, 130.98f, -2.094f},
    new float[] {9, 1, 21.77f, 129.36f, -2.094f},
    new float[] {9, 1, 19.48f, 127.74f, -2.094f},
    new float[] {9, 1, 17.19f, 126.12f, -2.618f},
    new float[] {9, 1, 17.02f, 119.92f, -3.24f},
    new float[] {9, 1, 15.87f, 110.66f, -2.818f},
    new float[] {9, 1, 15.22f, 104.63f, -2.818f},
    new float[] {9, 1, 13.04f, 95.56f, -2.818f},
    new float[] {9, 1, 10.86f, 86.49f, -2.818f},
    new float[] {9, 1, 8.68f, 77.42f, -2.818f},
    new float[] {9, 1, 6.5f, 68.35f, -2.818f},
    new float[] {9, 1, 4.32f, 59.28f, -2.818f},
    new float[] {9, 1, 2.14f, 50.21f, -2.818f},
    new float[] {9, 1, -0.04f, 41.14f, -2.818f},
    new float[] {9, 1, -2.22f, 32.07f, -3.24f},
    new float[] {9, 1, -3.82f, 21.3f, -3.24f},
    new float[] {9, 1, -2.08f, 16.2f, -3.24f},
    new float[] {9, 1, -1.5f, 14.5f, -3.24f},
    new float[] {9, 1, 0.24f, 9.4f, -3.24f},
    new float[] {9, 1, 0.82f, 7.7f, -3.24f},
    new float[] {9, 1, 1.4f, 6.0f, -3.24f}
    };
    

    void Start() {
        // initialize the 2D array for the data from MCS-Core
        // rows = VehicleConfiguration.instance.vehicles.Count;
        // MCSCoreData = new float[rows, cols];

        // // fill the 2D array with the data from MCS-Core
        // FillMCSCoreArray();

       // combinedArray = new float[][][] {v1, v2, v3, v4};
       
        //InvokeRepeating("SetVehicleDataEverySecond", 0, 1);

        // Test to connect to the server
        // DRFConnection dRFConnection = new DRFConnection();
        // dRFConnection.ConnectToServer("10.40.109.105");
        // fleetLiveServerConnection = gameObject.AddComponent<FleetLiveServerConnection>();
        // fleetLiveServerConnection.Connect("10.40.109.105");
        //fleetLiveServerConnection.Disconnect();
    }

    void Update()
    {
        if(fleetLiveServerConnection.newDataFlag)
        {
            foreach (KeyValuePair<float, float[]> entry in fleetLiveServerConnection.HashMap)
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
    

   


// OBS: This method will be removed in the final version
    // public void SetVehicleDataEverySecond()
    // {
    //     if (index < points)
    //     {
    //         for (int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
    //         {
    //             float id = combinedArray[i][index][0];
    //             try
    //             {
    //                 UpdateVehicleWithId(id);

    //             }
    //             catch(System.Collections.Generic.KeyNotFoundException e)
    //             {
    //                 Debug.LogError(e);
    //             }
    //         }
    //         index++;
    //     }
    // }



    // public void UpdateVehicleWithId(int id, float x_pos, float y_pos, float angle, int level)
    // {
    //     int length = vehicle.Length;
    //     for (int i = 0; i < length; i++)
    //     {
    //         if (vehicle[i].GetComponent<MetaData>().GetId().Equals((int)id))
    //         {
               
    //             //vehicle[i].GetComponent<coordinateBasedMovement>().MovementSystem(combinedArray[i][index][2], combinedArray[i][index][3], combinedArray[i][index][4], combinedArray[i][index][1]);
                
    //             vehicle[i].GetComponent<coordinateBasedMovement>().MovementSystem(x_pos, y_pos, angle, level);
    //             return;
    //         }
    //     }
    //     throw new System.Collections.Generic.KeyNotFoundException("Vehicle id was not found: " + id);
    // }

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

    
   
