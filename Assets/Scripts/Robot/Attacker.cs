using System;
using UnityEngine;

namespace Robot
{
    public class Attacker : MonoBehaviour
    {
        /**
         * attackDelay in seconds (or fractions thereof) 
         */
        public float attackDelay;
        /**
         * attackRange in units (or fractions thereof) of which an attack will be conisdered
         */
        public float attackRange;
        /**
         * Attack is executed once in range and not conflicting with attackDelay
         */
        public Attack attack;

        /**
         * target will be attacked with attack when conditions fit
         */
        public IDamagable target;
        
        private float lastAttackTime; 
        
        public void Update()
        {
            var dist = Vector3.Distance(this.transform.position, target.GetLocation());
            if (!(dist <= attackRange) || !(Time.time > lastAttackTime + attackDelay)) return;
            
            attack.ExecuteOn(target, this.gameObject);
            lastAttackTime = Time.time;
        }
    }
}