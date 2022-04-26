using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedAction : CooldownAction
{
    public void Trigger(float duration)
    {
        this.cooldown = duration;
        this.Trigger();
    }

    public override void BeforeAction()
    {        
        // Does nothing.
        // Works by providing a timed blocking state that can be
        // tested when trying to move again.
    }

    public override void AfterAction()
    {
    }

    public override void BeforeCooldown()
    {
    }

    public override void AfterCooldown()
    {
    }
}
