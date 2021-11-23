using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] 
    private float _currentHealthPoints;

    public float currentHealthPoints
    {
        get => _currentHealthPoints;
        set => _currentHealthPoints = Math.Min(Math.Max(0, value), maxHealthPoints);
    }

    public float maxHealthPoints;
}
