using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    private static readonly Color32 MAX_HEALTH_COLOR = new Color(0x0, 0xFF, 0x0);
    private static readonly Color32 MID_HEALTH_COLOR = new Color(0xFF, 0xEB, 0x0);
    private static readonly Color32 MIN_HEALTH_COLOR = new Color(0xFF, 0x0, 0x0);
    public Image background;

    public void UpdateView(float currentHealthPoints, float maxHealthPoints)
    {
    	float ratio = currentHealthPoints / maxHealthPoints;
    	float duration = 0.75f * ratio;
    	
    	//Fill the bar and interpolate the color.
        Color32 interpolation;
        if (ratio >= 0.5F) {
            interpolation = Color32.Lerp(MID_HEALTH_COLOR, MAX_HEALTH_COLOR, (ratio - 0.5F) * 2);
        } else {
            interpolation = Color32.Lerp(MIN_HEALTH_COLOR, MID_HEALTH_COLOR, ratio * 2);
        }

        background.color = interpolation;
        background.DOFillAmount(ratio, duration);
    }
}
