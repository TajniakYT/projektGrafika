
using UnityEngine;
using System;

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

    void OnDestroy()
    {
        try
        {
            Transform lightTransform = target.Find("Marked");
            if (lightTransform != null)
            {
                Light pointLight = lightTransform.GetComponent<Light>();
                if (pointLight != null)
                {
                    pointLight.enabled = false; // lub false, aby wy³¹czyæ
                }
            }
        }catch(Exception e)
        {
            Debug.Log(e);
        }
    }
}
