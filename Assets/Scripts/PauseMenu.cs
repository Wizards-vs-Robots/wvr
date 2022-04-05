using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
