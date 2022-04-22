using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float spellSpeed;//Not every Spell has a speed

    public Damage damage;
    public float manaCost;
    public float cooldown;

    public Damagable target; 
    //For Spells that do use Physics
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject,Time.maximumDeltaTime/2);
        if (other.collider.gameObject.TryGetComponent(out Damagable damageable))
        {
            if (target != null && !damageable.Equals(target)) return;
            damageable.ReceiveDamage(damage);
        }
    }

    //For spells that do not use Physics
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.TryGetComponent(out Damagable damageable))
        {
            if (target != null && !damageable.Equals(target)) return;
            damageable.ReceiveDamage(damage);
        }
    }
}
