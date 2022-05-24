using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MutualExclusiveAction : CooldownAction
{
    public int minScore;

    public bool IsUnlocked()
    {
        return Statics.GetScoreModel().GetScore() >= minScore;
    }
    
    public override void Start()
    {
        base.Start();
    }
}
