using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

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
        // Input for either keyboard or controller
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Accelerate
        if (inputDirection != Vector3.zero)
        {
            velocity += inputDirection * acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            // Friction
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

    public TMP_Text objectiveText;

    public void SetObjective(string newObjective)
    {
        objectiveText.text = "Objective: " + newObjective;
    }

    public Vector3 getSpeed()
    {
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        return velocity;
    }
}