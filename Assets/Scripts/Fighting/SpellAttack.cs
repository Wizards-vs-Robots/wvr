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
            
            var spellObject = Instantiate(currentSpellPrefab, pos, Quaternion.identity);

            spellObject.transform.Rotate(Vector3.forward, SpellUtil.CalculateAngle(dir));
            var spell = spellObject.GetComponent<Spell>();
            spell.target = on;
            spellObject.GetComponent<Rigidbody2D>().velocity = dir * spell.spellSpeed;
        }
    }
}