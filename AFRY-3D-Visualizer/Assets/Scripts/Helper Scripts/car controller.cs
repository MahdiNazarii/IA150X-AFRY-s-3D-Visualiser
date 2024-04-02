using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight; 
    [SerializeField] WheelCollider backLeft; 
    [SerializeField] WheelCollider backRight;

    [SerializeField] Transform frontLeftT;
    [SerializeField] Transform frontRightT;
    [SerializeField] Transform backLeftT;
    [SerializeField] Transform backRightT;


    public float acceleration = 500f;
    public float breakingForce = 500f;
    public float maxSteerAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentSteerAngle = 0f;

    public float torqueMultiplier = 2.0f; 


    private void FixedUpdate(){

        // Move forward and backward from the vertical axis
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // Break
        if(Input.GetKey(KeyCode.Space)){
            currentBreakForce = breakingForce;  
        }else{  
            currentBreakForce = 0f;
        }

        // Apply acceleration with a torque multiplier
        frontLeft.motorTorque = currentAcceleration * torqueMultiplier;
        frontRight.motorTorque = currentAcceleration * torqueMultiplier;
        backLeft.motorTorque = currentAcceleration * torqueMultiplier;
        backRight.motorTorque = currentAcceleration * torqueMultiplier;

        // Apply breaking
        frontLeft.brakeTorque = currentBreakForce;
        frontRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;

        // Steer left and right from the horizontal axis
        currentSteerAngle = maxSteerAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentSteerAngle;
        frontRight.steerAngle = currentSteerAngle;

        // Update wheel position
        UpdateWheel(frontLeft, frontLeftT);
        UpdateWheel(frontRight, frontRightT);
        UpdateWheel(backLeft, backLeftT);
        UpdateWheel(backRight, backRightT);
    }

    void UpdateWheel(WheelCollider col, Transform t){
        Vector3 pos;
        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        t.position = pos;
        t.rotation = rot;
    }
}
