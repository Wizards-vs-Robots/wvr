using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Fighting
{
    public class Spell:MonoBehaviour
    {
        public float spellSpeed;

        public Damage damage;

        public float manaCost;

        public float cooldown;

        public GameObject caster;//Should this be public? Idk...
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.Equals(caster)) return;
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent(out Damagable damageable)) damageable.ReceiveDamage(damage);
        }
    }
}