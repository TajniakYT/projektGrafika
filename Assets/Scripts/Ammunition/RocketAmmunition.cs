using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmunition : MonoBehaviour, IBulletBehavior
{

    public void Shoot(Vector3 targetPosition, Transform firePoint, GameObject bulletPrefab)
    {
        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Loop through each enemy and find the closest to the target position
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(targetPosition, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
       // Debug.LogError("found enemy." + closestEnemy.name);
        // Determine direction from fire point to target position
        Vector3 direction = (targetPosition - firePoint.position).normalized;

        // Instantiate the missile
        GameObject missile = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
      
        // Assign closest enemy to the missile script
        HomingMissileScript missileScript = missile.GetComponent<HomingMissileScript>();
        if (missileScript != null)
        {
            missileScript.target = closestEnemy.transform;
        }
        Destroy(missile, missile.GetComponent<BulletProperties>().lifetime);
       
    }


}
