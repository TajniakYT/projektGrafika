using UnityEngine;

public class HomingMissileScript : MonoBehaviour
{
    public Transform target;
    public float speed = 20f;
    public float turnSpeed = 5f; // w radianach na sekundê

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized * speed;
    }

    void FixedUpdate()
    {
        Vector3 forward = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;

        if (target != null)
        {
            Vector3 directionToTarget = (target.position - transform.position);
            directionToTarget.y = 0f; 
            directionToTarget.Normalize();

            Vector3 newDirection = Vector3.RotateTowards(forward, directionToTarget, turnSpeed * Time.fixedDeltaTime, 0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            rb.velocity = newDirection * speed;
        }
        else
        {
            rb.velocity = forward * speed;
        }
    }
}
