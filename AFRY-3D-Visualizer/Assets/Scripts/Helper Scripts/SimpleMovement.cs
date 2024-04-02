using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Transform target; // The target to move towards
    public float moveSpeed = 5f; // Movement speed of the capsule

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Calculate direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Move the capsule towards the target using physics
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);

        // Rotate the capsule to face the target (optional)
        RotateTowardsTarget(direction);
    }

    void RotateTowardsTarget(Vector3 direction)
    {
        // Create a rotation to look towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}
