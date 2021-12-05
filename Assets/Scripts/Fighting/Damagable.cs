using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    private HealthModel _health;

    public void Start()
    {
        _health = this.GetComponent<HealthModel>();
    }
    
    public Vector3 GetLocation()
    {
        return this.transform.position;
    }

    public void ReceiveDamage(Damage damage)
    {
        _health.currentHealthPoints -= damage.amount;
    }

    public void Update()
    {
        // TODO: perform animation (maybe)
    }
}
