using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreModel : MonoBehaviour
{
    [SerializeField]
    private int _score;
    public ScoreView scoreView;
    public Text expView;

    private int _exp;
    public int GetExperience() => _exp;

    public void SpendExperience(int spent)
    {
        _exp -= spent;
        expView.text = _exp.ToString();
    }

    public void Increment(int value)
    {
        double expFactor = Math.PI * Math.E;
        _exp += (int) (value / expFactor); 
        _score += value;
        scoreView.UpdateView(_score);
        expView.text = _exp.ToString();
    }

    public int GetScore() => _score;

    public void Start()
    {
        scoreView.UpdateView(_score);
    }
}
