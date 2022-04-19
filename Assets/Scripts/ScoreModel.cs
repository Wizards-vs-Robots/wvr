using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField]
    private int _score;
    public ScoreView scoreView;

    public void Increment(int value)
    {
        _score += value;
        scoreView.UpdateView(_score);
    }

    public void Decrement(int value) {
        _score -= value;
        scoreView.UpdateView(_score);
    }

    public int GetScore() => _score;

    public void Start()
    {
        scoreView.UpdateView(_score);
    }
}
