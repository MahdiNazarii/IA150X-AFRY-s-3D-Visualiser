using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera FlyingView;
    [SerializeField] CinemachineVirtualCamera LockedView; // Aka 3rd person

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            FlyingView.gameObject.SetActive(true);
            LockedView.gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.T))
        {
            FlyingView.gameObject.SetActive(false);
            LockedView.gameObject.SetActive(true);
        }

    }
}
