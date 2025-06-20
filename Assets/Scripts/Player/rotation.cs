using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class rotation : MonoBehaviour
{
    public enum Axis
    {
        x,
        y,
        z
    }
    public Axis rotationAxis;
    private float bladeSpeed = 500;
    public bool inverseRotation = false;
    private Vector3 Rotation;
    float rotateDegree;
    // Start is called before the first frame update
    void Start()
    {
        Rotation = transform.localEulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        if (inverseRotation)
            rotateDegree -= bladeSpeed * Time.deltaTime;
        else
            rotateDegree += bladeSpeed * Time.deltaTime;
        rotateDegree = rotateDegree % 360;
        switch (rotationAxis)
        {
            case Axis.y:
                transform.localRotation = Quaternion.Euler(Rotation.x, rotateDegree, Rotation.z);
                break;
            case Axis.z:
                transform.localRotation= Quaternion.Euler(Rotation.x, Rotation.y, rotateDegree);
                break;
            default:
                transform.localRotation = Quaternion.Euler(rotateDegree, Rotation.y, Rotation.z);
                break;
        }
    } 
}
