using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaDrop : MonoBehaviour
{
    public int manaAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out WizardMovement wizardMovement))
        {
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent(out ManaModel manaModel))
            {
                manaModel.currentManaPoints = manaModel.currentManaPoints + manaAmount;
            }
        }
    }
}
