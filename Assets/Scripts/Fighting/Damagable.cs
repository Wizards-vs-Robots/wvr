using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public Vector3 GetLocation()
    {
        return this.transform.position;
    }

    public void ReceiveDamage(Damage damage)
    {
        // TODO: manipulate health
    }

    public void Update()
    {
        // TODO: perform animation (maybe)
    }
}
