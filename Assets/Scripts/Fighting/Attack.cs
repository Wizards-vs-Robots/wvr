using UnityEngine;

namespace Fighting
{
    public abstract class Attack : MonoBehaviour
    {
        /// <summary>
        /// damage is used for the attack
        /// </summary>
        public Damage damage;
        
        public abstract void Perform(Damagable on, GameObject by);
    }
}