using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class VehicleConfiguration : MonoBehaviour
{
    public static VehicleConfiguration instance;
    //private string url = "https://localhost:7030/api/MacMachines/GetAllMacMachines"; // Replace with your API endpoint
    private string url = "https://localhost:7214/api/Machine/GetAllMachines";
    String jsonString;
    public List<VehicleConfiguration.Vehicle> vehicles;

    [SerializeField] GameObject[] vehicle;
    [SerializeField] GameObject[] vehicleButtons;
    [SerializeField] GameObject[] vehicleTags;
    public int activeVehicle = 0;


    [System.Serializable]
    public struct Vehicle
    {
        public int machine_id;
        public int machine_type;
        public string machine_external_id;
        public int serial_number;
        public int status;

    }

    private void Awake()
    {
        CreateSingleton();
        StartCoroutine(GetData());
        
    }

     private void InitializeComponents()
    {
        InitializeVehicles();
        InitializeButtons();
        InitializeTags();
    }

     private void InitializeVehicles()
    {
        int machine_id;
        int machine_type;
        String machine_external_id;
        int serial_number;
        int status;

        
                

        for (int i = 0; i <  vehicles.Count; i++)
        {
            machine_id = vehicles[i].machine_id;
            machine_type = vehicles[i].machine_type;
            machine_external_id = vehicles[i].machine_external_id;
            serial_number = vehicles[i].serial_number;
            status = vehicles[i].status;
            vehicle[i].SetActive(true);
            vehicle[i].GetComponent<MetaData>().SetMetaData(machine_id, machine_external_id, machine_type, serial_number, status);

        }

        
    }
    private void InitializeButtons()
    {
        for(int i = 0; i < vehicles.Count; i++)
        {
            vehicleButtons[i].SetActive(true);
            vehicleButtons[i].GetComponent<VehicleButton>().setVehicleText(vehicles[i].machine_external_id);
        }
    }
    private void InitializeTags()
    {
        for (int i = 0; i < vehicles.Count; i++)
        { 
            vehicleTags[i].SetActive(true);
            vehicleTags[i].GetComponent<FloatingTextTag>().SetTagText(vehicles[i].machine_external_id);
        }
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

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                jsonString = webRequest.downloadHandler.text;
                vehicles = JsonConvert.DeserializeObject<List<VehicleConfiguration.Vehicle>>(jsonString);
            }
        }

        // Initialize the vehicles, buttons and tags
        InitializeComponents();

        yield return null;
    }
}
