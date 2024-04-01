using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float maxZoom = 50f;
    [SerializeField] private float minZoom = 5f;
    Vector3 followOffset;
    public float lookSpeed = 2.0f;
    public float zoomSpeed = 10.0f;
    private Vector2 rotation = Vector2.zero;
    private void Awake()
    {
        followOffset = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset;

    }
    private void Update()
    {
        RotateCamera();
        //HandleZoom();
        ZoomCamera();
        if(Input.GetKey(KeyCode.P))
        {
            SwitchCamera();

        }

    }

    private void RotateCamera()
    {
        // Gets the rotation when mouse moves in different directions
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;

        this.gameObject.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
    }

    private void ZoomCamera()
    {
        //float speed = zoomSpeed * Time.deltaTime;
        Vector3 zoomDir = followOffset.normalized;
        //Zoom out
        if (Input.GetKey(KeyCode.Q))
        {
            followOffset += zoomDir;
        }

        //Zoom in
        if (Input.GetKey(KeyCode.E))
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

        virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(
            virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
        
    }
    private void HandleZoom()
    {
        //Zoom out
        if (Input.GetKey(KeyCode.UpArrow))
            virtualCamera.m_Lens.FieldOfView += 0.1f;
        //Zoom in
        if (Input.GetKey(KeyCode.DownArrow))
            virtualCamera.m_Lens.FieldOfView += -0.1f;
    }

    private void SwitchCamera()
    {
        if (virtualCamera.m_Priority > 7)
            virtualCamera.m_Priority = 5;
        else
            virtualCamera.m_Priority = 10;
    }
}
