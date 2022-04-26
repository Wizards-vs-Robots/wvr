using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CooldownAction : MonoBehaviour
{
    public bool active;
    public bool waiting;
    public float duration;
    public float cooldown;
    public float elapsed;
    public Image cooldownBackground;

    public abstract void BeforeAction();
    public abstract void AfterAction();
    public abstract void BeforeCooldown();
    public abstract void AfterCooldown();

    public virtual void Start()
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
        if (!active && !waiting)
            StartCoroutine(Act());
    }

    IEnumerator Act()
    {
        // Action and reset cooldown indicator
        active = true;
        BeforeAction();

        // Hide cooldown indicator
        if (cooldownBackground != null)
            cooldownBackground.fillAmount = 0.0F;

        // Wait for some time
        yield return new WaitForSeconds(duration);
        AfterAction();
        active = false;

        // Cooldown Handling
        waiting = true;
        BeforeCooldown();

        // Wait for some time
        yield return new WaitForSeconds(cooldown);
        elapsed = 0F;
        AfterCooldown();
        waiting = false;
    }

}
