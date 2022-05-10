using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statics
{
    private static ScoreModel scoreModel;
    private static WaveIndicatorView waveIndicator;

    public static GameMode gameMode = GameMode.SINGLEPLAYER;
    
    public enum GameMode {
        SINGLEPLAYER,
        LOCAL_MULTIPLAYER
    }

    public static void Initialize()
    {
        scoreModel = GameObject.FindGameObjectsWithTag("Score")[0]
                               .GetComponent<ScoreModel>();

        waveIndicator = GameObject.FindGameObjectsWithTag("WaveIndicator")[0]
                                  .GetComponent<WaveIndicatorView>();        
        waveIndicator.Start();
    }

    public static ScoreModel GetScoreModel()
    {
        return scoreModel;
    }

    public static WaveIndicatorView GetWaveIndicator()
    {
        return waveIndicator;
    }
}