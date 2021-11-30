using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    public HealthView healthView;
    public float maxHealthPoints;
    
    [SerializeField] 
    private float _currentHealthPoints;
    public float currentHealthPoints
    {
        get => _currentHealthPoints;
        set
        {
            _currentHealthPoints = Math.Min(Math.Max(0, value), maxHealthPoints);
            if (healthView != null) 
                healthView.UpdateView(currentHealthPoints, maxHealthPoints);
        }
    }

    public void Start()
    {
        if (healthView != null) {
            healthView.UpdateView(currentHealthPoints, maxHealthPoints);
        }
    }

}
