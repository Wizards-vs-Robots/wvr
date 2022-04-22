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
            if (castSpellAction.waiting)
                return;

            // Change spell when pressing space
            // TODO: Move to central handling and give configurable key
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int nextSpell = (spellIndex + 1) & learnedSpells.Count;
                SetSpell(nextSpell);
            }
            
            // Retrieve shooting direction
            var dir = GetShootingDirection();
            if (dir == Vector2.zero)
                return;
            
            // Check if wizard has enough mana to cast spell
            if (manaModel.currentManaPoints < selectedSpell.manaCost)
                return;
           
            // Update stats and start cooldown
            castSpellAction.Trigger();
            manaModel.Use(selectedSpell.manaCost);

            // Spawn spell entity
            var spellObject = Instantiate(selectedSpellPrefab,
                                          transform.GetComponent<Renderer>().bounds.center,
                                          Quaternion.identity);
            spellObject.transform.Rotate(Vector3.forward,
                                         SpellUtil.CalculateAngle(dir));

            var body = spellObject.GetComponent<Rigidbody2D>();
            body.velocity = dir * selectedSpell.spellSpeed;
        }

        private static Vector2 GetShootingDirection()
        {
            var dir = UnityEngine.Vector2.zero;
            
            // Left and right shooting
            if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_left")))
                dir.x = -1;
            else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_right")))
                dir.x = 1;

            // Up and down shooting
            if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_up")))
                dir.y = 1;
            else if (Input.GetKey(KeyBindings.GetKeyBinding("player1_shoot_down")))
                dir.y = -1;

            dir.Normalize();
            return dir;
        }
    }
}
