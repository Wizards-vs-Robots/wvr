using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public int healthAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out WizardMovement wizardMovement))
        {
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent(out HealthModel healthModel))
            {
                healthModel.currentHealthPoints = healthModel.currentHealthPoints + healthAmount;
            }
        }
    }
}