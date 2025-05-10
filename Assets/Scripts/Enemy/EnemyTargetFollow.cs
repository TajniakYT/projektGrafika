using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Target;    // Assign your Target GameObject here
    public float moveSpeed = 5f;  // Movement speed
    public float rotationSpeed = 5f; // How quickly it rotates

    void Update()
    {
        if (Target == null) return;

        // Rotate to face the Target
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Move towards the Target
        // transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
