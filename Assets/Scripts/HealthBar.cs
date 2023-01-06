using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int currentHealth;
    public int maxHealth = 50;


    private void Start()
    {
        SetMaxHealth();
    }


    public void SetMaxHealth()
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        currentHealth = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void ChangeHealth(int damage)
    {
        currentHealth += damage;
        slider.value = currentHealth;
    }

}
