using System;
using Fighting;
using Pathfinding;
using UnityEngine;
using UnityEngine.Serialization;

namespace Robot
{
    public class Attacker : MonoBehaviour
    {
        public int minWave;
        public int maxWave;

        /// <summary>
        /// attackDelay in seconds (or fractions thereof) 
        /// </summary>
        public float attackDelay;
        /// <summary>
        /// attackRange in units (or fractions thereof) of which an attack will be conisdered
        /// </summary>
        public float attackRange;

        // This scaling factor is applied to the attacker's strength
        // before using it in the WaveManager's wave quota algorithm.
        //
        // It prevents the quota from being mostly used up by strong
        // attackers, which initially spawn in large quantities and
        // then only leave quota for weaker opponents. Hence, it
        // allows waves to grow more gradually and spawning
        // medium-strength robots.
        public float strengthScale;
        public float strength;
        public Attack attack;
        public Damagable target;

        private float _lastAttackTime;

        public float GetStrengthScale()
        {
            return strengthScale;
        }

        public float GetStrength()
        {
            return strength;
        }

        public void Update()
        {
            if (target == null)
                return;
                
            var dist = Vector3.Distance(this.transform.position, target.GetLocation());
            if (!(dist <= attackRange) || !(Time.time > _lastAttackTime + attackDelay))
                return;
            
            attack.Perform(target, this.gameObject);
            _lastAttackTime = Time.time;
        }
    }
}