    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{


    [SerializeField] CinemachineVirtualCamera FlyingView;
    [SerializeField] CinemachineVirtualCamera[] LockedVehicleView; // Aka 3rd person
    [SerializeField] Canvas worldSpaceCanvas;

    private int current = 0;


    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            OnClickSwitchToFlyingView();
        }
    }


    public void OnClickSwitchToFlyingView()
    {
        FlyingView.gameObject.SetActive(true);
        LockedVehicleView[current].gameObject.SetActive(false);
        worldSpaceCanvas.GetComponent<EventCameraSwitcher>().UpdateWorldSpaceCanvasCameraF(this, "yo");
    }



    public void OnClickSwitchToVehicle(int id)
    {
        VehicleConfiguration.instance.activeVehicle = id;
      
        LockedVehicleView[current].gameObject.SetActive(false);
        LockedVehicleView[id].gameObject.SetActive(true);
        FlyingView.gameObject.SetActive(false);
        current = id;

    }


}
