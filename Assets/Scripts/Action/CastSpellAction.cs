using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpellAction : CooldownAction
{
    public override void Execute()
    {
        // Does nothing.
        // Works by providing a timed blocking state that can be
        // tested when trying to cast a spell again.
    }
}
