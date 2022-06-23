using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkillMenu : MonoBehaviour
{
    public SkillTree sT;
    private void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.gameObject.layer == 26){
            sT.ResumeGame();
        }
    }
}
