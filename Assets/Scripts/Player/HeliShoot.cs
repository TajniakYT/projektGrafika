
using UnityEngine;



public class HeliShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject heli;
    public float shootInterval = 0.2f; // Adjust for firing rate
    public Transform firePoint; // Assign in Inspector
    public UnityEngine.Camera mainCamera; // Assign in Inspector

    private float shootTimer = 0f;
    private float bulletSpeed;
    private float bulletLifetime;

    void Awake()
    {
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
            Vector3? targetPos = GetMouseWorldPosition();
            if (targetPos.HasValue)
            {
                Shoot(targetPos.Value);
                shootTimer = 0f;
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