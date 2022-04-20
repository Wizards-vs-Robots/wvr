using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CooldownAction : MonoBehaviour
{
    public bool waiting;
    public float cooldown;
    public float elapsed;
    public Image cooldownBackground;

    public abstract void Execute();

    public void Start()
    {
        if (cooldownBackground != null)
        {
            cooldownBackground.type = Image.Type.Filled;
            cooldownBackground.fillMethod = Image.FillMethod.Vertical;
        }
    }

    public void Update()
    {
        // Update cooldown background
        if (cooldownBackground != null && waiting)
            cooldownBackground.fillAmount = elapsed / cooldown;

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
        if (cooldownBackground != null)
            cooldownBackground.fillAmount = 0.0F;

        // Wait for some time before unblocking cooldown action
        yield return new WaitForSeconds(cooldown);
        waiting = false;
        elapsed = 0F;
    }

}
