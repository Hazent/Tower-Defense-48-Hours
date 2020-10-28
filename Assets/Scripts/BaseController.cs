using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    public float health;
    private float currentHealth;
    public Image healthbar;
    private float lerpSpeed = 5f;

    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount, currentHealth / health, lerpSpeed * Time.deltaTime);

        if(currentHealth <= 0)
        {
            BaseDown();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    private void BaseDown()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}
