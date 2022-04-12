using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class SpellCasting : MonoBehaviour
    {
        public List<GameObject> learnedSpells;

        private ManaModel _mana;
        private float _cooldown;
        private Spell _currentSpell;
        private GameObject _currentSpellPrefab;
        public int spellIndex=0;

        private void Start()
        {
            _mana = gameObject.GetComponent<ManaModel>();
            _currentSpellPrefab = learnedSpells[spellIndex];
            _currentSpell = learnedSpells[spellIndex].GetComponent<Spell>();
        }
        
        void Update()
        {
            //Change Spells, Probably wrong location to do so?
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spellIndex = (spellIndex + 1) % learnedSpells.Count;
                _currentSpell = learnedSpells[spellIndex].GetComponent<Spell>();
                _currentSpellPrefab = learnedSpells[spellIndex];            
            }
            
            var dir = GetDirInput();
            if (dir == Vector2.zero) return;
            
            if (_cooldown >= 0)
            {
                _cooldown -= Time.deltaTime;
                return;
            }
            if (_mana.currentManaPoints < _currentSpell.manaCost) return;
            _currentSpell.CastSpell(dir, transform.GetComponent<Renderer>().bounds.center); 
            
            // var spellObject = Instantiate(_currentSpellPrefab, transform.GetComponent<Renderer>().bounds.center ,Quaternion.identity);
            // spellObject.transform.Rotate(Vector3.forward, SpellUtil.CalculateAngle(dir));
            // spellObject.GetComponent<Rigidbody2D>().velocity = dir * _currentSpell.spellSpeed;
            
            _cooldown = _currentSpell.cooldown;
            _mana.Use(_currentSpell.manaCost);
        }

        private static Vector2 GetDirInput()
        {
            var dir = UnityEngine.Vector2.zero;
            if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_left")))
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_right")))
            {
                dir.x = 1;
            }

            if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_up")))
            {
                dir.y = 1;
            }
            else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_down")))
            {
                dir.y = -1;
            }
            dir.Normalize();

            return dir;
        }
    }
}
