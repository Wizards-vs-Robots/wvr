using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;

    public void UpdateHealthBar(float currentHealthPoints, float maxHealthPoints) {
        float duration = 0.75f * (currentHealthPoints / maxHealthPoints);
        healthBarImage.DOFillAmount( currentHealthPoints / maxHealthPoints, duration );
        Color newColor = Color.green;
        if ( currentHealthPoints < maxHealthPoints * 0.25f ) {
            newColor = Color.red;
        } else if ( currentHealthPoints < maxHealthPoints * 0.66f ) {
            newColor = new Color( 1f, .64f, 0f, 1f );
        }
        healthBarImage.DOColor( newColor, duration );
    }
}