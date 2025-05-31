using UnityEngine;

public class EnemyMissileLauncher : MonoBehaviour
{
    public Transform Target;
    public GameObject missilePrefab;
    public Transform firePoint;
    public float shootInterval = 3f;

    private float shootTimer = 0f;

    void Update()
    {
        if (Target == null || missilePrefab == null || firePoint == null) return;

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            LaunchMissile();
            shootTimer = 0f;
        }
    }

    void LaunchMissile()
    {
        GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);

        HomingMissileScript missileScript = missile.GetComponent<HomingMissileScript>();
        if (missileScript != null)
        {
            missileScript.target = Target;
        }
    }
}