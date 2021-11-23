using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBarImage;
    
    public void UpdateManaBar(float currentManaPoints, float maxManaPoints) {
        float duration = 0.75f * (currentManaPoints / maxManaPoints);
        manaBarImage.DOFillAmount( currentManaPoints / maxManaPoints, duration );
    }
}
