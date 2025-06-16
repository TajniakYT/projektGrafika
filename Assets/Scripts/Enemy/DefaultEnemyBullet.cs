using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultEnemyBullet : MonoBehaviour, IBulletBehavior
{
    // Start is called before the first frame update
    public void Shoot(Vector3 targetPosition, Transform firePoint, GameObject bulletPrefab)
    {
        Vector3 spawnPosition = firePoint.position;
        Vector3 direction = (targetPosition - spawnPosition).normalized;
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.LookRotation(direction));

        BulletProperties bp = bullet.GetComponent<BulletProperties>();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            // HelicopterController helicopterProperties = heli.GetComponent<HelicopterController>();
            bulletRb.velocity = direction * bp.speed;//+ helicopterProperties.getSpeed();
        }

        Destroy(bullet, bp.lifetime);
    }

}


