using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaModel : MonoBehaviour
{
    public float maxManaPoints;
    public float regenerationRate = 1;
    public ManaView manaView;
    public GameObject owner;

    [SerializeField] 
    private float _currentManaPoints;
    public float currentManaPoints
    {
        get => _currentManaPoints;
        set
        {
            _currentManaPoints = Math.Min(Math.Max(0, value), maxManaPoints);
            if (manaView != null)
                manaView.UpdateView(_currentManaPoints, maxManaPoints);
        }
    }

    public void Use(float cost)
    {
        currentManaPoints -= cost;
        manaView.UpdateView(currentManaPoints, maxManaPoints);
    }

    private void Regenerate()
    {
        if (currentManaPoints < maxManaPoints)
        {
            currentManaPoints += regenerationRate * Time.deltaTime;  
            manaView.UpdateView(currentManaPoints, maxManaPoints);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            //TEST: REPORTING DEATH TO WAVEMANAGER
            GameObject[] attackers = GameObject.FindGameObjectsWithTag("Attacker");
            GameObject waveManagerObject = GameObject.FindGameObjectsWithTag("WaveManager")[0];
            WaveManager waveManager = waveManagerObject.GetComponent<WaveManager>();

            foreach (GameObject attacker in attackers) {
                if (Vector3.Distance(attacker.transform.position, owner.transform.position) < 1F) {
                    waveManager.ReportDeath(attacker);
                }
            }
            //TEST DONE
            
            Use(10);
        }

        Regenerate();
    }
}
