using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public Image Healthbar;
    public Canvas healthbarCanvas;
    public bool hideWhenFull = true;

    private ObjectProperties objectProperties;
    // Start is called before the first frame update
    void Start()
    {
        objectProperties = GetComponent<ObjectProperties>();
        if (objectProperties != null)
        {
            UpdateHealthbar(objectProperties.getLife(), objectProperties.getMaxLife());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthbar(float currentHealth, float maxHealth)
    {
        float fillAmount = Mathf.Lerp(0.23f, 0.77f, currentHealth / maxHealth);
        Healthbar.fillAmount = fillAmount;

        if (hideWhenFull && healthbarCanvas != null)
        {
            healthbarCanvas.enabled = currentHealth < maxHealth;
        }
    }
}