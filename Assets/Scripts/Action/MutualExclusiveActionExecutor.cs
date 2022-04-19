using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutualExclusiveActionExecutor : MonoBehaviour
{
    public MutualExclusiveAction action;

    void Update()
    {
        if (action == null)
            return;

        if (Input.GetKeyDown(KeyBindings.GetKeyBinding("cooldown_action"))) {
            action.Update();
        }
    }
}
