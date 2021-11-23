using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image manaBarImage;
    public ManaPoints manaPoints;
    
    public void UpdateManaBar() {
        float duration = 0.75f * (manaPoints.currentManaPoints / manaPoints.maxManaPoints);
        manaBarImage.DOFillAmount( manaPoints.currentManaPoints / manaPoints.maxManaPoints, duration );
    }
}
