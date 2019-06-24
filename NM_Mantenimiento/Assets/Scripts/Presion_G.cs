using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presion_G : MonoBehaviour {

    public GameObject obj;
    // Use this for initialization

    private SpriteRenderer myS;
    public Sprite nwS;
    public AudioSource activeSound;
    private bool isPlayingMusic;

    float valor;

    Sprite temp;
    void Start()
    {
        isPlayingMusic = false;
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
        valor = obj.transform.GetComponent<Rotatorio>().speed;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player" && other.transform.GetComponent<PlayerController>().grounded)
        {
            obj.transform.GetComponent<Rotatorio>().speed = -valor;
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
        if (other.transform.tag == "Player")
        {
            obj.transform.GetComponent<Rotatorio>().speed = valor;
            myS.sprite = temp;
            isPlayingMusic = false;
        }
    }
}
