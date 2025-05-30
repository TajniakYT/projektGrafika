
using UnityEngine;



public class HeliShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject heli;
    public float shootInterval = 0.2f;
    public Transform firePoint;
    public UnityEngine.Camera mainCamera;

    private float shootTimer = 0f;
    private float bulletSpeed;
    private float bulletLifetime;
    private Vector3 lastHeliPosition;
    void Awake()
    {
        lastHeliPosition = heli.transform.position;
        if (mainCamera == null)
            Debug.LogError("Source: HeliShoot - no camera found");
        GetBulletProperties();
    }

    void GetBulletProperties()
    {
        if (bulletPrefab != null)
        {
            BulletProperties bulletProperties = bulletPrefab.GetComponent<BulletProperties>();
            if (bulletProperties != null)
            {
                bulletSpeed = bulletProperties.speed;
                UnityEngine.Debug.Log(bulletSpeed);
                bulletLifetime = bulletProperties.lifetime;
            }
            else
            {
                Debug.LogError("Bullet prefab is missing BulletProperties.");
                bulletSpeed = 0f;
                bulletLifetime = 0f;
            }
        }
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= shootInterval)
        {
            Vector3 currentPos = heli.transform.position;
            Vector3? targetPos = GetMouseWorldPosition();
            Vector3 aimDir = (targetPos.Value - transform.position).normalized;
            Vector3 moveDir = (currentPos - lastHeliPosition).normalized;
            lastHeliPosition = heli.transform.position;
            Vector3 directionReference = moveDir != Vector3.zero ? moveDir : heli.transform.forward;

            float cosAngle = Vector3.Dot(directionReference, aimDir);
            if (cosAngle > 0f)
            {
                if (targetPos.HasValue)
                {
                    Shoot(targetPos.Value);
                    shootTimer = 0f;
                }
            }
        }
    }

    Vector3? GetMouseWorldPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Change if not using y=0 as ground

        if (groundPlane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        return null;
    }

    void Shoot(Vector3 targetPosition)
    {
        Vector3 spawnPosition = firePoint.position;
        Vector3 direction = (targetPosition - spawnPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.LookRotation(direction));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            HelicopterController helicopterProperties = heli.GetComponent<HelicopterController>();
            bulletRb.velocity = direction * bulletSpeed + helicopterProperties.getSpeed();
        }

        Destroy(bullet, bulletLifetime);
    }
}