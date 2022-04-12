using System;
using System.Collections;
using System.Collections.Generic;
using Fighting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damagable : MonoBehaviour
{
    private HealthModel _health;

    public void Start()
    {
        _health = GetComponent<HealthModel>();
    }
    
    public Vector3 GetLocation()
    {
        return transform.position;
    }

    /// <summary>
    ///     
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>true if the entity was destroyed by the damage, false otherwise</returns>
    public bool ReceiveDamage(Damage damage)
    {
        _health.currentHealthPoints -= damage.amount;
        if (_health.currentHealthPoints == 0) //Shit dies here, maybe it should die in healthModel?
        {
            if (gameObject.CompareTag("Attacker"))
            {
                GameObject waveManagerObject = GameObject.FindGameObjectsWithTag("WaveManager")[0];
                WaveManager waveManager = waveManagerObject.GetComponent<WaveManager>();
                waveManager.ReportDeath(gameObject);
            }
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(0); //If player dies, goto main menu
            }
            else
            {
                Destroy(gameObject);
            }
            return true;
        }
        return false;
    }

    public void Update()
    {
        // TODO: perform animation (maybe)
    }
}
