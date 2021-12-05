using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ManaView : MonoBehaviour
{
    public Image background;
    
    public void UpdateView(float currentManaPoints, float maxManaPoints) {
        float ratio = currentManaPoints / maxManaPoints;
        float duration = 0.75f * ratio;
        background.DOFillAmount(ratio, duration);
    }
}
