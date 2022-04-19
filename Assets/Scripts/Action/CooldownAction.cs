using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CooldownAction : MonoBehaviour
{
    private bool waiting;
    public float cooldown;

    public abstract void Execute();

    public void Update()
    {
        if (!waiting)
            StartCoroutine(Act());
    }

    IEnumerator Act()
    {
        Execute();
        waiting = true;

        // Wait for some time before unblocking cooldown action
        yield return new WaitForSeconds(cooldown);
        waiting = false;
    }

}
