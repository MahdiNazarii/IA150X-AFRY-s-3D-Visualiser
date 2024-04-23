using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleWare : MonoBehaviour
{
    private int points;
    Vector3[] v1;
    Vector3[] v2;
    Vector3[] v3;
    Vector3[] v4;


    public Vehicle[] vehicles = new Vehicle[4];
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
        for (int i = 0; i < vehicles.Length; i++)
        {
            vehicles[i].id = i;
            vehicles[i].level = i % 2;
        }
        InvokeRepeating("SetVehicleDataEverySecond", 1, points);

    }
    private void SetVehicleDataEverySecond()
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            // VisualizerSettingsAndData.instance.vehicles[i];
        }

    }

}
    
    
   
