using System;
using UnityEngine;

namespace Fighting.Spells
{
    public class Earthball:Spell
    {
        public float spellSpeed;
        public Damage damage;
        private bool _dealtDmg = false;
        
        private void Start()
        {
            InvokeRepeating("SpinRock",0.1f,0.05f);
        }
        
        //Performance probably terrible but idk how to animate and it seems to complicated :)
        void SpinRock()
        {
            transform.Rotate((Vector3.forward),45f);
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.gameObject.TryGetComponent(out Damagable damageable))
            {
                if (!_dealtDmg)
                {
                    _dealtDmg = true;
                    if(damageable.ReceiveDamage(damage))
                    {
                        Destroy(gameObject);
                    }
                    Destroy(gameObject,Time.maximumDeltaTime);
                }
            }
            else
            {
                Destroy(gameObject); 
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