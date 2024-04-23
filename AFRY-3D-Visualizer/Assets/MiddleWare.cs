using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleWare : MonoBehaviour
{
    public Vehicle[] vehicles= new Vehicle[4];
   [System.Serializable]
    public struct Vehicle
    {
        public int id;
        public int level;
        // remember to switch Z and Y
        public Vector2 startingPosition;

    }

    private void Awake()
    {
        for(int i=0; i<vehicles.Length; i++)
        {
            vehicles[i].id = i;
            vehicles[i].level = i%2;
        }
    }
    
    
    
    }
