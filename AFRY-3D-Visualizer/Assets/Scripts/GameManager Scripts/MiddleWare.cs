using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleWare : MonoBehaviour
{
    private int points=20;
    int index = 0;
    
    // the vector containing (id, level, x,z, angle) which represent the data from MCS-Core
   Vector3[] v1 = {
    new Vector3(3,0, 1.4f, 6.0f, 0.1f),
    new Vector3(3,0, 0.82f, 7.7f, 0.1f),
    new Vector3(3,0, 0.24f, 9.4f, 0.1f),
    new Vector3(3,0, -0.34f, 11.1f, 0.1f),
    new Vector3(3,0, -0.92f, 12.8f, 0.1f),
    new Vector3(3,0, -1.5f, 14.5f, 0.1f),
    new Vector3(3,0, -2.08f, 16.2f, 0.1f),
    new Vector3(3,0, -2.66f, 17.9f, 0.1f),
    new Vector3(3,0, -3.24f, 19.6f, 0.1f),
    new Vector3(3,0, -3.82f, 21.3f, 0.1f),
    new Vector3(3,0, -4.4f, 23.0f, 0.1f),
    new Vector3(3,0, -2.22f, 32.07f, 0.1f),
    new Vector3(3,0, -0.04f, 41.14f, 0.1f),
    new Vector3(3,0, 2.14f, 50.21f, 0.1f),
    new Vector3(3,0, 4.32f, 59.28f, 0.1f),
    new Vector3(3,0, 6.5f, 68.35f, 0.1f),
    new Vector3(3,0, 8.68f, 77.42f, 0.1f),
    new Vector3(3,0, 10.86f, 86.49f, 0.1f),
    new Vector3(3,0, 13.04f, 95.56f, 0.1f),
    new Vector3(3,0, 15.22f, 104.63f, 0.1f),
    new Vector3(3,0, 17.4f, 113.7f, 0.1f)
};
    Vector3[] v3 = {
    new Vector3(5,0, 37.8f, 140.7f, -2.094f),
    new Vector3(5,0, 35.51f, 139.08f, -2.094f),
    new Vector3(5,0, 33.22f, 137.46f, -2.094f),
    new Vector3(5,0, 30.93f, 135.84f, -2.094f),
    new Vector3(5,0, 28.64f, 134.22f, -2.094f),
    new Vector3(5,0, 26.35f, 132.6f, -2.094f),
    new Vector3(5,0, 24.06f, 130.98f, -2.094f),
    new Vector3(5,0, 21.77f, 129.36f, -2.094f),
    new Vector3(5,0, 19.48f, 127.74f, -1.094f),
    new Vector3(5,0, 17.19f, 126.12f, -2.618f),
    new Vector3(5,0, 17.02f, 119.92f, -3.24f),
    new Vector3(5,0, 15.87f, 110.66f, -2.818f),
    new Vector3(5,0, 15.22f, 104.63f, -2.818f),
    new Vector3(5,0, 13.04f, 95.56f, -2.818f),
    new Vector3(5,0, 10.86f, 86.49f, -2.818f),
    new Vector3(5,0, 8.68f, 77.42f, -2.818f),
    new Vector3(5,0, 6.5f, 68.35f, -2.818f),
    new Vector3(5,0, 4.32f, 59.28f, -2.818f),
    new Vector3(5,0, 2.14f, 50.21f, -2.818f),
    new Vector3(5,0, -0.04f, 41.14f, -2.818f),
    new Vector3(5,0, -2.22f, 32.07f, -3.24f),
    new Vector3(5,0, -3.82f, 21.3f, -3.24f),
    new Vector3(5,0, -2.08f, 16.2f, -3.24f),
    new Vector3(5,0, -1.5f, 14.5f, -3.24f),
    new Vector3(5,0, 0.24f, 9.4f, -3.24f),
    new Vector3(5,0, 0.82f, 7.7f, -3.24f),
    new Vector3(5,0, 1.4f, 6.0f, -3.24f)
};

    Vector3[] v2 = {new Vector3 (1.4f, 6.0f, 0.1f),
    new Vector3 (7,1, 0.82f, 7.7f, 0.1f),
    new Vector3 (7,1, 0.24f, 9.4f, 0.1f),
    new Vector3 (7,1, -0.34f, 11.1f, 0.1f),
    new Vector3 (7,1, -0.92f, 12.8f, 0.1f),
    new Vector3 (7,1, -1.5f, 14.5f, 0.1f),
    new Vector3 (7,1, -2.08f, 16.2f, 0.1f),
    new Vector3 (7,1, -2.66f, 17.9f, 0.1f),
    new Vector3 (7,1, -3.24f, 19.6f, 0.1f),
    new Vector3 (7,1, -3.82f, 21.3f, 0.1f),
    new Vector3 (7,1, -4.4f, 23.0f, 0.1f),
    new Vector3 (7,1, -2.22f, 32.07f, 0.1f),
    new Vector3 (7,1, -0.04f, 41.14f, 0.1f),
    new Vector3 (7,1, 2.14f, 50.21f, 0.1f),
    new Vector3 (7,1, 4.32f, 59.28f, 0.1f),
    new Vector3 (7,1, 6.5f, 68.35f, 0.1f),
    new Vector3 (7,1, 8.68f, 77.42f, 0.1f),
    new Vector3 (7,1, 10.86f, 86.49f, 0.1f),
    new Vector3 (7,1, 13.04f, 95.56f, 0.1f),
    new Vector3 (7,1, 15.22f, 104.63f, 0.1f),
    new Vector3 (7,1, 17.4f, 113.7f, 0.1f)};
    
    Vector3[] v4 = {
    new Vector3 (9,1, 37.8f, 140.7f, -2.094f),
    new Vector3 (9,1, 35.51f, 139.08f, -2.094f),
    new Vector3 (9,1, 33.22f, 137.46f, -2.094f),
    new Vector3 (9,1, 30.93f, 135.84f, -2.094f),
    new Vector3 (9,1, 28.64f, 134.22f, -2.094f),
    new Vector3 (9,1, 26.35f, 132.6f, -2.094f),
    new Vector3 (9,1, 24.06f, 130.98f, -2.094f),
    new Vector3 (9,1, 21.77f, 129.36f, -2.094f),
    new Vector3 (9,1, 19.48f, 127.74f, -2.094f),
    new Vector3 (9,1, 17.19f, 126.12f, -2.618f),
    new Vector3 (9,1, 17.02f, 119.92f, -3.24f),
    new Vector3 (9,1, 15.87f, 110.66f, -2.818f),
    new Vector3 (9,1, 15.22f, 104.63f, -2.818f),
    new Vector3 (9,1, 13.04f, 95.56f, -2.818f),
    new Vector3 (9,1, 10.86f, 86.49f, -2.818f),
    new Vector3 (9,1, 8.68f, 77.42f, -2.818f),
    new Vector3 (9,1, 6.5f, 68.35f, -2.818f),
    new Vector3 (9,1, 4.32f, 59.28f, -2.818f),
    new Vector3 (9,1, 2.14f, 50.21f, -2.818f),
    new Vector3 (9,1, -0.04f, 41.14f, -2.818f),
    new Vector3 (9,1, -2.22f, 32.07f, -3.24f),
    new Vector3 (9,1, -3.82f, 21.3f, -3.24f),
    new Vector3 (9,1, -2.08f, 16.2f, -3.24f),
    new Vector3 (9,1, -1.5f, 14.5f, -3.24f),
    new Vector3 (9,1, 0.24f, 9.4f, -3.24f),
    new Vector3 (9,1, 0.82f, 7.7f, -3.24f),
    new Vector3 (9,1, 1.4f, 6.0f, -3.24f)
    };

    Vector3[][] combinedArray = new Vector3[][] {};

    [System.Serializable]
    public struct Vehicle
    {
        public int id;
        public int level;
        // remember to switch Z and Y
        public Vector2 startingPosition;

    }

    
    private void Start()
    {
        combinedArray = new Vector3[][] {v1, v2, v3, v4};

        for (int i = 0; i < VisualizerSettingsAndData.instance.vehicles.Length; i++)
        {
            // ids are arbitrary here and should be replaced from metadata
            VisualizerSettingsAndData.instance.vehicles[i].id = i+1;
            VisualizerSettingsAndData.instance.vehicles[i].level = i % 2;
        }
       
        InvokeRepeating("SetVehicleDataEverySecond", 0, 1);

    }
    
    private void SetVehicleDataEverySecond()
    {
    
        if(index<points){
            for(int i = 0; i< VisualizerSettingsAndData.instance.vehicles.Length; i++)
            {
                VisualizerSettingsAndData.instance.vehicles[i].startingPosition = combinedArray[i][index];
            }
            index++;
        }

    }

}
    
    
   
