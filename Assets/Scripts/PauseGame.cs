using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool active = false; //is the MENU active?
    public GameObject background;

    private int toggleID = -1;
    // Update is called once per frame
    
    private void Start()
    {
        Time.timeScale = 1F;
        active = false;
        background.SetActive(active);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyBindings.GetKeyBinding("pause_button")))
        {
            togglePause(0);
            active = !active;
            background.SetActive(active);
        }
    }
    public void ReturnToMainMenu()
    {
        Highscores.SaveHighscore();
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void togglePauseWrap()
    {
        togglePause(0);
        active = !active;
        background.SetActive(active);
    }
    public bool togglePause(int ID)
    {
        if(toggleID == -1){
            Time.timeScale = 1F - Time.timeScale;
            toggleID = ID;
            return true;
        }

        if (toggleID == ID)
        {
            Time.timeScale = 1F - Time.timeScale;
            toggleID = -1;
            return true;
        }

        return false;
    }

}
