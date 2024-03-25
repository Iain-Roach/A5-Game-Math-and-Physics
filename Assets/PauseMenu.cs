using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseMenu;
    [SerializeField]
    private MouseDrag mouseDrag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Open menu
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);

            // Also disables mouse drag until "unpaused"
            if(mouseDrag)
            mouseDrag.enabled = !mouseDrag.enabled;
        }
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
