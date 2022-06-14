using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DefaultNamespace;
using Fighting;
using Fighting.Spells;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    private bool active = false; //is the MENU active?
    public GameObject background;
    public ManaModel manaModel;
    public HealthModel healthModel;
    public SpellCasting spells;
    public ManaModel manaModelCoop;
    public HealthModel healthModelCoop;
    public SpellCasting spellsCoop;

    public GameObject stonePrefab;
    public GameObject lightningPrefab;

    
    private void Start()
    {
        Time.timeScale = 1F;
        active = false;
        background.SetActive(active);
    }

    public void ResumeGame()
    {
        active = !active;
        Time.timeScale = 1F - Time.timeScale;
        background.SetActive(active);
    }
    
    public void ButtonOne(GameObject o)
    {
        if (!spentPoint(o)) return;

        var inc = o.GetComponentInParent<IncrementSetter>().incrementStatBy;
        healthModel.maxHealthPoints += inc;
        healthModel.currentHealthPoints += inc;

        if (Statics.gameMode == GameMode.LOCAL_MULTIPLAYER)
        {
            healthModelCoop.maxHealthPoints += inc;
            healthModelCoop.currentHealthPoints += inc;
        }
    }
    
    public void ButtonThree(GameObject o)
    {
        if (!spentPoint(o)) return;

        var inc = o.GetComponentInParent<IncrementSetter>().incrementStatBy;
        manaModel.maxManaPoints += inc;
        manaModel.currentManaPoints += inc;

        if (Statics.gameMode == GameMode.LOCAL_MULTIPLAYER)
        {
            manaModelCoop.maxManaPoints += inc;
            manaModelCoop.currentManaPoints += inc;

        }
    }

    public void ButtonStone(GameObject o)
    {
        if (!spentPoint(o)) return;
        
        spells.learnedSpells.Add(stonePrefab);
        if (Statics.gameMode == GameMode.LOCAL_MULTIPLAYER)spellsCoop.learnedSpells.Add(stonePrefab);
        o.GetComponentInParent<Button>().interactable = false;
    }

    public void ButtonLightning(GameObject o)
    {
        if (!spentPoint(o)) return;
        
        spells.learnedSpells.Add(lightningPrefab);
        if (Statics.gameMode == GameMode.LOCAL_MULTIPLAYER) spellsCoop.learnedSpells.Add(lightningPrefab);
        o.GetComponentInParent<Button>().interactable = false;
    }
    
    private bool spentPoint(GameObject o)
    {
        var price = o.GetComponentInParent<PriceSetter>().price;
        if (price > Statics.GetScoreModel().GetExperience())
        {
            return false;
        }
        
        Statics.GetScoreModel().SpendExperience(price);

        return true;
    }

    }