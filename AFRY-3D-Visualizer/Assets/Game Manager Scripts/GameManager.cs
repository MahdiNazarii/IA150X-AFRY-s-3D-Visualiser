using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] vehicles;
    [SerializeField] GameObject[] vehicleButtons;
    [SerializeField] GameObject[] vehicleTags;

    private int length;
   
    //Initilaizer function
    private void Start()
    {
        length = VisualizerSettingsAndData.instance.vehicles.Length;
        InitializeComponents();
        InvokeRepeating("SetPosition", 0, 1);
        
    }
    private void InitializeComponents()
    {
        InitializeVehicles();
        InitializeButtons();
        InitializeTags();
    }

    private void InitializeVehicles()
    {
        int id;
        int level;
        Vector2 position;

        for (int i = 0; i <  length; i++)
        {
            id = VisualizerSettingsAndData.instance.vehicles[i].id;
            level = VisualizerSettingsAndData.instance.vehicles[i].level;
            position = VisualizerSettingsAndData.instance.vehicles[i].startingPosition;
            vehicles[i].SetActive(true);
            vehicles[i].GetComponent<MetaData>().SetMetaData(id, level, position);

        }
    }
    private void InitializeButtons()
    {
        for(int i = 0; i < length; i++)
        {
            vehicleButtons[i].SetActive(true);
            vehicleButtons[i].GetComponent<VehicleButton>().setVehicleText(VisualizerSettingsAndData.instance.vehicles[i].id);
        }
    }
    private void InitializeTags()
    {
        for (int i = 0; i < length; i++)
        { 
            vehicleTags[i].SetActive(true);
            vehicleTags[i].GetComponent<FloatingText>().SetTagText(VisualizerSettingsAndData.instance.vehicles[i].id);
        }
    }
    private void SetPosition(){
        for(int i = 0; i < VisualizerSettingsAndData.instance.vehicles.Length; i++)
        {
            vehicles[i].GetComponent<MetaData>().setCurrentPosition(VisualizerSettingsAndData.instance.vehicles[i].startingPosition);
        }
    }
}
