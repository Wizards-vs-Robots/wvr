using System;
using UnityEngine;

namespace Fighting
{
    public class MeleeAttack : Attack
    {
        public override void Perform(Damagable target, GameObject by)
        {
            target.ReceiveDamage(damage);
        }

        public void Update()
        {
            // do animation
        }
    }
}