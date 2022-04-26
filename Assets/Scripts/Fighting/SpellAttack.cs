using System;
using UnityEngine;

namespace Fighting
{
    public class SpellAttack : Attack
    {
        public GameObject currentSpellPrefab;

        public override void Perform(Damagable on, GameObject by)
        {
            var pos = transform.position + Vector3.up * 0.3f;
            var dir = (on.GetLocation() - pos).normalized;
            var spell = currentSpellPrefab.GetComponent<RobotSpell>();
            spell.CastSpell(dir,pos);
        }
    }
}