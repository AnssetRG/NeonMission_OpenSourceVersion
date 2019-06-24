using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    private bool playerInZone1;
    private bool playerInZone2;
    public string levelToLoad;
    public GameObject GanasteSprite;
    public Cronometro cronometroOB;
    public bool seleccionarLvl;

    public Image black;
    public Animator anim;
    public int lvl;
    private bool go;

    // Use this for initialization
    void Start()
    {
        playerInZone1 = false;
        GanasteSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInZone1 && playerInZone2 && !go)
        {
            GanasteSprite.SetActive(true);
            if (!seleccionarLvl)
            {
                cronometroOB.FinishLevelTimer();
                if (NewMenuPrincipalController.timeToBeatLvls[lvl] > cronometroOB.GetTime()){
                    /*Debug.Log("False: " + cronometroOB.GetTime() + " " + NewMenuPrincipalController.timeToBeatLvls[lvl]);
                else
                {*/
                    Debug.Log("True: " + cronometroOB.GetTime() + " " + NewMenuPrincipalController.timeToBeatLvls[lvl]);
                    NewMenuPrincipalController.timeToBeatLvls[lvl] = cronometroOB.GetTime();
                    Debug.Log("New Record: " + NewMenuPrincipalController.timeToBeatLvls[lvl]);
                }
                go = true;
               if(NewMenuPrincipalController.coinsCollected[lvl] == CoinsCounter.CoinsCollected)
                {
                    Debug.Log("Todas las monedas recolectadas");
                }else
                {
                    Debug.Log("Faltan recolectar " + (NewMenuPrincipalController.coinsCollected[lvl] - CoinsCounter.CoinsCollected));
                }
            }
            
        }
        if((Input.GetButtonDown("Jump_P1") || Input.GetButtonDown("Jump_P2")) && playerInZone1 && playerInZone2)
        {
            NewMenuPrincipalController.lvlPasado[lvl] = true;
            StartCoroutine(Fading());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone1 = true;
        }
        if (other.name == "Player2")
        {
            playerInZone2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone1 = false;
        }
        if (other.name == "Player2")
        {
            playerInZone2 = false;
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(levelToLoad);
    }
}