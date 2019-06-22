using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string starLevel;

    public void Newgame()
    {
        Debug.Log("Inicio");
        //SceneManager.LoadScene(starLevel);
        //Application.LoadLevel(starLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}

