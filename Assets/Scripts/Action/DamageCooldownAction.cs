using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCooldownAction : CooldownAction
{
    public override void BeforeAction()
    {
        // Does nothing.
        // Works by providing a timed blocking state that can be
        // tested when re-attacking the player.
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
