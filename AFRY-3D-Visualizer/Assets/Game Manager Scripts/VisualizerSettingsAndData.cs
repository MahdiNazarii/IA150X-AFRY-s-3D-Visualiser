using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerSettingsAndData : MonoBehaviour
{
    public static VisualizerSettingsAndData instance;

    public Vehicle[] vehicles;
    public int activeVehicle = 0;


    [System.Serializable]
    public struct Vehicle
    {
        public int id;
        public int level;
        // remember to switch Z and Y
        public Vector3 startingPosition;

    }

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            
        Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
