using UnityEngine;
using TMPro;
using System.IO;
using System.Net.Sockets;
using System.Collections;

public class coordinateBasedMovement : MonoBehaviour
{
    public Vector3? targetPosition = null;

    float carWidth = 1.84f;
    float carLength = 1.52f;

    public FloatingText floatingText;

    float level = 0;


    public void MovementSystem(float x,float z, float angle, float lev)
    {
        level = lev;
        MoveObjectToPosition(x, z, angle);
        SetOrientation();
        // move the corresponding tag of the HM
        floatingText.GetComponent<FloatingText>().FollowParentVehicle(); //shoulld not be here
    }

    public void MoveObjectToPosition(float xPosition, float zPosition, float angleInRadians)
    {
        float yPosition = transform.position.y; // Default to current y-position
        LayerMask layerMask;
        // Define a layer mask that only includes the mining road layer
        //int level = this.GetComponent<MetaData>().GetLevel();
        if (level == 0)
            layerMask = LayerMask.GetMask("MiningEnvL0");
        else
        {
            layerMask = LayerMask.GetMask("MiningEnvL1");
        }
        Ray ray = new Ray(new Vector3(xPosition, 1000, zPosition), Vector3.down);
        // Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 2f);
        RaycastHit hit;
        // Cast the ray, passing in the layer mask
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // The rest of your code...
            yPosition = hit.point.y;
            //Debug.Log("Hit point L1: " + hit.point);
        }

        targetPosition = new Vector3(xPosition, yPosition, zPosition);
       // Debug.Log("Target position set to: " + targetPosition);

        // Convert the angle from radians to degrees
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // Set the rotation of the model to face the specified direction
        transform.rotation = Quaternion.Euler(0, angleInDegrees, 0);

        //Debug.Log("Distance to target: " + distanceToTarget + " Target position: " + targetPosition.Value);
    }

 private void SetOrientation()
{
    if (targetPosition != null)
    {   
        // Teleport the object to the target position
        transform.position = targetPosition.Value;

        // Define the offsets for the four corners of the car
        Vector3[] offsets = new Vector3[]
        {
            new Vector3(-carWidth / 2, 0, -carLength / 2),
            new Vector3(carWidth / 2, 0, -carLength / 2),
            new Vector3(-carWidth / 2, 0, carLength / 2),
            new Vector3(carWidth / 2, 0, carLength / 2)
        };

        LayerMask layerMask;
        // Define a layer mask that only includes the mining road layer
        //int level = this.GetComponent<MetaData>().GetLevel();
        if (level == 0)
            layerMask = LayerMask.GetMask("MiningEnvL0");
        else
        {
            layerMask = LayerMask.GetMask("MiningEnvL1");
        }

        Vector3 averageNormal = Vector3.zero;
        foreach (Vector3 offset in offsets)
        {
            // Cast a ray downwards from a high position at each corner of the car
            Ray ray = new Ray(transform.position + Vector3.up * 1000 + offset, -Vector3.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // Add the hit normal to the average normal
                averageNormal += hit.normal;
            }
        }

        // Divide the average normal by the number of corners to get the actual average
        averageNormal /= offsets.Length;

        // Calculate the angle between the car's up direction and the average surface normal
        float angle = Vector3.Angle(transform.up, averageNormal);

        // If the angle is above a certain threshold, adjust the car's rotation to align with the average surface normal
        float angleThreshold = 7.5f; // Set this to whatever value you find appropriate
        if (angle > angleThreshold)
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, averageNormal) * transform.rotation;
        }

        // Reset the target position
        targetPosition = null; 
    }
}
}