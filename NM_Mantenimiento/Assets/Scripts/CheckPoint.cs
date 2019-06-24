using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public LevelManager levelManager;

    private SpriteRenderer myS;
    public AudioSource checkIncomplete;
    public AudioSource checkComplete;
    public Sprite nwS1;
    public Sprite nwS2;
    public Sprite nwS3;
    Sprite temp;
    //public bool playSound;

    //string val;

    bool finish;

    int completado;
    public int necesario;
    // Use this for initialization
    void Start()
    {
        //playSound = false;
        //if (necesario == 2)
        //{
        //    playSound = true;
        //}
        levelManager = FindObjectOfType<LevelManager>();
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
        completado = 2;
        finish = false;
        //val = gameObject.name;
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.5f);
    }

    // Update is called once per frame
    void Update () {

        if (levelManager.currentCheckPoint != gameObject && necesario == completado && finish)
        {
            myS.sprite = temp;
            finish = false;
            necesario = 0;
        }
        if (necesario == completado)
        {
            checkIncomplete.Stop();
            checkComplete.Play();
            levelManager.currentCheckPoint = gameObject;
            myS.sprite = nwS3;
            finish = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && finish == false)
        {
            necesario = necesario + 1;
            myS.sprite = nwS1;
            checkIncomplete.Play();
        }
        if (other.name == "Player2" && finish == false)
        {
            necesario = necesario + 1;
            myS.sprite = nwS2;
            checkIncomplete.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && !finish)
        {
            necesario = necesario - 1;
            myS.sprite = temp;
            //myC.enabled = false;
            //Debug.Log("Activated Checpoint " + transform.position);
        }
        if (other.name == "Player2" && !finish)
        {
            necesario = necesario - 1;
            myS.sprite = temp;
            //myC.enabled = false;
            //Debug.Log("Activated Checpoint " + transform.position);
        }
    }
}
