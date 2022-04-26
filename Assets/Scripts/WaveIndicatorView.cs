using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveIndicatorView : MonoBehaviour
{
    public TMP_Text label;
    public bool active;

    public float fadeDuration;
    public float waitDuration;

    public void Start()
    {
        // Set state and hide the indicator
        label.CrossFadeAlpha(0.0F, 0.0F, false);
        active = false;
    }

    public void UpdateView(int wave)
    {
        if (!active)
        {
            // Block unwelcomed successive calls and
            // indicate that wave has been defeated
            active = true;

            label.text = "Wave #" + wave + " defeated!";
            StartCoroutine(Indicate(wave));
        }
    }

    IEnumerator Indicate(int wave)
    {
        label.CrossFadeAlpha(1.0F, fadeDuration, false);
        yield return new WaitForSeconds(waitDuration);

        label.CrossFadeAlpha(0.0F, fadeDuration, false);
        active = false;
    }
}
