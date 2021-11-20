using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Attack
{
    public Damage damage; 
    
    public abstract void ExecuteOn(IDamagable target, GameObject by);
}
