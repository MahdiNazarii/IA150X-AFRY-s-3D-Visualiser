using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    
    public VehicleButton[] vehicleButton;
    public Canvas worldSpaceCanvas;
    public GameObject cameraManager;
   //public GameObject worldSpaceCanvas;

    private void Start()
    {
        int length = VisualizerSettingsAndData.instance.vehicles.Length;
        Debug.Log("There are " + length + " vehicles");
        for(int i = 0; i < length; i++)
        {
            int id = i;
            vehicleButton[i].gameObject.SetActive(true);
            vehicleButton[i].vehicleText.text = "Vehicle" + (i+1).ToString();
            vehicleButton[i].GetComponent<Button>().onClick.RemoveAllListeners();
            vehicleButton[i].GetComponent<Button>().onClick.AddListener(() => cameraManager.GetComponent<CameraSwitch>().OnClickSwitchToVehicle(id - 1));
            vehicleButton[i].GetComponent<Button>().onClick.AddListener(() => worldSpaceCanvas.GetComponent<EventCameraSwitcher>().UpdateWorldSpaceCanvasCamera(this, id-1));
            id++;
        }
        QuickFix(length);
    }

    private void SelectLevel(int idNum)
    {
        //Debug.Log("Switch to Vehicle " + idNum);

    }
    private void QuickFix(int length)
    {
        for (int i = 0; i < length; i++)
        {
            vehicleButton[i].GetComponent<Button>().onClick.Invoke();
        }
        cameraManager.GetComponent<CameraSwitch>().OnClickSwitchToFlyingView();
        cameraManager.GetComponent<CameraSwitch>().OnClickSwitchToFlyingView();
    }
}
