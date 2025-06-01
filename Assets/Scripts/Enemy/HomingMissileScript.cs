using UnityEngine;

public class HomingMissileScript : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 90f;
    public float lifetime = 5f;
    public float maxTrackingAngle = 60f;
    public float damage = 20f;
    public Transform target;

    private float currentLifetime = 0f;

    void Update()
    {
        currentLifetime += Time.deltaTime;

        if (target != null)
        {
            Vector3 toTarget = (target.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, toTarget);

            if (angle <= maxTrackingAngle)
            {
                Quaternion targetRot = Quaternion.LookRotation(toTarget);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
            }
            else
            {
                target = null;
            }
        }

        transform.position += transform.forward * speed * Time.deltaTime;

        
        Destroy(gameObject,lifetime);
        
    }
}