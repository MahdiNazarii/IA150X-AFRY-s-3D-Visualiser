using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EventCameraSwitcher : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera[] allCameras;
    [SerializeField]
    FloatingText[] allTexts;

    [SerializeField] CinemachineVirtualCamera flying;

    public void UpdateWorldSpaceCanvasCamera(Component sender, object data)
    {
        //Debug.Log(this.ToString() + "Data being sent?" + data.ToString());
        this.gameObject.GetComponent<Canvas>().worldCamera = allCameras[VehicleConfiguration.instance.activeVehicle].GetComponent<Camera>();
        for(int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
        {
           allTexts[i].SwitchCamera(this.gameObject.GetComponent<Canvas>().worldCamera);
        }
        //Debug.Log("UpdateWorldSpaceCanvasCamera successfully invoked");
    }
    public void UpdateWorldSpaceCanvasCameraF(Component sender, object data)
    {
        //Debug.Log(this.ToString() + "Data being sent?" + data.ToString());
        this.gameObject.GetComponent<Canvas>().worldCamera = flying.GetComponent<Camera>();
        for (int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
        {
            allTexts[i].SwitchCamera(this.gameObject.GetComponent<Canvas>().worldCamera);
        }
        //Debug.Log("UpdateWorldSpaceCanvasCamera successfully invoked");
    }
}
