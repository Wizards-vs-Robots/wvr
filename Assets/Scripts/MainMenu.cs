using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Statics.gameMode = Statics.GameMode.SINGLEPLAYER;
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void PlayMultiplayerGame()
    {
        Statics.gameMode = Statics.GameMode.LOCAL_MULTIPLAYER;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit(0);
    }
    
    public void Options()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}
