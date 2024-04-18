using UnityEngine;
using TMPro;
using System.IO;
using System.Net.Sockets;
using System.Collections;

public class coordinateBasedMovement2 : MonoBehaviour
{
    public Vector3? targetPosition = null;

    // public TMP_InputField xInput;
    // public TMP_InputField zInput;

    // public TMP_InputField angleInput;

    float carWidth = 1.84f;
    float carLength = 1.52f;


   

    float[][] coordinates = {
    new float[] {-2.25f, 35.0f, 0.1f},
    new float[] {-2.0555556f, 35.813133f, 0.1f},
    new float[] {-1.8611112f, 36.626263f, 0.1f},
    new float[] {-1.6666666f, 37.439392f, 0.1f},
    new float[] {-1.4722222f, 38.252525f, 0.1f},
    new float[] {-1.2777778f, 39.06566f, 0.1f},
    new float[] {-1.0833333f, 39.878788f, 0.1f},
    new float[] {-0.88888896f, 40.691917f, 0.1f},
    new float[] {-0.6944444f, 41.50505f, 0.1f},
    new float[] {-0.5f, 42.318184f,0.1f},
    new float[] {-0.30555558f, 43.131313f, 0.1f},
    new float[] {-0.111111164f, 43.944443f, 0.1f},
    new float[] {0.08333349f, 44.757576f, 0.1f},
    new float[] {0.27777767f, 45.57071f, 0.1f},
    new float[] {0.4722221f, 46.38384f, 0.1f},
    new float[] {0.66666675f, 47.196968f, 0.1f},
    new float[] {0.86111116f, 48.0101f, 0.1f},
    new float[] {1.0555553f, 48.82323f, 0.1f},
    new float[] {1.25f, 49.636364f, 0.1f},
    new float[] {1.4444444f, 50.449493f, 0.1f},
    new float[] {1.6388888f, 51.262627f, 0.1f},
    new float[] {1.8333335f, 52.07576f, 0.1f},
    new float[] {2.0277777f, 52.88889f, 0.1f},
    new float[] {2.2222223f, 53.70202f, 0.1f},
    new float[] {2.416667f, 54.515152f, 0.1f},
    new float[] {2.6111107f, 55.32828f, 0.1f},
    new float[] {2.8055553f, 56.141415f, 0.1f},
    new float[] {3.0f, 56.954544f, 0.1f},
    new float[] {3.1944442f, 57.767677f, 0.1f},
    new float[] {3.3888888f, 58.58081f, 0.1f},
    new float[] {3.5833335f, 59.39394f, 0.1f},
    new float[] {3.7777777f, 60.20707f, 0.1f},
    new float[] {3.9722223f, 61.020203f, 0.1f},
    new float[] {4.166667f, 61.833336f, 0.1f},
    new float[] {4.3611107f, 62.64646f, 0.1f},
    new float[] {4.5555553f, 63.459595f, 0.1f},
    new float[] {4.75f, 64.27273f, 0.1f},
    new float[] {4.944444f, 65.08586f, 0.1f},
    new float[] {5.138889f, 65.89899f, 0.1f},
    new float[] {5.3333335f, 66.71212f, 0.1f},
    new float[] {5.5277777f, 67.52525f, 0.1f},
    new float[] {5.7222223f, 68.33838f, 0.1f},
    new float[] {5.916667f, 69.15152f, 0.1f},
    new float[] {6.1111107f, 69.964645f, 0.1f},
    new float[] {6.3055553f, 70.77778f, 0.1f},
    new float[] {6.5f, 71.59091f, 0.1f},
    new float[] {6.6944447f, 72.40404f, 0.1f},
    new float[] {6.8888893f, 73.21717f, 0.1f},
    new float[] {7.083334f, 74.030304f, 0.1f},
    new float[] {7.2777777f, 74.84343f, 0.1f},
    new float[] {7.4722214f, 75.65656f, 0.1f},
    new float[] {7.666666f, 76.469696f, 0.1f},
    new float[] {7.8611107f, 77.28283f, 0.1f},
    new float[] {8.055555f, 78.09596f, 0.1f},
    new float[] {8.25f, 78.90909f, 0.1f},
    new float[] {8.444445f, 79.72223f, 0.1f},
    new float[] {8.638888f, 80.535355f, 0.1f},
    new float[] {8.833333f, 81.34848f, 0.1f},
    new float[] {9.027778f, 82.16162f, 0.1f},
    new float[] {9.222222f, 82.97475f, 0.1f},
    new float[] {9.416667f, 83.78788f, 0.1f},
    new float[] {9.611112f, 84.60101f, 0.1f},
    new float[] {9.805555f, 85.41414f, 0.1f},
    new float[] {10.0f, 86.22727f, 0.1f},
    new float[] {10.194445f, 87.040405f, 0.15f},
    new float[] {10.388889f, 87.85353f, 0.15f},
    new float[] {10.583334f, 88.66667f, 0.15f},
    new float[] {10.777778f, 89.4798f, 0.15f},
    new float[] {10.972221f, 90.29292f, 0.15f},
    new float[] {11.166666f, 91.106064f, 0.15f},
    new float[] {11.361111f, 91.91919f, 0.15f},
    new float[] {11.555555f, 92.73232f, 0.15f},
    new float[] {11.75f, 93.545456f, 0.15f},
    new float[] {11.944444f, 94.35858f, 0.15f},
    new float[] {12.138888f, 95.171715f, 0.15f},
    new float[] {12.333333f, 95.98485f, 0.15f},
    new float[] {12.527778f, 96.79798f, 0.15f},
    new float[] {12.722222f, 97.611115f, 0.15f},
    new float[] {12.916667f, 98.42424f, 0.15f},
    new float[] {13.111111f, 99.23737f, 0.15f},
    new float[] {13.305555f, 100.05051f, 0.15f},
    new float[] {13.5f, 100.86363f, 0.15f},
    new float[] {13.694445f, 101.676765f, 0.15f},
    new float[] {13.888889f, 102.4899f, 0.15f},
    new float[] {14.083334f, 103.30303f, 0.15f},
    new float[] {14.277777f, 104.11616f, 0.15f},
    new float[] {14.472221f, 104.92929f, 0.15f},
    new float[] {14.666666f, 105.742424f, 0.15f},
    new float[] {14.861111f, 106.55556f, 0.15f},
    new float[] {15.055555f, 107.36869f, 0.15f},
    new float[] {15.25f, 108.18182f, 0.15f},
    new float[] {15.444445f, 108.99495f, 0.15f},
    new float[] {15.638889f, 109.80808f, 0.15f},
    new float[] {15.833334f, 110.62121f, 0.15f},
    new float[] {16.027779f, 111.43434f, 0.15f},
    new float[] {16.222223f, 112.247475f, 0.15f},
    new float[] {16.416668f, 113.06061f, 0.15f},
    new float[] {16.61111f, 113.87373f, 0.15f},
    new float[] {16.805555f, 114.68687f, 0.15f},
    new float[] {17.0f, 115.5f, 0.08f},
    new float[] {40f, 143f, 0.8f}
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
        StartCoroutine(MoveThroughCoordinates());
    }

    IEnumerator MoveThroughCoordinates()
    {
        int index = 0;
        while (index < coordinates.Length)
        {
            float[] position = coordinates[index];
            float xPosition = position[0];
            float zPosition = position[1];
            float angle = position[2];
            MoveObjectToPosition(xPosition, zPosition, angle);

            index++;

            yield return new WaitForSeconds(1); // Wait for 1 second before moving to the next position
        }
    }

    public void MoveObjectToPosition(float xPosition, float zPosition, float angleInRadians)
    {
        float yPosition = transform.position.y; // Default to current y-position

        // Define a layer mask that only includes the mining road layer
        int layerMask = LayerMask.GetMask("MiningRoad");

        // Cast a ray downwards from a high position at the target x and z coordinates
        Ray ray = new Ray(new Vector3(xPosition, 1000, zPosition), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // If the ray hit something, set the y-position to the hit point's y-coordinate
            yPosition = hit.point.y;
        }

        targetPosition = new Vector3(xPosition, yPosition, zPosition);

        // Convert the angle from radians to degrees
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // Set the rotation of the model to face the specified direction
        transform.rotation = Quaternion.Euler(0, angleInDegrees, 0);

        //Debug.Log("Distance to target: " + distanceToTarget + " Target position: " + targetPosition.Value);
    }

 void Update()
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

        int layerMask = LayerMask.GetMask("MiningRoad");
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