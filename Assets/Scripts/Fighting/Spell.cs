using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    
    public float manaCost;

    public float cooldown;
    public abstract void  CastSpell(Vector2 direction, Vector3 pos);
}
