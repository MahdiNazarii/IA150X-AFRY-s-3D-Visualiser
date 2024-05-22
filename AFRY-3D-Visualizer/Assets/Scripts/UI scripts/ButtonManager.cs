using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    
    public VehicleButton[] vehicleButton;
    public Canvas worldSpaceCanvas;
    public GameObject cameraManager;

    public void InitializeButtons()
    {
        //VehicleConfiguration.Vehicle[] vehicles = VehicleConfiguration.instance.vehicles;
        
    int length = VehicleConfiguration.instance.vehicles.Count;
        for(int i = 0; i < length; i++)
        {
            int j = i;
            vehicleButton[i].GetComponent<VehicleButton>().SetVehicleText(VehicleConfiguration.instance.vehicles[i].machine_external_id);
            vehicleButton[i].gameObject.SetActive(true);
            vehicleButton[i].GetComponent<Button>().onClick.RemoveAllListeners();
            vehicleButton[i].GetComponent<Button>().onClick.AddListener(() => cameraManager.GetComponent<CameraSwitch>().OnClickSwitchToVehicle(j-1));
            vehicleButton[i].GetComponent<Button>().onClick.AddListener(() => worldSpaceCanvas.GetComponent<EventCameraSwitcher>().UpdateWorldSpaceCanvasCamera(/*this, j-1*/));
            j++;
        }
       
    }

}
///Possibly removable
