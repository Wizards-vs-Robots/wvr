using UnityEngine;

namespace Fighting
{
    public class SpellCasting : MonoBehaviour
    {
        public GameObject currentSpellPrefab;

        private ManaModel _mana;
        private float _cooldown;
        private Spell _currentSpell;
        private void Start()
        {
            _mana = gameObject.GetComponent<ManaModel>();
            _currentSpell = currentSpellPrefab.GetComponent<Spell>();
        }
        
        void Update()
        {
            if (_cooldown >= 0)
            {
                _cooldown -= Time.deltaTime;
                return;
            }

            var dir = GetDirInput();
            if (dir == Vector2.zero) return;
            
            if (_mana.currentManaPoints < _currentSpell.manaCost) return;
            
            var spellObject = Instantiate(currentSpellPrefab, transform.GetComponent<Renderer>().bounds.center ,Quaternion.identity);
            _mana.Use(_currentSpell.manaCost);
            spellObject.transform.Rotate(Vector3.forward, SpellUtil.CalculateAngle(dir));
            spellObject.GetComponent<Spell>().caster = gameObject;
            spellObject.GetComponent<Rigidbody2D>().velocity = dir * _currentSpell.spellSpeed;
            _cooldown = _currentSpell.cooldown;
            
        }

        private static Vector2 GetDirInput()
        {
            var dir = UnityEngine.Vector2.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
            }
            dir.Normalize();
            return dir;
        }
    }
}
