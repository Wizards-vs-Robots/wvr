using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CooldownAction : MonoBehaviour
{
    public bool waiting;
    public float cooldown;
    public float elapsed;
    public Image background;

    public abstract void Execute();

    public void Start()
    {
        if (background != null)
            background.type = Image.Type.Filled;
    }

    public void Update()
    {
        // Update cooldown background
        if (background != null && waiting)
            background.fillAmount = elapsed / cooldown;

        // Increment elapsed time counter
        if (waiting)
            elapsed += Time.deltaTime;
    }

    public void Trigger()
    {
        // Action is only triggered, when it is not already running
        if (!waiting)
            StartCoroutine(Act());
    }

    IEnumerator Act()
    {
        // Execute and initiate waiting state
        Execute();
        waiting = true;

        // Reset cooldown background
        if (background != null)
        {
            // TODO: Does not get updated
            background.fillAmount = 0.0F;
        }

        // Wait for some time before unblocking cooldown action
        yield return new WaitForSeconds(cooldown);
        waiting = false;
        elapsed = 0F;
    }

}
