using UnityEngine;

[System.Serializable]
public class BulletType
{
    public GameObject bulletPrefab;
}

public class EnemyShoot : MonoBehaviour
{
    public Transform Target;
    public BulletType currentBullet;
    public float shootInterval = 2f;
    public Transform firePoint; // Assign your specific fire point Transform in the Inspector

    private float shootTimer = 0f;
    private Vector3 firePointOffset = Vector3.zero; // Store the calculated offset
    private float bulletSpeed;
    private float bulletLifetime;

    void OnValidate()
    {
        // This function is called in the editor when the script or its public variables change.
        // It's useful for updating things when you make adjustments in the Inspector.
        CacheFirePointOffset();
        GetBulletProperties(); // Get bullet properties in OnValidate
    }

    void Awake()
    {
        // Awake is called once when the script instance is being loaded.
        CacheFirePointOffset();
        GetBulletProperties(); // Get bullet properties in Awake
    }

    void CacheFirePointOffset()
    {
        //if (firePoint != null)
        //{
        //    switch (firePoint.name)
        //    {
        //        case "cannonMuzzle":
        //            firePointOffset = Vector3.forward * 0.5f;
        //            break;
        //        case "leftWingTip":
        //            firePointOffset = Vector3.left * 0.3f + Vector3.forward * 0.1f;
        //            break;
        //        case "rightWingTip":
        //            firePointOffset = Vector3.right * 0.3f + Vector3.forward * 0.1f;
        //            break;
        //        default:
        //            UnityEngine.Debug.LogWarning("No specific offset defined for fire point: " + firePoint.name);
        //            firePointOffset = Vector3.zero;
        //            break;
        //    }
        //}
        //else
        //{
        //    firePointOffset = Vector3.zero;
        //}
    }

    void GetBulletProperties()
    {
        if (currentBullet != null && currentBullet.bulletPrefab != null)
        {
            BulletProperties bulletProperties = currentBullet.bulletPrefab.GetComponent<BulletProperties>();
            if (bulletProperties != null)
            {
                bulletSpeed = bulletProperties.speed;
                bulletLifetime = bulletProperties.lifetime;
            }
            else
            {
                UnityEngine.Debug.LogError("Bullet Prefab '" + currentBullet.bulletPrefab.name + "' is missing the BulletProperties component!");
                bulletSpeed = 0f;
                bulletLifetime = 0f;
            }
        }
        else
        {
            bulletSpeed = 0f;
            bulletLifetime = 0f;
        }
    }

    void Update()
    {
        //check if enemy should be attacking if not return
        if (!(GetComponent<Detection>().GetCurrentState() == DetectionState.Attacking)) return;

        if (Target == null || currentBullet.bulletPrefab == null || firePoint == null) return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        IBulletBehavior bulletBehavior = currentBullet.bulletPrefab.GetComponent<IBulletBehavior>();
        if (bulletBehavior != null)
        {
            bulletBehavior.Shoot(Target.position, firePoint, currentBullet.bulletPrefab);
        }
    }
}
