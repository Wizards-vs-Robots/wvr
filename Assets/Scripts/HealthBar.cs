using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public HealthPoints healthPoints;

    public void UpdateHealthBar() {
        float duration = 0.75f * (healthPoints.currentHealthPoints / healthPoints.maxHealthPoints);
        healthBarImage.DOFillAmount( healthPoints.currentHealthPoints / healthPoints.maxHealthPoints, duration );
        Color newColor = Color.green;
        if ( healthPoints.currentHealthPoints < healthPoints.maxHealthPoints * 0.25f ) {
            newColor = Color.red;
        } else if ( healthPoints.currentHealthPoints < healthPoints.maxHealthPoints * 0.66f ) {
            newColor = new Color( 1f, .64f, 0f, 1f );
        }
        healthBarImage.DOColor( newColor, duration );
    }
}