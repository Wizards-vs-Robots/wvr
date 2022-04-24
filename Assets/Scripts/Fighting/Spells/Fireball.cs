using UnityEngine;

namespace Fighting.Spells
{
    public class Fireball:Spell
    {
        public float spellSpeed;
        public Damage damage;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent(out Damagable damageable))
            {
                damageable.ReceiveDamage(damage);
            }
        }

        public override void CastSpell(Vector2 dir, Vector3 pos)
        {
            var spellObject = Instantiate(gameObject, pos ,Quaternion.identity);
            spellObject.transform.Rotate(Vector3.forward, SpellUtil.CalculateAngle(dir));
            spellObject.GetComponent<Rigidbody2D>().velocity = dir * spellSpeed; 
        }
    }
}