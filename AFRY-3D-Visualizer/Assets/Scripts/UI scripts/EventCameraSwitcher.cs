using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EventCameraSwitcher : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera[] allCameras;
    [SerializeField]
    FloatingTextTag[] allTexts;

    [SerializeField] CinemachineVirtualCamera flying;

    public void UpdateWorldSpaceCanvasCamera()
    {
       
        this.gameObject.GetComponent<Canvas>().worldCamera = allCameras[VehicleConfiguration.instance.activeVehicle].GetComponent<Camera>();
        for(int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
        {
            allTexts[i].SwitchCamera(this.gameObject.GetComponent<Canvas>().worldCamera);
        }
      
    }
    public void UpdateWorldSpaceCanvasCameraF()
    {
        this.gameObject.GetComponent<Canvas>().worldCamera = flying.GetComponent<Camera>();
        
        for (int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
        {
            allTexts[i].SwitchCamera(this.gameObject.GetComponent<Canvas>().worldCamera);
        }
    }
}
