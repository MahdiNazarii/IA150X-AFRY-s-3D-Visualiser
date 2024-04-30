using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    
    public VehicleButton[] vehicleButton;
    public Canvas worldSpaceCanvas;
    public GameObject cameraManager;

    private void Start()
    {
        int length = VehicleConfiguration.instance.vehicles.Count;
        for(int i = 0; i < length; i++)
        {
            int j = i;
            vehicleButton[i].gameObject.SetActive(true);
            vehicleButton[i].GetComponent<Button>().onClick.RemoveAllListeners();
            vehicleButton[i].GetComponent<Button>().onClick.AddListener(() => cameraManager.GetComponent<CameraSwitch>().OnClickSwitchToVehicle(j - 1));
            vehicleButton[i].GetComponent<Button>().onClick.AddListener(() => worldSpaceCanvas.GetComponent<EventCameraSwitcher>().UpdateWorldSpaceCanvasCamera(this, j-1));
            j++;
        }
        QuickFix(length);
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
