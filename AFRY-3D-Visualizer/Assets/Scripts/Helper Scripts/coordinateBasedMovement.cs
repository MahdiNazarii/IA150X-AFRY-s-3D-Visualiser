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


   

    float[][] coordinates = {
    new float[] {1.4f, 6.0f, 0.1f},
    new float[] {0.82f, 7.7f, 0.1f},
    new float[] {0.24f, 9.4f, 0.1f},
    new float[] {-0.34f, 11.1f, 0.1f},
    new float[] {-0.92f, 12.8f, 0.1f},
    new float[] {-1.5f, 14.5f, 0.1f},
    new float[] {-2.08f, 16.2f, 0.1f},
    new float[] {-2.66f, 17.9f, 0.1f},
    new float[] {-3.24f, 19.6f, 0.1f},
    new float[] {-3.82f, 21.3f, 0.1f},
    new float[] {-4.4f, 23.0f, 0.1f},
    new float[] {-2.22f, 32.07f, 0.1f},
    new float[] {-0.04f, 41.14f, 0.1f},
    new float[] {2.14f, 50.21f, 0.1f},
    new float[] {4.32f, 59.28f, 0.1f},
    new float[] {6.5f, 68.35f, 0.1f},
    new float[] {8.68f, 77.42f, 0.1f},
    new float[] {10.86f, 86.49f, 0.1f},
    new float[] {13.04f, 95.56f, 0.1f},
    new float[] {15.22f, 104.63f, 0.1f},
    new float[] {17.4f, 113.7f, 0.1f}
    };


    // public void SetTargetPositionFromInput()
    // {
    //     float xPosition = float.Parse(xInput.text);
    //     float zPosition = float.Parse(zInput.text);
    //     float angle = float.Parse(angleInput.text);
        
    //      // If the target position is the same as the previous one, return early
    //     if (targetPosition.HasValue && targetPosition.Value.x == xPosition && targetPosition.Value.z == zPosition)
    //     {
    //         return;
    //     }
    //     MoveObjectToPosition(xPosition, zPosition, angle);

    // }


    void Start()
    {
        InvokeRepeating("MovementSystem", 0, 1);
        //StartCoroutine(MoveThroughCoordinates());
    }

    // IEnumerator MoveThroughCoordinates()
    // {
    //     int index = 0;
    //     while (index < coordinates.Length)
    //     {
    //         float[] position = coordinates[index];
    //         float xPosition = position[0];
    //         float zPosition = position[1];
    //         float angle = position[2];
    //         MoveObjectToPosition(xPosition, zPosition, angle);

    //         index++;

    //         yield return new WaitForSeconds(1); // Wait for 1 second before moving to the next position
    //     }
    // }
    public void MovementSystem()
    {
        float x = this.GetComponent<MetaData>().positionObject.x;
        float z = this.GetComponent<MetaData>().positionObject.y;
        float angle = this.GetComponent<MetaData>().positionObject.z;
        MoveObjectToPosition(x, z, angle );
        SetOrientation();
    }

    public void MoveObjectToPosition(float xPosition, float zPosition, float angleInRadians)
    {
        float yPosition = transform.position.y; // Default to current y-position
        LayerMask layerMask;
        // Define a layer mask that only includes the mining road layer
        int level = this.GetComponent<MetaData>().GetLevel();
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
        int level = this.GetComponent<MetaData>().GetLevel();
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