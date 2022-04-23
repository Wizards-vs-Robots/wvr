using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAction : MutualExclusiveAction
{
    public WizardMovement control;
    public StunAction stunAction;
    public float startStunDuration;
    public float endStunDuration;
    public float distance;

    public override void Start()
    {
        base.Start();

        float stunDuration = startStunDuration + endStunDuration;
        stunAction.duration = stunDuration;
        this.duration = stunDuration;
    }

    public override void BeforeAction()
    {
        // Stop movement and trigger stun
        control.SetVelocity(Vector2.zero);
        stunAction.Trigger();

        // Start delayed teleport
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        // Wait until the initial stun is inactive
        yield return new WaitForSeconds(startStunDuration);

        // Calculate new location and teleport wizard there
        Vector2 difference = control.GetNormalizedDirection() * distance; 
        Vector2 end = control.GetPosition() + difference;
        control.SetPosition(end);
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
