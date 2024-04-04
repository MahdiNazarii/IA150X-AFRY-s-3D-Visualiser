using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] UIManager UI;
    [SerializeField] CinemachineVirtualCamera FlyingView;
    [SerializeField] CinemachineVirtualCamera LockedView; // Aka 3rd person


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            FlyingView.gameObject.SetActive(true);
            LockedView.gameObject.SetActive(false);
            UI.ActivateFlyingViewUI();
        }
        if (Input.GetKey(KeyCode.T))
        {
            FlyingView.gameObject.SetActive(false);
            LockedView.gameObject.SetActive(true);
            UI.ActiveLockedViewUI(0);
        }

    }
}
