using UnityEngine;
using TMPro;
using System.IO;
using System.Net.Sockets;

public class coordinateBasedMovement2 : MonoBehaviour
{
    public Vector3? targetPosition = null;

    public TMP_InputField xInput;
    public TMP_InputField zInput;


    float speed = 4f;

    float distanceToTarget = 0f;
    float acceleration = 1f;
    private float currentSpeed = 0f;

    public void SetTargetPositionFromInput()
    {
        float xPosition = float.Parse(xInput.text);
        float zPosition = float.Parse(zInput.text);
        
         // If the target position is the same as the previous one, return early
        if (targetPosition.HasValue && targetPosition.Value.x == xPosition && targetPosition.Value.z == zPosition)
        {
            return;
        }
        MoveObjectToPosition(xPosition, zPosition);

    }

    // Getting x and z coordinates from MCS-Core
    // public void SetTargetPositionFromInput()
    // {
    //     TcpClient client = new TcpClient("localhost", 5000);
    //     StreamReader reader = new StreamReader(client.GetStream());

    //     string[] positions = reader.ReadLine().Split(',');
    //     float xPosition = float.Parse(positions[0]);
    //     float zPosition = float.Parse(positions[1]);

    //      if (targetPosition.HasValue && targetPosition.Value.x == xPosition && targetPosition.Value.z == zPosition)
    //     {
    //         return;
    //     }
    //     MoveObjectToPosition(xPosition, zPosition);
    // }

    public void MoveObjectToPosition(float xPosition, float zPosition)
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
        Debug.Log("Distance to target: " + distanceToTarget + " Target position: " + targetPosition.Value);
    }

   void Update()
{
    if (targetPosition != null)
    {   
        distanceToTarget = Vector3.Distance(transform.position, targetPosition.Value);
        if (distanceToTarget > 0.1)
        {
            Vector3 directionToTarget = (targetPosition.Value - transform.position).normalized;

            // Calculate the angle between the car's forward direction and the direction to the target
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            // Check if the direction to the target is not a zero vector
            if (directionToTarget != Vector3.zero)
            {
                // If the target is behind the car, flip the direction
                if (angle > 90)
                {
                    directionToTarget = -directionToTarget;
                }

                // Calculate a rotation that faces the target position
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                // Apply the rotation to the car's transform
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed * 0.3f);
                //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }

            // Check if the target is behind the car
            if (angle > 90)
            {
                // Move in reverse
                currentSpeed = Mathf.Max(currentSpeed - acceleration * Time.deltaTime, -speed);
                transform.position += transform.forward * currentSpeed * Time.deltaTime;
            }
            else
            {
                // Move forward
                currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, speed);
                transform.position += transform.forward * currentSpeed * Time.deltaTime;
            }
        }
        else
        {
            targetPosition = null; // Stop moving the object

            // Stop any physical movement by setting the velocity to zero
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            currentSpeed = 0f;
        }
    }
}
}