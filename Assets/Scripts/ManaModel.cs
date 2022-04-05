using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaModel : MonoBehaviour
{
    public float maxManaPoints;
    [SerializeField] 
    private float _currentManaPoints;
    public float currentManaPoints
    {
        get => _currentManaPoints;
        set => _currentManaPoints = Math.Min(Math.Max(0, value), maxManaPoints);
    }
    public float regenerationRate = 1;
    public ManaView manaView;

    public void Use(float cost)
    {
        currentManaPoints -= cost;
    }

    private void Regenerate()
    {
        if (currentManaPoints < maxManaPoints)
        {
            currentManaPoints += regenerationRate * Time.deltaTime;  
        }
    }

    private void Start()
    {
        Paint();
    }

    void Update()
    {
        Regenerate();
        Paint();
    }

    private void Paint()
    {
        if (manaView != null) manaView.UpdateView(_currentManaPoints, maxManaPoints);
    }
}
