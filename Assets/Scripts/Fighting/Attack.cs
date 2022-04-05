using UnityEngine;

namespace Fighting
{
    public abstract class Attack : MonoBehaviour
    {
        public abstract void Perform(Damagable on, GameObject by);
    }
}