using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPoints : MonoBehaviour
{
    public float currentManaPoints;
    public float maxManaPoints;
    public ManaBar manaBar;

    public void UseMana(float cost)
    {
        currentManaPoints -= cost;
        manaBar.UpdateManaBar();
    }

    public void ManaRegen()
    {
        if (currentManaPoints < maxManaPoints)
        {
            currentManaPoints += (1 * Time.deltaTime);  
            manaBar.UpdateManaBar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            UseMana(10);
        }
        ManaRegen();
    }
}
