using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public Vector3 GetLocation(); 
    public void ReceiveDamage(Damage damage);
}
