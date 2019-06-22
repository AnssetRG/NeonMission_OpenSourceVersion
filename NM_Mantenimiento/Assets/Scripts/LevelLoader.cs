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
    public string levelTag;

    public Image black;
    public Animator anim;
    public int lvl;

    // Use this for initialization
    void Start()
    {
        playerInZone1 = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        PlayerPrefs.SetInt(levelTag, 1);
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(levelToLoad);
    }
}