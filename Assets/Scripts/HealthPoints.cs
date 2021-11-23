using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float currentHealthPoints;
    public float maxHealthPoints;
    public float shieldPoints;
    public HealthBar healthBar;

    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage;
        healthBar.UpdateHealthBar();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            TakeDamage(10);
        }
    }
}
