using UnityEngine;

// Base class for all objects with these properties
public class ObjectProperties : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float movementSpeed = 5f;
    public float shield = 0f;
    public ScoreCounter scoreCounter;
    public void TakeDamage(float damage)
    {

        if (shield > 0)
        {
            shield -= damage;
            if (shield < 0)
            {
                health += shield;
                shield = 0;
            }
        }
        else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public float getLife()
    {
        return health;
    }

    public float getMaxLife()
    {
        return maxHealth;
    }


    // Method for object death
    protected virtual void Die()
    {
        scoreCounter.AddScore(100);
        Destroy(gameObject); 
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