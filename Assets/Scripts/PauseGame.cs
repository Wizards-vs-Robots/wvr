using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool active = false; //is the MENU active?
    public GameObject background;
    // Update is called once per frame
    
    private void Start()
    {
        Time.timeScale = 1F;
        active = false;
        background.SetActive(active);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Time.timeScale = 1F - Time.timeScale;
            active = !active;
            background.SetActive(active);
            new WaitForSecondsRealtime(2);
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void ResumeGame()
    {
        active = !active;
        Time.timeScale = 1F - Time.timeScale;
        background.SetActive(active);
    }

}
