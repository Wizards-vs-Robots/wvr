using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageAction : CooldownAction
{
    public override void Execute()
    {
        // Does nothing.
        // Works by providing a timed blocking state that can be
        // tested when re-attacking the player.
    }
}
