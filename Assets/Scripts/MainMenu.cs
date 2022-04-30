using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void PlayMultiplayerGame()
    {

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
