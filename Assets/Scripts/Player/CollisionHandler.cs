
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public ObjectProperties objectProperties; //  Reference to the ObjectProperties component on *this* GameObject.

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        //  Call the appropriate function based on what we collided with.
        if (collision.gameObject.tag == "Bullet")
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
        Debug.Log("Collided with a bullet: " + collision.gameObject.name);
        objectProperties.TakeDamage(collision.gameObject.GetComponent<BulletProperties>().damage);
       

        Rigidbody rb = GetComponent<Rigidbody>(); // Get the Rigidbody of this object.
        if (rb != null)
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal) * 0.5f;
        }
    }

  

    private void HandleDefaultCollision(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        Rigidbody rb = GetComponent<Rigidbody>(); // Get the Rigidbody of this object.
        if (rb != null)
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal) * 0.5f;
        }
    }
}

