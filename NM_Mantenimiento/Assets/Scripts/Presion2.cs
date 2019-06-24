using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presion2 : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;
    // Use this for initialization

    private SpriteRenderer myS;
    public Sprite nwS;
    public AudioSource activeSound;

    private bool isPlayingMusic;
    public bool temp2;
    Sprite temp;
    void Start()
    {
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable"/* && other.transform.GetComponent<PlayerController>().grounded*/)
        {
            //obj.transform.GetComponent<Rotatorio>().speed = -1;
            if (obj1.transform.GetComponent<PlataformaMov>() != null)
                obj1.transform.GetComponent<PlataformaMov>().Act = true;
            if (obj1.transform.GetComponent<Rotatorio>() != null)
                obj1.transform.GetComponent<Rotatorio>().Act = true;
            if (obj1.transform.GetComponent<Generador>() != null)
                obj1.transform.GetComponent<Generador>().Act = false;
            if (obj1.transform.GetComponent<GeneradorB>() != null)
                obj1.transform.GetComponent<GeneradorB>().Act = true;

            if (obj2.transform.GetComponent<PlataformaMov>() != null)
                obj2.transform.GetComponent<PlataformaMov>().Act = true;
            if (obj2.transform.GetComponent<Rotatorio>() != null)
                obj2.transform.GetComponent<Rotatorio>().Act = true;
            if (obj2.transform.GetComponent<Generador>() != null)
                obj2.transform.GetComponent<Generador>().Act = false;
            if (obj2.transform.GetComponent<GeneradorB>() != null)
                obj2.transform.GetComponent<GeneradorB>().Act = true;
            myS.sprite = nwS;
            if (!isPlayingMusic)
            {
                activeSound.Play();
                isPlayingMusic = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable")
        {
            if (obj1.transform.GetComponent<PlataformaMov>() != null)
                obj1.transform.GetComponent<PlataformaMov>().Act = false;
            if (obj1.transform.GetComponent<Rotatorio>() != null)
                obj1.transform.GetComponent<Rotatorio>().Act = false;
            if (obj1.transform.GetComponent<Generador>() != null)
                obj1.transform.GetComponent<Generador>().Act = true;
            if (obj1.transform.GetComponent<GeneradorB>() != null)
                obj1.transform.GetComponent<GeneradorB>().Act = false;

            if (obj2.transform.GetComponent<PlataformaMov>() != null)
                obj2.transform.GetComponent<PlataformaMov>().Act = false;
            if (obj2.transform.GetComponent<Rotatorio>() != null)
                obj2.transform.GetComponent<Rotatorio>().Act = false;
            if (obj2.transform.GetComponent<Generador>() != null)
                obj2.transform.GetComponent<Generador>().Act = true;
            if (obj2.transform.GetComponent<GeneradorB>() != null)
                obj2.transform.GetComponent<GeneradorB>().Act = false;


            myS.sprite = temp;
            isPlayingMusic = false;
        }

    }
}
