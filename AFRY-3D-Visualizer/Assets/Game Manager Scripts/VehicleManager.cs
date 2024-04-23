using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public GameObject[] vehicles;

    [SerializeField] GameObject[] vehicleButtons;
    // Start is called before the first frame update
    private void Start()
    {
        SetHMIds();
        int length = VisualizerSettingsAndData.instance.vehicles.Length;

        for(int i = 0; i < length; i++ )
        {
            Vector3 position = new Vector3(VisualizerSettingsAndData.instance.vehicles[i].startingPosition.x, vehicles[i].transform.position.y,
                                            VisualizerSettingsAndData.instance.vehicles[i].startingPosition.y);
            vehicles[i].transform.position = position;
            vehicles[i].SetActive(true);
            vehicleButtons[i].GetComponent<VehicleButton>().setVehicleText(VisualizerSettingsAndData.instance.vehicles[i].id);
        }
        
    }

    private void SetHMIds()
    {
        int length = VisualizerSettingsAndData.instance.vehicles.Length;
        int id;
        int level;
        Vector2 position;

        for (int i = 0; i <  length; i++)
        {
            id = VisualizerSettingsAndData.instance.vehicles[i].id;
            level = VisualizerSettingsAndData.instance.vehicles[i].level;
            position = VisualizerSettingsAndData.instance.vehicles[i].startingPosition;
            vehicles[i].GetComponent<MetaData>().SetMetaData(id, level, position);
        }
    }
}
