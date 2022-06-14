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
    //Do something
    public void ButtonOne()
    {
        
        healthModel.maxHealthPoints += 10;
        healthModel.currentHealthPoints += 10;
    }
    
    public void ButtonTwo()
    {
     //idk what to do here   
    }
    public void ButtonThree()
    {
        manaModel.maxManaPoints += 10;
        manaModel.currentManaPoints += 10;
    }

    }