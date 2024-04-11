using UnityEngine;
using TMPro;

public class coordinateBasedMovement : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight; 
    [SerializeField] WheelCollider backLeft; 
    [SerializeField] WheelCollider backRight;

    [SerializeField] Transform frontLeftT;
    [SerializeField] Transform frontRightT;
    [SerializeField] Transform backLeftT;
    [SerializeField] Transform backRightT;

    public Vector3? targetPosition = null;

    private static float previousTargetPositionx;
    private static float previousTargetPositionz;

    Vector2 previousTargetPosition;

    Vector2 currentTargetPosition;
    public TMP_InputField xInput;
    public TMP_InputField zInput;

    float torque = 100f; 
    float speed = 5f;
    float brakeForce = 500f; // You can adjust this value as needed
    float closeEnoughDistance = 1.0f; // You can adjust this value as needed

     float distanceToTarget = 0f;
    float acceleration = 1.0f;
    private float currentSpeed = 0f;

    public void MoveObjectFromInput()
    {
        SetTargetPositionFromInput();
    }

    void Update()
    {
        // Apply a constant downward force to keep the car grounded
        GetComponent<Rigidbody>().AddForce(0, -10, 0, ForceMode.Acceleration);

        if (targetPosition != null)
        {

            currentTargetPosition = new Vector2(targetPosition.Value.x, targetPosition.Value.z);
            distanceToTarget = Vector3.Distance(transform.position, targetPosition.Value);

            if (distanceToTarget > closeEnoughDistance && previousTargetPosition != currentTargetPosition)
            {
                Debug.Log(previousTargetPosition != currentTargetPosition);
                MoveToTarget();
            }
            else
            {
                StopMoving();
            }
        }
    }

    private void SetTargetPositionFromInput()
    {
        float xPosition = float.Parse(xInput.text);
        float zPosition = float.Parse(zInput.text);

        Ray ray = new Ray(new Vector3(xPosition, 100, zPosition), Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
        }
    }

   

   private void MoveToTarget()
{
    Debug.Log("Current target position: " + currentTargetPosition + " Previous target position: " + previousTargetPosition);

    ReleaseBrakes();

    currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, speed);

    // Calculate the direction to the target
    Vector3 directionToTarget = (targetPosition.Value - transform.position).normalized;

    // Calculate the new position
    Vector3 newPosition = transform.position + directionToTarget * currentSpeed * Time.deltaTime;

    // Move the car to the new position
    GetComponent<Rigidbody>().MovePosition(newPosition);

    // Apply a downward force to keep the car grounded
    GetComponent<Rigidbody>().AddForce(0, -10, 0, ForceMode.Acceleration);

    ApplyTorqueToWheels();

    UpdateWheelPositions();
}

    private void StopMoving()
    {
        UpdatePreviousTargetPosition();

        Debug.Log("Previous target position: " + previousTargetPosition);

        ApplyBrakes();

        targetPosition = null; // Stop moving the object

        StopPhysicalMovement();

        currentSpeed = 0f;

        StopApplyingTorqueToWheels();
    }

    private void ReleaseBrakes()
    {
        frontLeft.brakeTorque = 0;
        frontRight.brakeTorque = 0;
        backLeft.brakeTorque = 0;
        backRight.brakeTorque = 0;
    }

    private void RotateTowardsTarget()
    {
        Vector3 directionToTarget = (targetPosition.Value - transform.position).normalized;

        // Check if the direction to the target is not a zero vector
        if (directionToTarget != Vector3.zero)
        {
            // Calculate a rotation that faces the target position
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Apply the rotation to the car's transform
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

    private void ApplyTorqueToWheels()
    {
        frontLeft.motorTorque = torque;
        frontRight.motorTorque = torque;
        backLeft.motorTorque = torque;
        backRight.motorTorque = torque;
    }

    private void UpdateWheelPositions()
    {
        UpdateWheel(frontLeft, frontLeftT);
        UpdateWheel(frontRight, frontRightT);
        UpdateWheel(backLeft, backLeftT);
        UpdateWheel(backRight, backRightT);
    }

    private void UpdatePreviousTargetPosition()
    {
        previousTargetPositionx = targetPosition.Value.x;
        previousTargetPositionz = targetPosition.Value.z;
        previousTargetPosition = new Vector2(previousTargetPositionx, previousTargetPositionz);
    }

    private void ApplyBrakes()
    {
        frontLeft.brakeTorque = brakeForce;
        frontRight.brakeTorque = brakeForce;
        backLeft.brakeTorque = brakeForce;
        backRight.brakeTorque = brakeForce;
    }

    private void StopPhysicalMovement()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void StopApplyingTorqueToWheels()
    {
        frontLeft.motorTorque = 0;
        frontRight.motorTorque = 0;
        backLeft.motorTorque = 0;
        backRight.motorTorque = 0;
    }

    void UpdateWheel(WheelCollider col, Transform t)
    {
        Vector3 pos;
        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        t.position = pos;
        t.rotation = rot;
    }
}