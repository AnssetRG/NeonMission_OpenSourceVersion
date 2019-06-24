using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {

    public string tutorial;
    public string selectLevel;
    public string lvl1tag;

    public void Tutorial()
    {
       Debug.Log("Start Game");
       SceneManager.LoadScene(tutorial);
    }

    public void Select()
    {
        PlayerPrefs.SetInt(lvl1tag, 1);

        if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition"))
        {
            PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        }
        SceneManager.LoadScene(selectLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
