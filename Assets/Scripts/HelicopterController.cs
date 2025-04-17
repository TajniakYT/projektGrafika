using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public float acceleration = 20f;
    public float maxSpeed = 10f;
    public float rotationSpeed = 10f;
    public float friction = 10f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 inputDirection = Vector3.zero;

    void Update()
    {
        // Get input
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1f;
        if (Input.GetKey(KeyCode.S)) moveZ -= 1f;
        if (Input.GetKey(KeyCode.D)) moveX += 1f;
        if (Input.GetKey(KeyCode.A)) moveX -= 1f;

        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Accelerate
        if (inputDirection != Vector3.zero)
        {
            velocity += inputDirection * acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            // Apply friction when no input
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, friction * Time.deltaTime);
        }

        // Move
        Vector3 movement = velocity * Time.deltaTime;
        transform.position += movement;

        // Rotate toward movement
        if (velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);

        // Optional: Stop movement on collision
        //velocity = Vector3.zero;
        velocity = Vector3.Reflect(velocity, collision.contacts[0].normal) * 0.5f;
        // Optional: Bounce back slightly
        //velocity = -velocity * 0.1f;
    }
}
