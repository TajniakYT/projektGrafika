using System.Net.NetworkInformation;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Target;    // Assign your Target GameObject here
    private float moveSpeed=0;  // Movement speed
    public float rotationSpeed = 5f; // How quickly it rotates

    private float speed;

    void Start()
    {
        speed = GetComponent<ObjectProperties>().movementSpeed;
    }
    void FixedUpdate()
    {
        if (Target == null) return;
        var state = GetComponent<Detection>().GetCurrentState();
        if (state == DetectionState.Waiting || state== DetectionState.Searching) return;
        moveSpeed = (state == DetectionState.Following) ? speed : 0f;



        // Rotate to face the Target
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Move towards the Target
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
