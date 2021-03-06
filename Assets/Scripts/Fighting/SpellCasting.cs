using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class SpellCasting : MonoBehaviour
    {
        public CastSpellAction castSpellAction;
        public List<GameObject> learnedSpells;

        private ManaModel manaModel;

        public int spellIndex;
        private Spell selectedSpell;
        private GameObject selectedSpellPrefab;
        
        public string keyUp = "player1_shoot_up";
        public string keyDown = "player1_shoot_down";
        public string keyRight = "player1_shoot_right";
        public string keyLeft = "player1_shoot_left";
        public string keyChangeSpell = "player1_change_spell";

        void Start()
        {
            // Retrieve visual components
            manaModel = gameObject.GetComponent<ManaModel>();
            SetSpell(0);
        }

        private void SetSpell(int index)
        {
            spellIndex = index;

            // Retrieve spell
            selectedSpellPrefab = learnedSpells[spellIndex];
            selectedSpell = learnedSpells[spellIndex].GetComponent<Spell>();
            
            // Instantiate spell casting action for cooldown effect
            castSpellAction.cooldown = selectedSpell.cooldown;
        }
        
        void Update()
        {
            // Nothing can be done, when the spell cooldown is
            // still active. Neither spells can be thrown, nor
            // can spells be swapped during this period of time
            if (castSpellAction.active || castSpellAction.waiting)
                return;

            ChangeSpell();
            
            // Retrieve shooting direction
            var dir = GetShootingDirection();
            
            if (dir == Vector2.zero || manaModel.currentManaPoints < selectedSpell.manaCost) return;
            
            castSpellAction.Trigger();
            selectedSpell.CastSpell(dir, transform.GetComponent<Renderer>().bounds.center);
            manaModel.Use(selectedSpell.manaCost);
        }

        private void ChangeSpell()
        {
            if (Input.GetKeyDown(KeyBindings.GetKeyBinding(keyChangeSpell)))
            {
                int nextSpell = (spellIndex + 1) % learnedSpells.Count;
                SetSpell(nextSpell);
            }
        }

        private Vector2 GetShootingDirection()
        {
            var dir = UnityEngine.Vector2.zero;
            
            // Left and right shooting
            if (Input.GetKey(KeyBindings.GetKeyBinding(keyLeft)))
                dir.x = -1;
            else if (Input.GetKey(KeyBindings.GetKeyBinding(keyRight)))
                dir.x = 1;

            // Up and down shooting
            if (Input.GetKey(KeyBindings.GetKeyBinding(keyUp)))
                dir.y = 1;
            else if (Input.GetKey(KeyBindings.GetKeyBinding(keyDown)))
                dir.y = -1;

            dir.Normalize();
            return dir;
        }
    }
}
