using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MutualExclusiveActionExecutor : MonoBehaviour
{
    public MutualExclusiveAction action;

    void Update()
    {
        if (action == null)
            return;
            
        // Handle control
        if (Input.GetKeyDown(KeyBindings.GetKeyBinding("cooldown_action"))) {
            action.Update();
        }
    }
}
