    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColliderLevelToLoad : MonoBehaviour {

    public string lvlToLoad;
    private bool colission;
    private SpriteRenderer casilla;
    public Image black;
    public Animator anim;

    // Use this for initialization
    void Start () {
        colission = false;
        casilla = GetComponent < SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(colission);
        if (colission)
        {
            SceneManager.LoadScene(lvlToLoad);
        }
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            colission = true;
        }
    }

    /*IEnumerator Iniciar()
    {
        Time.timeScale = 2f;
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(lvlToLoad);
    }*/
}
