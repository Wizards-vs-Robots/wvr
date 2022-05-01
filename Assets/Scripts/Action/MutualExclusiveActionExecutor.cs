using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MutualExclusiveActionExecutor : MonoBehaviour
{
    public MutualExclusiveAction action;
    public string KeyBinding = "player1_cooldown_action";

    void Start()
    {
        if (action != null)
            action.Start();
    }

    void Update()
    {
        if (action == null)
            return;

        action.Update();

        // Handle control
        if (Input.GetKeyDown(KeyBindings.GetKeyBinding(KeyBinding)) &&
            action.IsUnlocked())
        {
            action.Trigger();
        }
    }
}
