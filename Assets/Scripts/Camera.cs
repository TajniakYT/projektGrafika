using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -15f);
    public float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.rotation = Quaternion.Euler(30f, -37f, 0f); // Fixed angle
    }
}
