using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public GameObject[] vehicles;
    // Start is called before the first frame update
    private void Start()
    {
        int length = VisualizerSettingsAndData.instance.vehicles.Length;

        for(int i = 0; i < length; i++ )
        {
            Vector3 position = new Vector3(VisualizerSettingsAndData.instance.vehicles[i].startingPosition.x, vehicles[i].transform.position.y,
                                            VisualizerSettingsAndData.instance.vehicles[i].startingPosition.y);
            vehicles[i].transform.position = position;
            vehicles[i].SetActive(true);
        }
        
    }
}
