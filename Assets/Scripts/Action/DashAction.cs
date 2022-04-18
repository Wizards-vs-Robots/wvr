using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAction : MonoBehaviour
{
    public WizardMovement movement;
    public Rigidbody2D body;

    void Update()
    {
        if (Input.GetKey(KeyBindings.GetKeyBinding("cooldown_action"))) {
            Debug.Log(movement.direction * 100F);
            body.AddForce(movement.direction * 100F);
        }
    }
}
