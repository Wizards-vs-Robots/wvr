using System;
using Fighting;
using UnityEngine;

namespace Robot
{
    public class Attacker : MonoBehaviour
    {
        /// <summary>
        /// attackDelay in seconds (or fractions thereof) 
        /// </summary>
        public float attackDelay;
        /// <summary>
        /// attackRange in units (or fractions thereof) of which an attack will be conisdered
        /// </summary>
        public float attackRange;
        public Attack attack;
        public Damagable target;
        
        private float _lastAttackTime;

        public void Update()
        {
            var dist = Vector3.Distance(this.transform.position, target.GetLocation());
            if (!(dist <= attackRange) || !(Time.time > _lastAttackTime + attackDelay)) return;
            
            attack.Perform(target, this.gameObject);
            _lastAttackTime = Time.time;
        }
    }
}