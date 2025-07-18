
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private ObjectProperties objectProperties; //  Reference to the ObjectProperties component on *this* GameObject.
    private HealthbarController healthbarController;
    private void Awake()
    {
        // Get the ObjectProperties component on this GameObject.
        objectProperties = GetComponent<ObjectProperties>();
        if (objectProperties == null)
        {
            Debug.LogError("ObjectProperties component not found on the same GameObject as CollisionHandler!");
            enabled = false; // Disable this script if ObjectProperties is missing.
            return;
        }
        healthbarController = GetComponent<HealthbarController>();

        if (healthbarController == null)
        {
            Debug.LogError("HealthbarController component not found on the same GameObject!");
            enabled = false; // Disable this script if ObjectProperties is missing.
            return;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //  Call the appropriate function based on what we collided with.
        if (collision.gameObject.tag == "Bullet")
        {
            HandleEnemyCollision(collision);
        }
        else if (collision.gameObject.tag == "Ammunition")
        {
            HandleEnemyCollision(collision);
        }
        else if (collision.gameObject.tag == "Pickup")
        {
        }
        else
        {
            HandleDefaultCollision(collision); // Handle any other type of collision
        }
    }

    private void HandleEnemyCollision(Collision collision)
    {
        Debug.Log("Collided with enemy projectile: " + collision.gameObject.name);

        float damage = 0f;

        if (collision.gameObject.TryGetComponent<BulletProperties>(out var bullet))
        {
            damage = bullet.damage;
        }        
        else
        {
            Debug.LogWarning("No damage component found on: " + collision.gameObject.name);
            return;
        }

        objectProperties.TakeDamage(damage);
        healthbarController.UpdateHealthbar(objectProperties.getLife(), objectProperties.getMaxLife());

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal) * 0.5f;
        }

        Destroy(collision.gameObject);
    }

    private void HandleDefaultCollision(Collision collision)
    {
        UnityEngine.Debug.Log("Collided with: " + collision.gameObject.name);
        Rigidbody rb = GetComponent<Rigidbody>(); // Get the Rigidbody of this object.
        if (rb != null)
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal) * 0.5f;
        }
    }
}
