    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{

    //[Header("Events")]
    //public GameEvent OnCameraHasSwitched;
    [SerializeField] CinemachineVirtualCamera FlyingView;
    [SerializeField] CinemachineVirtualCamera[] LockedVehicleView; // Aka 3rd person
    [SerializeField] Canvas worldSpaceCanvas;

    //[Header("Events")]
    //public GameEvent onCameraHasChanged;
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
        //FlyingView.GetComponent<FreeFlyCamera>().enabled = true;
        FlyingView.gameObject.SetActive(true);
        LockedVehicleView[current].gameObject.SetActive(false);
        worldSpaceCanvas.GetComponent<EventCameraSwitcher>().UpdateWorldSpaceCanvasCameraF(this, "yo");
        //onCameraHasChanged.Raise(this, counter);
    }



    public void OnClickSwitchToVehicle(int id)
    {
        VehicleConfiguration.instance.activeVehicle = id;
        //FlyingView.GetComponent<FreeFlyCamera>().enabled = false;
        
        LockedVehicleView[current].gameObject.SetActive(false);
        LockedVehicleView[id].gameObject.SetActive(true);
        FlyingView.gameObject.SetActive(false);
        current = id;
        //OnCameraHasSwitched.Raise(this, id);

    }


}
