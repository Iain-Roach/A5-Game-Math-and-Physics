using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuNav : MonoBehaviour
{
    public static MenuNav Instance { get; private set; }

    public void Awake()
    {
        if(Instance != null & Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // DontDestroyOnLoad(this);
            Instance = this;
        }
    }

   
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchCustomPhysics()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
