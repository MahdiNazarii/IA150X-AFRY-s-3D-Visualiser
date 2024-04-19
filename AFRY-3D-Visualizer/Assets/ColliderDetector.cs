using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public string tagsToCollideWith = "miningEnvironment"; // Tags of objects to collide with
    public bool canMove = true; // Flag to control camera movement

    public GameObject cameraTarget;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagsToCollideWith)
        {
            // If so, set canMove to false
            cameraTarget.GetComponent<CameraControllerOld>().canMove = false;
           
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == tagsToCollideWith)
        {
            cameraTarget.GetComponent<CameraControllerOld>().canMove = true;
            
        }
        
    }
}