using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    Transform currentCamera;
    [SerializeField]
    Transform vehicle;
    [SerializeField]
    Canvas worldSpaceCanvas;
 

    public Vector3 offset;
    float minSize = 0.025f;
    float maxSize = 0.2f;
    private void Awake()
    {
        currentCamera = worldSpaceCanvas.worldCamera.transform;
        this.GetComponent<TextMeshProUGUI>().text = vehicle.GetComponent<MetaData>().GetId().ToString();

        if (worldSpaceCanvas == null)
        {
            Debug.LogError("No worldSpaceCanvas found in parent hierarchy for FloatingText object: " + gameObject.name);
        }
    }

    void Update()
    {
        if (worldSpaceCanvas != null)
        {
            RotateToCamera();
            //FollowParentVehicle();
            ScaleTextWithCameraDistance();
        }
    }
    private void RotateToCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - currentCamera.position);
    }
    public void FollowParentVehicle()
    {
        transform.position = vehicle.position + offset;
    }
    private void ScaleTextWithCameraDistance()
    {
        float newSize = Vector3.Distance(new Vector3(transform.position.x, transform.position.y, transform.position.z)
            , currentCamera.position)/1000;
        //Debug.Log(newSize);
        newSize = Mathf.Clamp(newSize, minSize, maxSize);
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
    // Method to switch the camera if needed
    public void SwitchCamera(Camera newCamera)
    {
        currentCamera = newCamera.transform;
    }

    public void SetTagText(string machineName)
    {
        this.GetComponent<TextMeshProUGUI>().text = machineName;
    }
}
