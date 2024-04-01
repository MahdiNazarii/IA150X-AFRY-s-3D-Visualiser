using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
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
}
