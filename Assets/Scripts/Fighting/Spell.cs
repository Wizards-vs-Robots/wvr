using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float spellSpeed;

    public Damage damage;

    public float manaCost;

    public float cooldown;

    public GameObject caster;

    public Damagable target; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.Equals(caster)) return;
        Destroy(gameObject);
        if (other.gameObject.TryGetComponent(out Damagable damageable))
        {
            if (target != null && !damageable.Equals(target)) return;
            damageable.ReceiveDamage(damage);
        }
    }
}
