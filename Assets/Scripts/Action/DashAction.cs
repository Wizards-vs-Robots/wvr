using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAction : MutualExclusiveAction
{
    public WizardMovement control;

    public override void Execute()
    {
        control.dashing = true;
        control.dash = control.direction * 100F;
    }
}
