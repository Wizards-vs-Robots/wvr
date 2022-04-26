using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAction : MutualExclusiveAction
{
    public WizardMovement control;
    public float speed;

    public override void BeforeAction()
    {
        control.dashing = true;
        control.SetVelocity(control.GetNormalizedDirection() * 10.0F);
    }

    public override void AfterAction()
    {
        control.dashing = false;
    }  

    public override void BeforeCooldown()
    {
    }

    public override void AfterCooldown()
    {
    }
}
