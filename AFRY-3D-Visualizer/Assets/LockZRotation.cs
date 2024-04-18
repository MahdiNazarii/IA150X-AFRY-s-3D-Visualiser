using UnityEngine;
using Cinemachine;

public class LockZRotation : MonoBehaviour
{
   [SerializeField]
    CinemachineVirtualCamera virtualCamera;


    private void Update()
    {
        // Lock the rotation around the Z-axis
        if (virtualCamera != null)
        {
            Transform followTarget = virtualCamera.Follow;
            if (followTarget != null)
            {
                Vector3 eulerRotation = followTarget.eulerAngles;
                eulerRotation.z = 0f; // Lock Z-axis rotation
                followTarget.eulerAngles = eulerRotation;
            }
        }
    }
}
