using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float maxZoom = 50f;
    [SerializeField] private float minZoom = 5f;
    Vector3 followOffset;
    public float lookSpeed = 2.0f;
    public float zoomSpeed = 2.0f;
    private Vector2 rotation = Vector2.zero;
    private void Awake()
    {
        followOffset = virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;

    }
    private void Update()
    {
        RotateCamera();
        ZoomCamera();
    }

    private void RotateCamera()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;

        this.gameObject.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
    }

    private void ZoomCamera()
    {
        Vector3 zoomDir = followOffset.normalized;
        //Zoom out
        if (Input.mouseScrollDelta.y < 0)
        {
            followOffset += zoomDir;
        }

        //Zoom in
        if (Input.mouseScrollDelta.y > 0)
        {
            followOffset -= zoomDir;
        }
        if(followOffset.magnitude > maxZoom)
        {
            followOffset = zoomDir * maxZoom;
        }
        if (followOffset.magnitude < minZoom)
        {
            followOffset = zoomDir * minZoom;
        }

        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(
            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
        
    }
}
