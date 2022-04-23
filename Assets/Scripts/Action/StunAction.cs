using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAction : CooldownAction
{
    public WizardMovement control; 

    public override void BeforeAction()
    {
        control.stunned = true;
    }

    public override void AfterAction()
    {
        control.stunned = false;
    }

    public override void BeforeCooldown()
    {
    }

    public override void AfterCooldown()
    {
    }
}
