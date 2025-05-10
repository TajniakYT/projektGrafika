using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class HelicopterController : MonoBehaviour
{
    public float acceleration = 20f;
    public float maxSpeed = 10f;
    public float rotationSpeed = 10f;
    public float friction = 10f;

    public TMP_Text timerText;
    private float timeElapsed;

    private Vector3 velocity = Vector3.zero;
    private Vector3 inputDirection = Vector3.zero;

    void Update()
    {
       // timeElapsed += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
       // timerText.text = $"{seconds:000}";

        // Input for either keyboard or controller
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Accelerate
        if (inputDirection != Vector3.zero)
        {
            velocity += inputDirection * acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            // Friction
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, friction * Time.deltaTime);
        }

        // Move
        Vector3 movement = velocity * Time.deltaTime;
        transform.position += movement;

        // Rotate toward movement
        if (velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("Hit: " + collision.gameObject.name);
        velocity = Vector3.Reflect(velocity, collision.contacts[0].normal) * 0.5f;
    }

    public Slider healthSlider;

    void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    //public Image weaponIcon;
    public Sprite rocketSprite;
    public Sprite minigunSprite;

    void SwitchWeapon(int weaponId)
    {
        //if (weaponId == 0) weaponIcon.sprite = rocketSprite;
        //if (weaponId == 1) weaponIcon.sprite = minigunSprite;
    }

    public TMP_Text scoreText;
    private int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public TMP_Text objectiveText;

    public void SetObjective(string newObjective)
    {
        objectiveText.text = "Objective: " + newObjective;
    }
}