using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class CooldownAction : MonoBehaviour
{
    public bool waiting;
    public float cooldown;
    public float elapsed;
    public Image background;

    public abstract void Execute();

    public void Update()
    {
        // Update cooldown background
        if (background != null && waiting)
        {
            // TODO: Does not work
            float ratio = elapsed / cooldown;
            //background.DOFillAmount(ratio, 1);
        }

        if (!waiting)
            StartCoroutine(Act());
        else
            elapsed += Time.deltaTime;
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
