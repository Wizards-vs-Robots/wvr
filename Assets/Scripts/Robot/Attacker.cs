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

        public float strengthRating;
        public Attack attack;
        public Damagable target;

        private float _lastAttackTime;

        public float GetStrength()
        {
            return strengthRating;
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