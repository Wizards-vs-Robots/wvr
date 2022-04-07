using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void change(int scene)
    {
        SceneManager.LoadScene(sceneBuildIndex: scene);
    }
}
