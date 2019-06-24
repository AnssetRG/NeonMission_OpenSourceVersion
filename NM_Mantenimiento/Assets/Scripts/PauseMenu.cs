using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private string mainMenu;
    public string selectLevel;
    public bool isPaused;
    public GameObject pauseMenuCanvas;
    // Use this for initialization
    void Start () {
        mainMenu = "Title_Menu";

    }
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(mainMenu);
    }
}
