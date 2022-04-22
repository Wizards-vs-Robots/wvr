using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damagable : MonoBehaviour
{
    public DamageCooldownAction damageCooldownAction;
    private HealthModel _health;

    public void Start()
    {
        _health = GetComponent<HealthModel>();
        if (damageCooldownAction != null)
            damageCooldownAction.Start();
    }
    
    public Vector3 GetLocation()
    {
        return transform.position;
    }

    public void ReceiveDamage(Damage damage)
    {
        
        if (damageCooldownAction != null) 
        {
            // Still waiting before damage protection wears off
            if (damageCooldownAction.waiting)
                return;
            else
                damageCooldownAction.Trigger();
        }

        _health.currentHealthPoints -= damage.amount;
        if (_health.currentHealthPoints <= 0) //Shit dies here, maybe it should die in healthModel?
        {
            if (gameObject.CompareTag("Attacker"))
            {
                GameObject waveManagerObject = GameObject.FindGameObjectsWithTag("WaveManager")[0];
                WaveManager waveManager = waveManagerObject.GetComponent<WaveManager>();
                waveManager.ReportDeath(gameObject);
            }
            if (gameObject.CompareTag("Player"))
            {
                Highscores.SaveHighscore();
                SceneManager.LoadScene(0); //If player dies, goto main menu
                return;
            }
            Destroy(gameObject);
        }
    }
}
