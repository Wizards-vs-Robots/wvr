using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    public TMP_Text label;

    public void UpdateView(int score)
    {
        label.text = "Score: " + score;
    }
}
