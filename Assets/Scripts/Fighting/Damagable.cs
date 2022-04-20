using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damagable : MonoBehaviour
{
    public TakeDamageAction takeDamageAction;
    private HealthModel _health;

    public void Start()
    {
        _health = GetComponent<HealthModel>();
    }
    
    public Vector3 GetLocation()
    {
        return transform.position;
    }

    public void ReceiveDamage(Damage damage)
    {
        if (takeDamageAction != null) 
        {
            // Still waiting before damage protection wears off
            if (takeDamageAction.waiting)
                return;
            else
                takeDamageAction.Trigger();
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

    public void Update()
    {
        // TODO: perform animation (maybe)
    }
}
