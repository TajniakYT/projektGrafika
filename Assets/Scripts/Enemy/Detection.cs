using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum DetectionState { 
    Waiting, 
    Searching, 
    Following, 
    Attacking 
};

public interface IAttackable
{
    void Attack();
}


public class Detection : MonoBehaviour
{
    public DetectionState startingState = DetectionState.Waiting;
    private DetectionState currentState;

    public float detectionRadius = 5f;
    private Transform player;
    private float shootingDistance;

    private IAttackable attackable;
    private ObjectProperties objectProperties;

    public DetectionState GetCurrentState()
    {
        return currentState;
    }

    private void Start()
    {
        currentState = startingState;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null) Debug.LogError("Player not found");
        objectProperties = GetComponent<ObjectProperties>();
        if (objectProperties != null)
        {
            shootingDistance = objectProperties.shootingDistance;
        }
        else
        {
            Debug.LogError("ObjectProperties script not found!");
        }

        attackable = GetComponent<IAttackable>();
        if (attackable == null)
        {
            Debug.LogWarning("IAttackable not implemented on this enemy!");
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        switch (currentState)
        {
            case DetectionState.Waiting:
            case DetectionState.Searching:
                if (distanceToPlayer <= detectionRadius)
                {
                    currentState = DetectionState.Following;
                }
                break;

            case DetectionState.Following:
                if (distanceToPlayer <= shootingDistance)
                {
                    currentState = DetectionState.Attacking;
                }
                else if (distanceToPlayer > detectionRadius)
                {
                    currentState = startingState; // Return to initial DetectionState
                }
                break;

            case DetectionState.Attacking:
                if (distanceToPlayer > shootingDistance)
                {
                    currentState = DetectionState.Following;
                }
                else
                {
                    attackable?.Attack();
                }
                break;
        }
    }

    // Optional: Visualize detection radius in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        if (objectProperties != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, objectProperties.shootingDistance);
        }
    }
}
