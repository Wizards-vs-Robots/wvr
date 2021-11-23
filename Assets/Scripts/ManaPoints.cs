using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPoints : MonoBehaviour
{
    [SerializeField] 
    private float _currentManaPoints;
    
    public float currentManaPoints
    {
        get => _currentManaPoints;
        set
        {
            _currentManaPoints = Math.Min(Math.Max(0, value), maxManaPoints);
            if (manaBar	!= null) manaBar.UpdateManaBar(_currentManaPoints, maxManaPoints);
        }
    }
    
    public float maxManaPoints;
    public float regenerationRate = 1;
    public ManaBar manaBar;

    public void UseMana(float cost)
    {
        currentManaPoints -= cost;
        manaBar.UpdateManaBar(currentManaPoints, maxManaPoints);
    }

    private void ManaRegen()
    {
        if (currentManaPoints < maxManaPoints)
        {
            currentManaPoints += regenerationRate * Time.deltaTime;  
            manaBar.UpdateManaBar(currentManaPoints, maxManaPoints);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            UseMana(10);
        }
        ManaRegen();
    }
}
