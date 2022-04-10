using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * use this as experience, just need to change the name+asset. Though it would make more sense to use coins as
 * means to buy more spells etc instead of "experience coins"
 */
public class CoinDrop : MonoBehaviour
{
    public int moneyAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out WizardMovement wizardMovement))
        {
            Destroy(gameObject);
            {
                GameObject scoreField = GameObject.FindGameObjectsWithTag("Score")[0];
                ScoreModel view = scoreField.GetComponent<ScoreModel>();
                view.Increment(moneyAmount * 10);
                //do your magic here
            }
        }
    }
}
