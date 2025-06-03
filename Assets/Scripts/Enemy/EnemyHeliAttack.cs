using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeliAttack : MonoBehaviour
{
   // public float strafeSpeed = 2f; // Speed of orbiting/swaying motion

    private Transform player;
    private Detection detection;
    private ObjectProperties objectProperties;
    private int counter=0;
    private float oscilator = -1.0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        detection = GetComponent<Detection>();
        objectProperties = GetComponent<ObjectProperties>();
    }

    void FixedUpdate()
    {
        if (player == null || detection == null || objectProperties == null)
            return;

        if (detection.GetCurrentState() == DetectionState.Attacking)
        {
            OrbitWithinAngle();
        }
    }

    void OrbitWithinAngle()
    {
        counter++;
        if (counter >= 45) {oscilator *= -1;counter = 0; }
        float radius = objectProperties.shootingDistance-0.1f;


        // Direction from player to this enemy (flattened)
        Vector3 toEnemy = transform.position - player.position;
        toEnemy.y = 0f;
        toEnemy.Normalize();

        // Rotate that direction by the oscillating angle
        Vector3 offset = Quaternion.Euler(0f, oscilator*1f, 0f) * toEnemy * radius;

        // Set new position with fixed Y
        Vector3 newPosition = player.position + offset;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // Face the player
        Vector3 lookDir = player.position - transform.position;
        lookDir.y = 0f;
        if (lookDir != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
