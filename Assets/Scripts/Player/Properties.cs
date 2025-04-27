using UnityEngine;

// Base class for all objects with these properties
public class ObjectProperties : MonoBehaviour
{
    public float life = 100f;
    public float movementSpeed = 5f;
    public float shield = 0f;

    // Method to take damage
    public void TakeDamage(float damage)
    {
        if (shield > 0)
        {
            shield -= damage;
            if (shield < 0)
            {
                life += shield; // Remaining damage goes to life
                shield = 0;
            }
        }
        else
        {
            life -= damage;
        }

        if (life <= 0)
        {
            Die();
        }
    }

    // Method for object death
    protected virtual void Die()
    {
        
        //Destroy(gameObject); 
    }

    public virtual void RepairShield(float repairAmount)
    {
        shield += repairAmount;

        if (shield > 100f)  
        {
            shield = 100f;
        }
    }
    public virtual void PickUpSpeedBoost(float boostAmount, float duration)
    {
        movementSpeed += boostAmount;
        StartCoroutine(ResetSpeedAfterDuration(boostAmount, duration));
    }

    private System.Collections.IEnumerator ResetSpeedAfterDuration(float boostAmount, float duration)
    {
        yield return new WaitForSeconds(duration);
        movementSpeed -= boostAmount;
    }
}
