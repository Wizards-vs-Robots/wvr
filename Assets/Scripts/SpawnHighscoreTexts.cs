using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHighscoreTexts : MonoBehaviour
{
    public GameObject textPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var v in Highscores.Get())
        {
            var t = Instantiate(textPrefab, this.transform, false);
            t.GetComponent<Text>().text = $"{v.score} at {v.time:yyyy-MM-dd HH:mm:ss}"; 
        }
    }
}
