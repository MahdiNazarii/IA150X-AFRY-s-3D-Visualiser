using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControllerOld : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float maxZoom = 100f;
    [SerializeField] private float minZoom = 5f;
    Vector3 followOffset;
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 2.0f;
    private Vector2 rotation = Vector2.zero;
    private void Awake()
    {
        followOffset = virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;

    }
    private void Update()
    {
        //CursorMode =  CursorLockMode.Locked;
        RotateCamera();
        ZoomCamera();
    }

    private void RotateCamera()
    {
         rotation.y += Input.GetAxis("Mouse X") * rotationSpeed;
         rotation.x += -Input.GetAxis("Mouse Y") * rotationSpeed;

        //rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);
        //rotates the camera target according to lateral mouse movement
        this.gameObject.transform.localRotation = Quaternion.Euler(0, rotation.y, 0);
        //Debug.Log(this.transform.rotation.ToString());
        transform.eulerAngles = new Vector3(0, rotation.y, 0);

        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        // Rotate around Y axis
        //transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World); // Use Space.World to rotate around global Y axis
        //
        //// Rotate around X axis
        //Quaternion cameraRotation = virtualCamera.transform.localRotation * Quaternion.Euler(-mouseY * rotationSpeed, 0f, 0f); // Calculate new rotation
        //float angleX = cameraRotation.eulerAngles.x;
        //if (angleX > 180f) angleX -= 360f; // Convert angle to -180 to 180 range
        //float newAngleX = Mathf.Clamp(angleX, -80f, 80f); // Clamp rotation to prevent flipping
        //virtualCamera.transform.localRotation = Quaternion.Euler(newAngleX, 0f, 0f); // Apply new rotation

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
