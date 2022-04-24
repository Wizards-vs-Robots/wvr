using UnityEngine;

namespace Fighting
{
    public class RobotSpell:Spell
    {
        public float spellSpeed;
        public Damage damage;
        public override void CastSpell(Vector2 direction,Vector3 pos)
        {
            var spellObj = Instantiate(gameObject, pos ,Quaternion.identity);
            spellObj.transform.Rotate(Vector3.forward, SpellUtil.CalculateAngle(direction));
            spellObj.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent(out Damagable damageable))
            {
                damageable.ReceiveDamage(damage);
            }
        }
    }
}