using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

public class VehicleConfiguration : MonoBehaviour
{
    
    public static VehicleConfiguration instance;
    //private string url = "https://localhost:7030/api/MacMachines/GetAllMacMachines"; // Replace with your API endpoint
    private string url = "https://localhost:7214/api/Machine/GetAllMachines";

   
    String jsonString;
    public List<VehicleConfiguration.Vehicle> vehicles;

    [SerializeField] GameObject buttonUI;
    //[SerializeField] GameObject cameraManager;
    //[SerializeField] GameObject worldSpaceCanvas;

    [SerializeField] GameObject[] vehicle;
    //[SerializeField] GameObject[] vehicleButtons;
    [SerializeField] GameObject[] vehicleTags;
    public int activeVehicle = 0;
    [SerializeField] private bool isTest;


    [System.Serializable]
    public struct Vehicle
    {
        public int machine_id;
        public int machine_type;
        public string machine_external_id;
        public int serial_number;
        public int status;

        public Vehicle(int id, int type, string name, int serialnumber, int status)
        {
            machine_id = id;
            machine_type = type;
            machine_external_id = name;
            serial_number = serialnumber;
            this.status = status;
        }

    }

    private void Awake()
    {
        CreateSingleton();
        if (!isTest)
        {
            StartCoroutine(GetData());
        }
        else
        {
            TestInit();

        }
    }

    public void TestInit()
    {
        //vehicles = new Vehicle[2];
        vehicles[0] = new Vehicle(3, 1, "Vehicle 1", 1, 1);
        vehicles[1] = new Vehicle(5, 1, "Vehicle 2", 1, 3);

        vehicle[0].SetActive(true);
        vehicle[1].SetActive(true);
        vehicle[0].GetComponent<MetaData>().SetMetaData(3, "Vehicle 1", 12, 1, 1);
        vehicle[1].GetComponent<MetaData>().SetMetaData(5, "Vehicle 2", 12, 1, 3);

        buttonUI.GetComponent<ButtonManager>().InitializeButtons();


        vehicleTags[0].SetActive(true);
        vehicleTags[0].GetComponent<FloatingTextTag>().SetTagText("Vehicle 1");
        vehicleTags[0].GetComponent<FloatingTextTag>().FollowParentVehicle();
        vehicleTags[1].SetActive(true);
        vehicleTags[1].GetComponent<FloatingTextTag>().SetTagText("Vehicle 2");
        vehicleTags[1].GetComponent<FloatingTextTag>().FollowParentVehicle();

    }

     private void InitializeComponents()
    {
        InitializeVehicles();
        buttonUI.GetComponent<ButtonManager>().InitializeButtons();
        //InitializeButtons();
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
    
    private void InitializeTags()
    {
        for (int i = 0; i < vehicles.Count; i++)
        { 
            vehicleTags[i].SetActive(true);
            vehicleTags[i].GetComponent<FloatingTextTag>().SetTagText(vehicles[i].machine_external_id);
            vehicleTags[i].GetComponent<FloatingTextTag>().FollowParentVehicle(); 
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
