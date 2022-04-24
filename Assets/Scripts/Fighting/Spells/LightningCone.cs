using System;
using UnityEngine;

namespace Fighting.Spells
{
    public class LightningCone:Spell
    {
        public Damage damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Damagable damageable))
            {
                damageable.ReceiveDamage(damage);
            }
        }

        public override void CastSpell(Vector2 dir, Vector3 pos)
        {
            pos = new Vector3(pos.x + dir.x, pos.y + dir.y, pos.z);
            var spellObject = Instantiate(gameObject, pos ,Quaternion.identity);
            spellObject.transform.Rotate(Vector3.forward, SpellUtil.CalculateAngle(dir));
            Destroy(spellObject,Time.maximumDeltaTime);
        }
    }
}