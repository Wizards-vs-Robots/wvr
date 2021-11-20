using UnityEngine;

namespace Fighting
{
    public class MeleeAttack : Attack
    {
        public override void ExecuteOn(IDamagable target, GameObject by)
        {
            // TODO: Add animation
            target.ReceiveDamage(damage);
        }
    }
}