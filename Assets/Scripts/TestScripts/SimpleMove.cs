using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float moveStep = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.Translate(Vector3.right * moveStep);

            if (transform.position.x >= startPosition.x + distance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * moveStep);

            if (transform.position.x <= startPosition.x - distance)
                movingRight = true;
        }
    }
}
